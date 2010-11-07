/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Data;
using System.Collections;
using System.Security.Cryptography;

using SD.HnD.Utility;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;

namespace SD.HnD.BL
{
	/// <summary>
	/// General class which manages the security in the System.
	/// </summary>
	public static class SecurityManager
	{
		#region Enums
		/// <summary>
		/// Standard enum which is used to signal back the authentication result of an authentication request. 
		/// </summary>
		public enum AuthenticateResult:int
		{
			/// <summary>
			/// Authentication was succesful
			/// </summary>
			AllOk,
			/// <summary>
			/// Authentication wasn't succesful, the combination of username and password was wrong.
			/// </summary>
			WrongUsernamePassword,
			/// <summary>
			/// The user couldn't be authenticated because the user is currently banned.
			/// </summary>
			IsBanned
		}
		#endregion

		/// <summary>
		/// Audits the login of the user with the id specified.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditLogin(int userID)
		{
			AuditDataCoreEntity toLog = new AuditDataCoreEntity();
			toLog.AuditActionID = (int)AuditActions.AuditLogin;
			toLog.UserID = userID;
			toLog.AuditedOn = DateTime.Now;
			return toLog.Save();
		}

		
		/// <summary>
		/// Audits the creation of a new thread by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditNewThread(int userID, int threadID)
		{
			AuditDataThreadRelatedEntity toLog = new AuditDataThreadRelatedEntity();
			toLog.AuditActionID = (int)AuditActions.AuditNewThread;
			toLog.UserID = userID;
			toLog.AuditedOn = DateTime.Now;
			toLog.ThreadID = threadID;
			return toLog.Save();
		}


		/// <summary>
		/// Audits the edit of the memo field for a thread by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditEditMemo(int userID, int threadID)
		{
			AuditDataThreadRelatedEntity toLog = new AuditDataThreadRelatedEntity();
			toLog.AuditActionID = (int)AuditActions.AuditEditMemo;
			toLog.UserID = userID;
			toLog.AuditedOn = DateTime.Now;
			toLog.ThreadID = threadID;
			return toLog.Save();
		}


		/// <summary>
		/// Audits the approval of an attachment. We'll log the approval of an attachment with the messageid, as attachments are stored related to a message.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="attachmentID">The attachment ID.</param>
		public static bool AuditApproveAttachment(int userID, int attachmentID)
		{
			AuditDataMessageRelatedEntity toLog = new AuditDataMessageRelatedEntity();

			AttachmentCollection collection = new AttachmentCollection();
			// use a scalar query to obtain the message id so we don't have to pull it completely in memory. An attachment can be big in size so we don't want to 
			// read the entity to just read the messageid. We could use excluding fields to avoid the actual attachment data, but this query is really simple.
			// this query will return 1 value directly from the DB, so it won't read all attachments first into memory.
			int messageID = (int)collection.GetScalar(AttachmentFieldIndex.MessageID, null, AggregateFunction.None, (AttachmentFields.AttachmentID==attachmentID));
			toLog.AuditActionID = (int)AuditActions.AuditApproveAttachment;
			toLog.UserID = userID;
			toLog.MessageID = messageID;
			toLog.AuditedOn = DateTime.Now;
			return toLog.Save();
		}


		/// <summary>
		/// Audits the creation of a new message by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="messageID">Message ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditNewMessage(int userID, int messageID)
		{
			AuditDataMessageRelatedEntity toLog = new AuditDataMessageRelatedEntity();
			toLog.AuditActionID = (int)AuditActions.AuditNewMessage;
			toLog.UserID = userID;
			toLog.AuditedOn = DateTime.Now;
			toLog.MessageID = messageID;
			return toLog.Save();
		}


		/// <summary>
		/// Audits the alternation of a message by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="messageID">Message ID.</param>
		/// <returns></returns>
		public static bool AuditAlteredMessage(int userID, int messageID)
		{
			AuditDataMessageRelatedEntity toLog = new AuditDataMessageRelatedEntity();
			toLog.AuditActionID = (int)AuditActions.AuditAlteredMessage;
			toLog.UserID = userID;
			toLog.AuditedOn = DateTime.Now;
			toLog.MessageID = messageID;
			return toLog.Save();
		}


		/// <summary>
		/// Persists the IP ban unit of work passed into this method. The call to this method originates from the form which manages IP bans with
		/// one LLBLGenProDataSource controls which is used to persist changes. This LLBLGenProDataSource produces a UnitOfWork when the
		/// PerformWork event is raised and this UoW contains the changes to persist. This routine persists these changes. 
		/// </summary>
		/// <param name="uow">The unitofwork object which contains 1 or more changes (with standard .NET controls, this is 1) to persist.</param>
		public static void PersistIPBanUnitOfWork(UnitOfWork uow)
		{
			// pass a new transaction to the commit routine and auto-commit this transaction when the transaction is complete.
			uow.Commit(new Transaction(IsolationLevel.ReadCommitted, "PersistIPBans"), true);
		}


		/// <summary>
		/// Creates a new Role in the system. If the user specified a role description that is already available, the unique constraint violation will be 
		/// caught and 0 is returned in that case.
		/// </summary>
		/// <param name="roleDescription">Description to store</param>
		/// <returns>new RoleID if succeeded. If the description was already available, 0 is returned</returns></returns>
		public static int CreateNewRole(string roleDescription)
		{
			if(CheckIfRoleDescriptionIsPresent(roleDescription))
			{
				// is already present
				return 0;
			}

			RoleEntity newRole = new RoleEntity();
			newRole.RoleDescription = roleDescription;

			int toReturn = 0;
			bool result = newRole.Save();
			if(result)
			{
				// save was succesful, read back the ID that was just created so we can return that to the caller. 
				toReturn = newRole.RoleID;
			}
			return toReturn;
		}


		/// <summary>
		/// Modifies the given role: it resets the system action rights for the given role to the given set of action rights and it modifies
		/// the role description for the given role. If the user specified a role description that is already available, false will be returned to signal
		/// that the save failed.
		/// </summary>
		/// <param name="actionRightIDs">The action rights.</param>
		/// <param name="roleID">The role ID.</param>
		/// <param name="roleDescription">The role description.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool ModifyRole(List<int> actionRightIDs, int roleID, string roleDescription)
		{
			// read the existing role entity from the database. 
			RoleEntity roleToModify = new RoleEntity(roleID);
			if(roleToModify.IsNew)
			{
				// not found
				return false;
			}

			// check if the description is different. If so, we've to check if the new roledescription is already present. If so, we'll
			// abort the save
			if(roleToModify.RoleDescription != roleDescription)
			{
				if(CheckIfRoleDescriptionIsPresent(roleDescription))
				{
					// new description, is already present, fail
					return false;
				}
			}

			// all set. We're going to delete all Role - SystemAction Rights combinations first, as we're going to re-insert them later on. 
			// We'll use a transaction to be able to roll back all our changes if something fails. 
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "ModifyRole");
			try
			{
				RoleSystemActionRightCollection roleActionRights = new RoleSystemActionRightCollection();
				// add this collection to the transaction so all actions executed through this collection will be inside the transaction
				trans.Add(roleActionRights);
				// delete all role-systemactionright combinations directly from the database, by issuing a direct delete on the database, using a filter
				// on roleid
				roleActionRights.DeleteMulti((RoleSystemActionRightFields.RoleID == roleID));

				// add new role-systemactionright entities which we'll save to the database after that
				foreach(int actionRightID in actionRightIDs)
				{
					RoleSystemActionRightEntity toAdd = new RoleSystemActionRightEntity();
					toAdd.ActionRightID = actionRightID;
					toAdd.RoleID = roleID;
					roleActionRights.Add(toAdd);
				}
				// save the new entities to the database
				roleActionRights.SaveMulti();

				// we'll now save the role and the role description, if it's changed. Otherwise the save action will be a no-op. 
				// add it to the transaction
				trans.Add(roleToModify);
				roleToModify.RoleDescription = roleDescription;
				roleToModify.Save();

				// all done, commit the transaction
				trans.Commit();
				return true;
			}
			catch
			{
				// failed, roll back transaction.
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}


		/// <summary>
		/// Saves the audit actions for role specified. First removes all present rows for the roleid
		/// </summary>
		/// <param name="auditActionIDs">Audit action IDs.</param>
		/// <param name="roleID">Role ID.</param>
		/// <returns>true if the save action succeeded, false otherwise</returns>
		public static bool SaveAuditActionsForRole(List<int> auditActionIDs, int roleID)
		{
			RoleAuditActionCollection roleAuditActions = new RoleAuditActionCollection();
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "SaveAuditActionsForRole");
			
			// add this collection to the transaction so all actions executed through this collection will be inside the transaction
			trans.Add(roleAuditActions);

			try
			{
				// first remove the existing rows for the role
				roleAuditActions.DeleteMulti((RoleAuditActionFields.RoleID == roleID));

				// THEN add new ones to the same collection. 
				foreach(int auditActionID in auditActionIDs)
				{
					RoleAuditActionEntity newRoleAuditAction = new RoleAuditActionEntity();
					newRoleAuditAction.AuditActionID = auditActionID;
					newRoleAuditAction.RoleID = roleID;
					roleAuditActions.Add(newRoleAuditAction);
				}

				// save all new entities
				roleAuditActions.SaveMulti();

				// succeeded, commit transaction
				trans.Commit();
				return true;
			}
			catch
			{
				// failed, rollback transaction
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}


		/// <summary>
		/// Saves the given set of actionrights as the set of forum action rights for the given forum / role combination.
		/// It first removes all current action rights for that combination.
		/// </summary>
		/// <param name="actionRightIDs">List of actionrights to set of this role</param>
		/// <param name="roleID">Role to use</param>
		/// <param name="forumID">Forum to use</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool SaveForumActionRightsForForumRole(List<int> actionRightIDs, int roleID, int forumID)
		{
			ForumRoleForumActionRightCollection forumRightsPerRole = new ForumRoleForumActionRightCollection();
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "SaveForumActionRights");

			// add this collection to the transaction so all actions executed through this collection will be inside the transaction
			trans.Add(forumRightsPerRole);
			try
			{
				// first remove the existing rows for the role
                forumRightsPerRole.DeleteMulti((ForumRoleForumActionRightFields.RoleID == roleID) & (ForumRoleForumActionRightFields.ForumID == forumID));

				// THEN add new ones
				foreach(int actionRightID in actionRightIDs)
				{
					ForumRoleForumActionRightEntity newForumRightPerRole = new ForumRoleForumActionRightEntity();
					newForumRightPerRole.ActionRightID = actionRightID;
					newForumRightPerRole.ForumID = forumID;
					newForumRightPerRole.RoleID = roleID;
					forumRightsPerRole.Add(newForumRightPerRole);
				}

				// save the new entities
				forumRightsPerRole.SaveMulti();

				// all done, commit transaction
				trans.Commit();
				return true;
			}
			catch
			{
				// failed, rollback transaction
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}
		

		/// <summary>
		/// Adds all users which ID's are stored in UsersToAdd, to the role with ID RoleID.
		/// </summary>
		/// <param name="userIDsToAdd">List with UserIDs of the users to add</param>
		/// <param name="roleID">ID of role the users will be added to</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool AddUsersToRole(List<int> userIDsToAdd, int roleID)
		{
			if(userIDsToAdd.Count<=0)
			{
				return true;
			}

			RoleUserCollection roleUsers = new RoleUserCollection();
			// for each userid in the list, add a new entity to the collection
			foreach(int userID in userIDsToAdd)
			{ 
				RoleUserEntity newRoleUser = new RoleUserEntity();
				newRoleUser.UserID = userID;
				newRoleUser.RoleID = roleID;
				roleUsers.Add(newRoleUser);
			}
			
			// save the new role-user combinations
			return (roleUsers.SaveMulti() > 0);
		}


		/// <summary>
		/// Removes all users which ID's are stored in UsersToRemove, from the role with ID RoleID.
		/// </summary>
		/// <param name="userIDsToRemove">ArrayList with UserIDs of the users to Remove</param>
		/// <param name="roleID">ID of role the users will be removed from</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool RemoveUsersFromRole(List<int> userIDsToRemove, int roleID)
		{
			if(userIDsToRemove.Count<=0)
			{
				return true;
			}

			// we'll delete all role-user combinations for the users in the given range plus for the given role. 
			// if there's just one user, we'll use an optimization, as the range query will result in an IN (param, param... ) query, 
			// and an field IN (param) query, is much slower compared to field = param, at least on Sqlserver.

			// produce the filter which will be used to filter out the entities to delete. 
			PredicateExpression filter = new PredicateExpression();
			if(userIDsToRemove.Count == 1)
			{
				// use compare value predicate instead
				filter.Add((RoleUserFields.UserID == userIDsToRemove[0]));
			}
			else
			{
				// add a range filter
				filter.Add((RoleUserFields.UserID == userIDsToRemove));
			}
			// add the filter for the role as with AND.
			filter.AddWithAnd((RoleUserFields.RoleID == roleID));

			// delete the entities directly from the database. As this gives a single DELETE statement, we don't have to start a transaction manually.
			RoleUserCollection roleUsers = new RoleUserCollection();
			return (roleUsers.DeleteMulti(filter) > 0);
		}


		/// <summary>
		/// Deletes the given role from the system.
		/// </summary>
		/// <param name="roleID">ID of role to delete</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool DeleteRole(int roleID)
		{
			RoleEntity toDelete = SecurityGuiHelper.GetRole(roleID);
			if(toDelete == null)
			{
				// not found
				return false;
			}

			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "DeleteRole");

			try
			{
				// remove the role - forum - action right entities
				ForumRoleForumActionRightCollection forumRoleActionRights = new ForumRoleForumActionRightCollection();
				trans.Add(forumRoleActionRights);
				forumRoleActionRights.DeleteMulti(ForumRoleForumActionRightFields.RoleID == roleID);

				// Remove role-audit action entities
				RoleAuditActionCollection roleAuditActions = new RoleAuditActionCollection();
				trans.Add(roleAuditActions);
				roleAuditActions.DeleteMulti(RoleAuditActionFields.RoleID == roleID);

				// remove Role - systemright entities
				RoleSystemActionRightCollection roleSystemRights = new RoleSystemActionRightCollection();
				trans.Add(roleSystemRights);
				roleSystemRights.DeleteMulti(RoleSystemActionRightFields.RoleID == roleID);

				// remove Role - user entities
				RoleUserCollection roleUsers = new RoleUserCollection();
				trans.Add(roleUsers);
				roleUsers.DeleteMulti(RoleUserFields.RoleID == roleID);

				// delete the actual role
				trans.Add(toDelete);
				toDelete.Delete();
				trans.Commit();
				return true;
			}
			catch
			{
				// error occured, rollback
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}

		
		/// <summary>
		/// Checks if the user with the given NickName exists in the database. This is necessary to check if a user which gets authenticated through
		/// forms authentication is still available in the database. 
		/// </summary>
		/// <param name="nickName">The nickname of the user to check if he/she exists in the database</param>
		/// <returns>true if user exists, false otherwise.</returns>
		public static bool DoesUserExist(string nickName)
		{
			UserEntity user = new UserEntity();
			// fetch the user using the unique constraint functionality.
			return user.FetchUsingUCNickName(nickName);
		}


		/// <summary>
		/// Checks if the user with the given UserID exists in the database.
		/// </summary>
		/// <param name="userID">The UserID of the user to check if he/she exists in the database</param>
		/// <returns>true if user exists, false otherwise. </returns>
		public static bool DoesUserExist(int userID)
		{
			UserEntity user = new UserEntity(userID);
			// return true if the user entity was fetched succesfully, i.e.: the entity isn't new anymore.
			return (!user.IsNew);
		}


        /// <summary>
        /// Checks if the user with the given NickName exists in the database. This is necessary to check if a user which gets authenticated through
        /// forms authentication is still available in the database.
        /// </summary>
        /// <param name="nickName">The nickname of the user to check if he/she exists in the database</param>
        /// <param name="user">The user object is returned</param>
        /// <returns>true if user exists, false otherwise.</returns>
        public static bool DoesUserExist(string nickName, out UserEntity user)
        {
            user = new UserEntity();
            // fetch the user using the unique constraint functionality.
            return user.FetchUsingUCNickName(nickName);
        }

		
		/// <summary>
		/// Authenticates the user with the given Nickname and the given Password.
		/// </summary>
		/// <param name="nickName">Nickname of the user</param>
		/// <param name="password">Password of the user</param>
		/// <returns>AuthenticateResult.AllOk if the user could be authenticated, 
		///	AuthenticateResult.WrongUsernamePassword if user couldn't be authenticated given the current credentials,
		/// AuthenticateResult.IsBanned if the user is banned. </returns>
		public static AuthenticateResult AuthenticateUser(string nickName, string password, out UserEntity user)
		{
			// fetch the Roles related to the user when fetching the user, using a prefetchPath object.
            PrefetchPath prefetchPath = new PrefetchPath((int)EntityType.UserEntity);
            prefetchPath.Add(UserEntity.PrefetchPathRoles);

			// fetch the user data using the nickname which has a unique constraint
            user = new UserEntity();
            bool fetchResult = user.FetchUsingUCNickName(nickName, prefetchPath);

			if(!fetchResult)
			{
				// not found. Simply return that the user has specified a wrong username/password combination. 
				return AuthenticateResult.WrongUsernamePassword;
			}

			// user was found, check if the user can be authenticated and has specified the correct password.
			if(user.IsBanned)
			{
				// user is banned. We'll report that to the caller
                return AuthenticateResult.IsBanned;
			}
			else
			{
				// check password and UserID. We disallow the user with id 0 to login as that's the anonymous coward ID for a user not logged in.
				string md5HashedPassword = HnDGeneralUtils.CreateMD5HashedBase64String(password);
				if((md5HashedPassword == user.Password)&&(user.UserID != Globals.UserIDToDenyLogin))
				{
					// correct username/password combination
                    return AuthenticateResult.AllOk;
				}
				else
				{
					// something was wrong, report wrong authentication combination
                    return AuthenticateResult.WrongUsernamePassword;
				}
			}
		}


		/// <summary>
		/// Checks if the specified role description is already present.
		/// </summary>
		/// <param name="roleDescription">The role description.</param>
		/// <returns>true if the role description is already present, otherwise false.</returns>
		private static bool CheckIfRoleDescriptionIsPresent(string roleDescription)
		{
			// check if the role description is already available. Do that by performing a GetDbCount query on the role entities using a filter for the description.
			RoleCollection roles = new RoleCollection();
			// perform the getdbcount query.
			int count = roles.GetDbCount((RoleFields.RoleDescription == roleDescription));
			return (count > 0);
		}
	}
}
