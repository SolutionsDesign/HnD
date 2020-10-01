
-- ###############################################################################################################
-- DROP statements for elements no longer needed or replaced elements.
-- ###############################################################################################################
-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'HnD'
-- ----------------------------------------------------------------------------------------------------------------

USE [HnD_LLBLGen]
GO

ALTER TABLE [dbo].[Thread] DROP COLUMN [ThreadLastPostingDate]
GO


-- ###############################################################################################################
-- ADD statements for new elements (except FK/UC)
-- ###############################################################################################################
-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'HnD'
-- ----------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[ThreadStatistics] 
(
	[ThreadID] [int] NOT NULL, 
	[LastMessageID] [int] NOT NULL, 
	[NumberOfMessages] [int] NOT NULL, 
	[NumberOfViews] [int] NOT NULL 
)
GO

-- ###############################################################################################################
-- ALTER statements for table fields and ADD statements for new primary key constraints
-- ###############################################################################################################
-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'HnD'
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[ThreadStatistics] WITH NOCHECK 
	ADD CONSTRAINT [PK_c0958924ef9b7ecf06dccd2537e] PRIMARY KEY CLUSTERED 
	( 
		[ThreadID] 
	)
GO

-- ###############################################################################################################
-- ADD statements for new foreign key constraints, unique constraints and default values
-- ###############################################################################################################
-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'HnD'
-- ----------------------------------------------------------------------------------------------------------------


ALTER TABLE [dbo].[ThreadStatistics] 
	ADD CONSTRAINT [UC_19c59ce41b5be7a6d2c358322d4] UNIQUE NONCLUSTERED
	(
		[LastMessageID] 
	)
GO

ALTER TABLE [dbo].[ThreadStatistics] 
	ADD CONSTRAINT [FK_2033ff74285bde08311a5a99ae1] FOREIGN KEY
	(
		[LastMessageID] 
	)
	REFERENCES [dbo].[Message]
	(
		[MessageID] 
	)
	ON DELETE CASCADE
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[ThreadStatistics] 
	ADD CONSTRAINT [FK_15e6b0a402d80d4e4b0df3453c5] FOREIGN KEY
	(
		[ThreadID] 
	)
	REFERENCES [dbo].[Thread]
	(
		[ThreadID] 
	)
	ON DELETE CASCADE
	ON UPDATE NO ACTION
GO

-- ###############################################################################################################
-- FILL ThreadStatistics
-- ###############################################################################################################
INSERT INTO ThreadStatistics
SELECT        
		MessageAggregate.[ThreadID],
		MessageAggregate.[LastMessageID] AS LastMessageID,
        MessageAggregate.[NumberOfMessages],
		COALESCE(T.NumberOfViews, 0)
FROM   (
			SELECT	[HnD_LLBLGen].[dbo].[Message].[ThreadID],
		            MAX([HnD_LLBLGen].[dbo].[Message].[MessageID])   AS [LastMessageID],
					COUNT([HnD_LLBLGen].[dbo].[Message].[MessageID]) AS [NumberOfMessages]
			FROM	[HnD_LLBLGen].[dbo].[Message]
			GROUP  BY [HnD_LLBLGen].[dbo].[Message].[ThreadID]
		) AS MessageAggregate
        INNER JOIN Thread T
            ON MessageAggregate.ThreadID = T.ThreadID
GO

-- ###############################################################################################################
-- DROP NumberOfViews in thread, as we no longer need it. 
-- ###############################################################################################################

ALTER TABLE [dbo].[Thread] DROP CONSTRAINT DF_Thread_NumberOfViews
GO

ALTER TABLE [dbo].[Thread] DROP COLUMN [NumberOfViews]
GO


-- ###############################################################################################################
-- CREATE index on fk field in ThreadStatistics
-- ###############################################################################################################
CREATE NONCLUSTERED INDEX [IX_ThreadStatistics] ON [dbo].[ThreadStatistics]
(
	[LastMessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
