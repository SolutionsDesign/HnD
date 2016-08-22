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
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.HelperClasses;

using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.Linq;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

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
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataCoreEntity
							{
								AuditActionID = (int)AuditActions.AuditLogin,
								UserID = userID,
								AuditedOn = DateTime.Now
							};
				return adapter.SaveEntity(toLog);
			}
		}

		
		/// <summary>
		/// Audits the creation of a new thread by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditNewThread(int userID, int threadID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataThreadRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditNewThread,
								UserID = userID,
								AuditedOn = DateTime.Now,
								ThreadID = threadID
							};
				return adapter.SaveEntity(toLog);
			}
		}


		/// <summary>
		/// Audits the edit of the memo field for a thread by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditEditMemo(int userID, int threadID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataThreadRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditEditMemo,
								UserID = userID,
								AuditedOn = DateTime.Now,
								ThreadID = threadID
							};
				return adapter.SaveEntity(toLog);
			}
		}


		/// <summary>
		/// Audits the approval of an attachment. We'll log the approval of an attachment with the messageid, as attachments are stored related to a message.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="attachmentID">The attachment ID.</param>
		public static bool AuditApproveAttachment(int userID, int attachmentID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// use a scalar query to obtain the message id so we don't have to pull it completely in memory. An attachment can be big in size so we don't want to 
				// read the entity to just read the messageid. We could use excluding fields to avoid the actual attachment data, but this query is really simple.
				// this query will return 1 value directly from the DB, so it won't read all attachments first into memory.
				int messageID = adapter.FetchScalar<int>(new QueryFactory().Create().Select(AttachmentFieldIndex.MessageID).Where(AttachmentFields.AttachmentID == attachmentID));
				var toLog = new AuditDataMessageRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditApproveAttachment,
								UserID = userID,
								MessageID = messageID,
								AuditedOn = DateTime.Now
							};
				return adapter.SaveEntity(toLog);
			}
		}


		/// <summary>
		/// Audits the creation of a new message by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="messageID">Message ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static bool AuditNewMessage(int userID, int messageID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataMessageRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditNewMessage,
								UserID = userID,
								AuditedOn = DateTime.Now,
								MessageID = messageID
							};
				return adapter.SaveEntity(toLog);
			}
		}


		/// <summary>
		/// Audits the alternation of a message by the specified user
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="messageID">Message ID.</param>
		/// <returns></returns>
		public static bool AuditAlteredMessage(int userID, int messageID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataMessageRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditAlteredMessage,
								UserID = userID,
								AuditedOn = DateTime.Now,
								MessageID = messageID
							};
				return adapter.SaveEntity(toLog);
			}
		}


		/// <summary>
		/// Persists the IP ban unit of work passed into this method. The call to this method originates from the form which manages IP bans with
		/// one LLBLGenProDataSource controls which is used to persist changes. This LLBLGenProDataSource produces a UnitOfWork when the
		/// PerformWork event is raised and this UoW contains the changes to persist. This routine persists these changes. 
		/// </summary>
		/// <param name="uow">The unitofwork object which contains 1 or more changes (with standard .NET controls, this is 1) to persist.</param>
		public static void PersistIPBanUnitOfWork(UnitOfWork2 uow)
		{
			// pass a new transaction to the commit routine and auto-commit this transaction when the transaction is complete.
			uow.Commit(new DataAccessAdapter(), true);
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
			using(var adapter = new DataAccessAdapter())
			{
				var newRole = new RoleEntity {RoleDescription = roleDescription};
				return adapter.SaveEntity(newRole) ? newRole.RoleID : 0;
			}
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
			var roleActionRights = new EntityCollection<RoleSystemActionRightEntity>();
			// add new role-systemactionright entities which we'll save to the database after that
			foreach(int actionRightID in actionRightIDs)
			{
				var toAdd = new RoleSystemActionRightEntity
							{
								ActionRightID = actionRightID,
								RoleID = roleID
							};
				roleActionRights.Add(toAdd);
			}

			using(var adapter = new DataAccessAdapter())
			{
				// read the existing role entity from the database. 
				var roleToModify = new RoleEntity(roleID);
				var result = adapter.FetchEntity(roleToModify);
				if(!result)
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
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "ModifyRole");
				try
				{
					adapter.DeleteEntitiesDirectly(typeof(RoleSystemActionRightEntity), new RelationPredicateBucket(RoleSystemActionRightFields.RoleID == roleID));
					adapter.SaveEntityCollection(roleActionRights);
					// we'll now save the role and the role description, if it's changed. Otherwise the save action will be a no-op. 
					roleToModify.RoleDescription = roleDescription;
					adapter.SaveEntity(roleToModify);
					// all done, commit the transaction
					adapter.Commit();
					return true;
				}
				catch
				{
					// failed, roll back transaction.
					adapter.Rollback();
					throw;
				}
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
			var roleAuditActions = new EntityCollection<RoleAuditActionEntity>();
			foreach(int auditActionID in auditActionIDs)
			{
				var newRoleAuditAction = new RoleAuditActionEntity
										 {
											 AuditActionID = auditActionID,
											 RoleID = roleID
										 };
				roleAuditActions.Add(newRoleAuditAction);
			}
			using(var adapter = new DataAccessAdapter())
			{ 
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "SaveAuditActionsForRole");
				try
				{
					// first delete the current entities directly from the db
					adapter.DeleteEntitiesDirectly(typeof(RoleAuditActionEntity), new RelationPredicateBucket(RoleAuditActionFields.RoleID == roleID));

					// THEN save all new entities
					adapter.SaveEntityCollection(roleAuditActions);

					// succeeded, commit transaction
					adapter.Commit();
					return true;
				}
				catch
				{
					// failed, rollback transaction
					adapter.Rollback();
					throw;
				}
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
			var forumRightsPerRole = new EntityCollection<ForumRoleForumActionRightEntity>();
			foreach(int actionRightID in actionRightIDs)
			{
				var newForumRightPerRole = new ForumRoleForumActionRightEntity
										   {
											   ActionRightID = actionRightID,
											   ForumID = forumID,
											   RoleID = roleID
										   };
				forumRightsPerRole.Add(newForumRightPerRole);
			}
			using(var adapter = new DataAccessAdapter())
			{ 
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "SaveForumActionRights");
				try
				{
					// first remove the existing rows for the role. Do this by a query directly on the database.
					adapter.DeleteEntitiesDirectly(typeof(ForumRoleForumActionRightEntity), 
													new RelationPredicateBucket((ForumRoleForumActionRightFields.RoleID == roleID).And(ForumRoleForumActionRightFields.ForumID == forumID)));
					// then save the new entities
					adapter.SaveEntityCollection(forumRightsPerRole);
					// all done, commit transaction
					adapter.Commit();
					return true;
				}
				catch
				{
					// failed, rollback transaction
					adapter.Rollback();
					throw;
				}
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

			var roleUsers = new EntityCollection<RoleUserEntity>();
			// for each userid in the list, add a new entity to the collection
			foreach(int userID in userIDsToAdd)
			{
				var newRoleUser = new RoleUserEntity
								  {
									  UserID = userID,
									  RoleID = roleID
								  };
				roleUsers.Add(newRoleUser);
			}
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.SaveEntityCollection(roleUsers) > 0;
			}
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

			// we'll delete all role-user combinations for the users in the given range plus for the given role. We'll do that with a query directly onto the DB.
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.DeleteEntitiesDirectly(typeof(RoleUserEntity), new RelationPredicateBucket(RoleUserFields.UserID.In(userIDsToRemove).And(RoleUserFields.RoleID.Equal(roleID)))) > 0;
			}
		}


		/// <summary>
		/// Deletes the given role from the system.
		/// </summary>
		/// <param name="roleID">ID of role to delete</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool DeleteRole(int roleID)
		{
			var toDelete = SecurityGuiHelper.GetRole(roleID);
			if(toDelete == null)
			{
				// not found
				return false;
			}

			using(var adapter = new DataAccessAdapter())
			{ 
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "DeleteRole");
				try
				{
					// remove the role - forum - action right entities
					adapter.DeleteEntitiesDirectly(typeof(ForumRoleForumActionRightEntity), new RelationPredicateBucket(ForumRoleForumActionRightFields.RoleID == roleID));
					// Remove role-audit action entities
					adapter.DeleteEntitiesDirectly(typeof(RoleAuditActionEntity), new RelationPredicateBucket(RoleAuditActionFields.RoleID == roleID));
					// remove Role - systemright entities
					adapter.DeleteEntitiesDirectly(typeof(RoleSystemActionRightEntity), new RelationPredicateBucket(RoleSystemActionRightFields.RoleID == roleID));
					// remove Role - user entities
					adapter.DeleteEntitiesDirectly(typeof(RoleUserEntity), new RelationPredicateBucket(RoleUserFields.RoleID == roleID));
					// delete the actual role
					adapter.DeleteEntity(toDelete);
					adapter.Commit();
					return true;
				}
				catch
				{
					// error occured, rollback
					adapter.Rollback();
					throw;
				}
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
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).User.Any(u=>u.NickName == nickName);
			}
		}


		/// <summary>
		/// Checks if the user with the given UserID exists in the database.
		/// </summary>
		/// <param name="userID">The UserID of the user to check if he/she exists in the database</param>
		/// <returns>true if user exists, false otherwise. </returns>
		public static bool DoesUserExist(int userID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).User.Any(u => u.UserID == userID);
			}
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
	        var qf = new QueryFactory();
	        var q = qf.User.Where(UserFields.NickName.Equal(nickName));
	        using(var adapter = new DataAccessAdapter())
	        {
		        user = adapter.FetchFirst(q) ?? new UserEntity();
		        return user.Fields.State==EntityState.Fetched;
	        }
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
			var qf = new QueryFactory();
			// fetch the Roles related to the user when fetching the user, using a prefetchPath object.
			var q = qf.User.Where(UserFields.NickName.Equal(nickName))
					       .WithPath(UserEntity.PrefetchPathRoles);
			using(var adapter = new DataAccessAdapter())
			{
				user = adapter.FetchFirst(q) ?? new UserEntity();
				bool fetchResult = user.Fields.State == EntityState.Fetched;

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

#warning ADJUST FOR #4
				// check password and UserID. We disallow the user with id 0 to login as that's the anonymous coward ID for a user not logged in.
				string md5HashedPassword = HnDGeneralUtils.CreateMD5HashedBase64String(password);
				if((md5HashedPassword == user.Password) && (user.UserID != Globals.UserIDToDenyLogin))
				{
					// correct username/password combination
					return AuthenticateResult.AllOk;
				}
				// something was wrong, report wrong authentication combination
				return AuthenticateResult.WrongUsernamePassword;
			}
		}


		/// <summary>
		/// Checks if the specified role description is already present.
		/// </summary>
		/// <param name="roleDescription">The role description.</param>
		/// <returns>true if the role description is already present, otherwise false.</returns>
		private static bool CheckIfRoleDescriptionIsPresent(string roleDescription)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Role.Any(r=>r.RoleDescription == roleDescription);
			}
		}
	}
}
