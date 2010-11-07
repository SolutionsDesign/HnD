-- Upgrade script of database of HnD v2.0 to v2.1. 
-- This script won't remove anything, it will migrate varchar/text types to nvarchar/ntext and will 
-- replace the init stored proc, and add some additional values for auditing. Please check the SQL first
-- before running the script on your database. 

-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
--
--      FIRST CREATE A BACKUP OF YOUR DATABASE
--
-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

---------------------------------------------------------------------------------------------
-- Migration of varchar/text fields to nvarchar/ntext.
---------------------------------------------------------------------------------------------

-- First drop all indexes on the columns to alter

DROP INDEX [dbo].[ActionRight].[TF_ActionRight_AK1]
GO

DROP INDEX [dbo].[Forum].[TF_Forum_AK1] 
GO

DROP INDEX [dbo].[Forum].[TF_Forum_AK2]
GO

DROP INDEX [dbo].[Role].[TF_Role_AK1]
GO

DROP INDEX [dbo].[Section].[TF_Section_AK1]
GO

DROP INDEX [dbo].[Section].[TF_Section_AK2]
GO

DROP INDEX [dbo].[Thread].[TF_Thread_AK1]
GO

DROP INDEX [dbo].[User].[TF_User_AK1]
GO

DROP INDEX [dbo].[UserTitle].[TF_UserTitle_AK1]
GO

ALTER TABLE [User]
	DROP CONSTRAINT [TF_User_NickName_U2]
GO

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'disable' 
GO

exec sp_fulltext_column N'[dbo].[Message]', N'MessageText', N'drop', 1033  
GO

exec sp_fulltext_table N'[dbo].[Message]', N'drop'  
GO

exec sp_fulltext_column N'[dbo].[Thread]', N'Subject', N'drop', 1033  
GO

exec sp_fulltext_table N'[dbo].[Thread]', N'drop'  
GO

-- alter columns using a generic script. credit:
-- http://forums.microsoft.com/technet/showpost.aspx?postid=1868356&siteid=17&sb=0&d=1&at=7&ft=11&tf=0&pageid=2
DECLARE @rowCount int
DECLARE @altersql nvarchar(1024)
DECLARE @columnName nvarchar(256)
DECLARE @todatatable nvarchar(200)
DECLARE @size nvarchar(200)
DECLARE @aReturn nvarchar(256)
DECLARE @tableName nvarchar(256)
DECLARE @todatatype nvarchar(256)
DECLARE @patchName nvarchar(256)
DECLARE @nullable nvarchar(256)
DECLARE @existing nvarchar(256)
DECLARE @newcol nvarchar(256)

BEGIN TRAN ConvertTypes

SET @rowCount = 1
SELECT
IDENTITY(int, 1, 1) AS aKey,
TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,
(CASE WHEN IS_NULLABLE='yes' THEN 'NULL'
 WHEN IS_NULLABLE='no' AND DATA_TYPE='varchar' THEN 'NOT NULL'
 WHEN IS_NULLABLE='no' AND DATA_TYPE='text' THEN 'NOT NULL CONSTRAINT [TEMP_DefaultValue]  DEFAULT (N''test'')' END) AS nullable
INTO #TempColumns FROM INFORMATION_SCHEMA.COLUMNS
WHERE (DATA_TYPE='varchar' OR DATA_TYPE='text') AND TABLE_NAME NOT IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS)
AND TABLE_NAME != 'dtproperties' AND COLUMN_NAME NOT IN ('PostedFromIp', 'IPNumber')
ORDER BY TABLE_NAME

WHILE @rowCount < (SELECT MAX(aKey) FROM #TempColumns)
BEGIN
 SELECT @tablename=TABLE_NAME, @columnname=COLUMN_NAME,
  @todatatype=(CASE WHEN DATA_TYPE='varchar' THEN 'nvarchar' WHEN DATA_TYPE='text' THEN 'ntext' END),
  @size=(CASE WHEN DATA_TYPE='varchar' THEN '(' + CAST(CHARACTER_MAXIMUM_LENGTH AS NVARCHAR(10)) + ') '
   WHEN DATA_TYPE='text' THEN ' ' END),
  @nullable=nullable
  FROM #TempColumns WHERE aKey=@rowCount
 IF @todatatype='nvarchar'
 BEGIN
  SET @altersql = N'ALTER TABLE [dbo].[' + @tablename + '] ALTER COLUMN [' + @columnname + '] [' + @todatatype + '] ' + @size + @nullable
  PRINT @altersql
  EXEC @aReturn=[dbo].sp_executesql @altersql
  IF @@ERROR <> 0 OR @aReturn <> 0 GOTO Error
 END
 ELSE
 BEGIN
  SELECT @existing = N'dbo.' + @tablename + '.' + @columnname, @newcol=@columnname + '_OLD'
  PRINT N'-- [' + @patchName + '] - Rename existing column "' + @existing + '" to "' + @newcol + '".'
  EXEC @aReturn=sp_rename @existing, @newcol, 'COLUMN'
  IF @@ERROR <> 0 OR @aReturn <> 0 GOTO Error

  SET @altersql = N'ALTER TABLE [dbo].[' + @tablename + '] ADD [' + @columnname + '] [' + @todatatype + '] ' + @size + @nullable
  PRINT N'-- [' + @patchName + '] - Add new NULLABLE column "' + @columnname + '".'
  EXEC @aReturn=[dbo].sp_executesql @altersql
  IF @@ERROR <> 0 OR @aReturn <> 0
  BEGIN
   SET @existing = N'dbo.' + @tablename + '.' + @newcol
   SET @newcol=@columnname
   PRINT N' - ERROR, renaming changed column back.'
   EXEC @aReturn=sp_rename @existing, @newcol, 'COLUMN'
   IF @@ERROR <> 0 OR @aReturn <> 0 GOTO Error 
  
   GOTO Error
  END
  
  PRINT '-- [' + @patchName + '] - Update new column "' + @columnname + '" with data in column "' + @newcol + '".'
  SET @altersql = N'UPDATE [dbo].[' + @tablename + '] SET [' + @columnname + ']=[' + @newcol + ']'
  PRINT @altersql
  EXEC @aReturn=[dbo].sp_executesql @altersql
  IF @@ERROR <> 0 OR @aReturn <> 0 GOTO Error

  PRINT N'-- [' + @patchName + '] - Drop old column "' + @newcol + '".'
  SET @altersql = N'ALTER TABLE [dbo].' + @tablename + ' DROP COLUMN [' + @newcol + ']'
  EXEC @aReturn=[dbo].sp_executesql @altersql
  IF @@ERROR <> 0 OR @aReturn <> 0 GOTO Error

  IF @todatatype='ntext' AND @nullable != 'NULL'
  BEGIN
   PRINT N'-- [' + @patchName + '] - Drop the temporary default constraint "TEMP_DefaultValue".'
   SET @altersql = N'ALTER TABLE [dbo].[' + @tablename + '] DROP CONSTRAINT [TEMP_DefaultValue]'
   EXEC @aReturn=[dbo].sp_executesql @altersql
   IF @@ERROR <> 0 OR @aReturn <> 0 GOTO Error
  END
 END

 SET @rowCount = @rowCount + 1
END

COMMIT
GOTO Rebuild

Error:
ROLLBACK
Return

Rebuild:

-- recreate indexes
 CREATE  UNIQUE  INDEX [TF_ActionRight_AK1] ON [dbo].[ActionRight]([ActionRightDescription]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_Forum_AK1] ON [dbo].[Forum]([ForumName]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_Forum_AK2] ON [dbo].[Forum]([ForumDescription]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_Role_AK1] ON [dbo].[Role]([RoleDescription]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_Section_AK1] ON [dbo].[Section]([SectionName]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_Section_AK2] ON [dbo].[Section]([SectionDescription]) ON [PRIMARY]
GO

 CREATE  INDEX [TF_Thread_AK1] ON [dbo].[Thread]([Subject]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_User_AK1] ON [dbo].[User]([NickName]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [TF_UserTitle_AK1] ON [dbo].[UserTitle]([UserTitleDescription]) ON [PRIMARY]
GO

ALTER TABLE [User]
	ADD CONSTRAINT [TF_User_NickName_U2] UNIQUE  NONCLUSTERED 
	(
		[NickName]
	)  ON [PRIMARY] 
GO

-- Re-enable full text search
if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 
GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'TF_FullTextCatalog')
exec sp_fulltext_catalog N'TF_FullTextCatalog', N'create' 
GO

exec sp_fulltext_table N'[dbo].[Message]', N'create', N'TF_FullTextCatalog', N'TF_Message_PK'
GO

exec sp_fulltext_column N'[dbo].[Message]', N'MessageText', N'add', 1033  
GO

exec sp_fulltext_table N'[dbo].[Message]', N'activate'  
GO

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 
GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'TF_FullTextCatalog')
exec sp_fulltext_catalog N'TF_FullTextCatalog', N'create' 
GO

exec sp_fulltext_table N'[dbo].[Thread]', N'create', N'TF_FullTextCatalog', N'TF_Thread_PK'
GO
exec sp_fulltext_column N'[dbo].[Thread]', N'Subject', N'add', 1033  
GO

exec sp_fulltext_table N'[dbo].[Thread]', N'activate'  
GO


---------------------------------------------------------------------------------------------
-- Insert new AuditRight value
---------------------------------------------------------------------------------------------
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (6, N'Audit approve attachment')

---------------------------------------------------------------------------------------------
-- Drop of install proc and install of new one. 
---------------------------------------------------------------------------------------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_Install]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_Install]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-----------------------
-- Installs all necessary data to get the HnD system up and running.
CREATE PROCEDURE [pr_Install]
	@sAdminEmailAddress nvarchar(150)
AS
DECLARE	@iAnonymousRoleID int,
	@iAdminRoleID int,
	@iUserRoleID int,
	@iUserID int,
	@iUserTitleID int,
	@iForumID int,
	@iSectionID int

-- CREATE ActionRights
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (1, N'Add and Edit Message', 1, 0)	-- add a new message and edit your own
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (2, N'Access Forum', 1, 0) 		-- have access to a forum
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (3, N'User Management', 0, 1)		-- set all kinds of userproperties/rights
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (4, N'Security Management', 0, 1)		-- set rights on roles, create new roles, assign roles to forums etc.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (5, N'Edit And Delete Other Users Messages', 1,0)	-- edit other users' messages
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (6, N'Forum Specific Thread Management', 1, 0)	-- edit thread's properties like sticky and closed, and move threads
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (7, N'System Management', 0, 1)		-- change system settings like new section/forum etc.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (8, N'Add and Edit Message in Sticky Thread', 1, 0)	-- add a new message to a sticky thread and edit your own 
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (9, N'System Wide Thread Management', 0, 1) -- administrate threads system wide.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (10, N'Add Normal Thread', 1, 0) -- Add a normal thread to a forum
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (11, N'Add Sticky Thread', 1, 0) -- Add a sticky thread to a forum
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (12, N'Edit Thread Memo', 1, 0) -- Edit the memo field of a thread
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (13, N'Flag Thread As Done', 1, 0) -- Flag a thread not started by the user as done.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (14, N'Queue Content Management', 0, 1) -- perform content management of support queues.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (15, N'View Normal Threads Started by Others', 1, 0) -- view threads started by others in threadview and message view.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (16, N'Manage Other Users Attachments', 1, 0) -- ability to manage/delete attachments of others
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (17, N'Add Attachment', 1, 0) -- Add an attachment to a message (and also delete it)
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (18, N'Gets Attachments Approved Automatically', 1, 0) -- Attachments added are approved automatically.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (19, N'Approve Attachment', 1, 0) -- Ability to approve and revoke approval of an attachment of a person.

-- CREATE Administrators Role
INSERT Role (RoleDescription)
	VALUES (N'Administrators Role')
SELECT @iAdminRoleID = SCOPE_IDENTITY()
-- CREATE UserTitle entry
INSERT UserTitle (UserTitleDescription)
	VALUES (N'Administrator')
SELECT @iUserTitleID = SCOPE_IDENTITY()
-- CREATE Admin user
-- Password is MD5 hashed 'admin', or: ISMvKXpXpadDiUoOSoAfww==
INSERT [User] (NickName, Password, IsBanned, IPNumber, Signature, IconURL, EmailAddress, 		UserTitleID, DateOfBirth, Occupation, Location, Website, SignatureAsHTML, JoinDate, AmountOfPostings, EmailAddressIsPublic)
	VALUES (N'Admin', N'ISMvKXpXpadDiUoOSoAfww==', 0, N'', N'', N'', @sAdminEmailAddress, @iUserTitleID, 0, N'', N'', N'', N'', GETDATE(), 0, 0)
SELECT @iUserID = SCOPE_IDENTITY()
-- Add new admin user to new role
INSERT RoleUser (RoleID, UserID)
	VALUES (@iAdminRoleID, @iUserID)

-- Add system rights to new role
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 3)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 4)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 7)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 9)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 14)

-- CREATE Default User role
INSERT Role (RoleDescription)
	VALUES (N'User Role')
SELECT @iUserRoleID = SCOPE_IDENTITY()
-- Add admin to this role
INSERT RoleUser (RoleID, UserID)
	VALUES (@iUserRoleID, @iUserID)

-- CREATE Anonymous Role
INSERT Role (RoleDescription)
	VALUES (N'Anonymous user Role')
SELECT @iAnonymousRoleID = SCOPE_IDENTITY()

-- CREATE UserTitle entry
INSERT UserTitle (UserTitleDescription)
	VALUES (N'User')
SELECT @iUserTitleID = SCOPE_IDENTITY()

-- CREATE Anonymous user. 
SET IDENTITY_INSERT [User] ON
INSERT [User] (UserID, NickName, Password, IsBanned, IPNumber, Signature, IconURL, EmailAddress, 
		UserTitleID, DateOfBirth, Occupation, Location, Website, SignatureAsHTML, JoinDate, AmountOfPostings, EmailAddressIsPublic)
	VALUES (0, N'Anonymous', N'', 0, N'', N'', N'', N'', @iUserTitleID, NULL, N'', N'', N'', N'', GETDATE(), 0, 0)
-- Add anonymous user to anonymous role
INSERT RoleUser (RoleID, UserID)
	VALUES (@iAnonymousRoleID, 0)

-- Insert the one row in the system data table. Set the values to the defaults. 
INSERT SystemData(DefaultRoleNewUser, AnonymousRole, DefaultUserTitleNewUser, HoursThresholdForActiveThreads, PageSizeSearchResults, 
	MinNumberOfThreadsToFetch, MinNumberOfNonStickyVisibleThreads, SendReplyNotifications)
	VALUES (@iUserRoleID, @iAnonymousRoleID, @iUserTitleID, 48, 25, 25, 5, 1)

-- Create General Section
INSERT Section (SectionName, SectionDescription)
	VALUES (N'General', N'Section with general forums')
SELECT @iSectionID = SCOPE_IDENTITY()

-- Create General forum, place it in the general section
INSERT Forum (SectionID, ForumName, ForumDescription, ForumLastPostingDate)
	VALUES (@iSectionID, N'General Chat', N'Forum for offtopic talk', NULL)
SELECT @iForumID = SCOPE_IDENTITY()

-- Add all action rights which apply to forum for the admin role to the general chat forum
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	SELECT 	@iForumID AS ForumID, 
		@iAdminRoleID,
		ActionRightID
	FROM ActionRight
	WHERE AppliesToForum = 1

-- Add User role with the edit/add rights to this forum.
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iUserRoleID, 1)
-- Add User role with the access forum right to this forum.
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iUserRoleID, 2)
-- Add User role with the view other people's threads right to this forum
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iUserRoleID, 15)

-- Add Anonymous role with the access forum right to this forum
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iAnonymousRoleID, 2)

-- Add audit actions
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (1, N'Audit login')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (2, N'Audit new message')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (3, N'Audit new thread')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (4, N'Audit altered message')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (5, N'Audit edit memo')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (6, N'Audit approve attachment')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




