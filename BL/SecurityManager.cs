/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
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
using SD.HnD.Utility;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.HelperClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.Linq;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
using SD.LLBLGen.Pro.LinqSupportClasses;
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
		public enum AuthenticateResult : int
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
		/// <param name="userId">User ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static async Task<bool> AuditLoginAsync(int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataCoreEntity
							{
								AuditActionID = (int)AuditActions.AuditLogin,
								UserID = userId,
								AuditedOn = DateTime.Now
							};
				var toReturn = await adapter.SaveEntityAsync(toLog).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Audits the creation of a new thread by the specified user
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="threadId">Thread ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static async Task<bool> AuditNewThreadAsync(int userId, int threadId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataThreadRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditNewThread,
								UserID = userId,
								AuditedOn = DateTime.Now,
								ThreadID = threadId
							};
				return await adapter.SaveEntityAsync(toLog).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Audits the edit of the memo field for a thread by the specified user
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="threadId">Thread ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static async Task<bool> AuditEditMemoAsync(int userId, int threadId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataThreadRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditEditMemo,
								UserID = userId,
								AuditedOn = DateTime.Now,
								ThreadID = threadId
							};
				return await adapter.SaveEntityAsync(toLog).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Audits the approval of an attachment. We'll log the approval of an attachment with the messageid, as attachments are stored related to a message.
		/// </summary>
		/// <param name="userId">The user ID.</param>
		/// <param name="attachmentId">The attachment ID.</param>
		public static async Task<bool> AuditApproveAttachmentAsync(int userId, int attachmentId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// use a scalar query to obtain the message id so we don't have to pull it completely in memory. An attachment can be big in size so we don't want to 
				// read the entity to just read the messageid. We could use excluding fields to avoid the actual attachment data, but this query is really simple.
				// this query will return 1 value directly from the DB, so it won't read all attachments first into memory.
				var q = new QueryFactory().Attachment.Where(AttachmentFields.AttachmentID.Equal(attachmentId)).Select(AttachmentFields.MessageID);
				var messageID = await adapter.FetchScalarAsync<int>(q);
				var toLog = new AuditDataMessageRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditApproveAttachment,
								UserID = userId,
								MessageID = messageID,
								AuditedOn = DateTime.Now
							};
				var toReturn = await adapter.SaveEntityAsync(toLog).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Audits the creation of a new message by the specified user
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="messageId">Message ID.</param>
		/// <returns>true if the save was successful, false otherwise</returns>
		public static async Task<bool> AuditNewMessageAsync(int userId, int messageId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataMessageRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditNewMessage,
								UserID = userId,
								AuditedOn = DateTime.Now,
								MessageID = messageId
							};
				return await adapter.SaveEntityAsync(toLog).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Audits the alternation of a message by the specified user
		/// </summary>
		/// <param name="userId">User ID.</param>
		/// <param name="messageId">Message ID.</param>
		/// <returns></returns>
		public static async Task<bool> AuditAlteredMessageAsync(int userId, int messageId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var toLog = new AuditDataMessageRelatedEntity
							{
								AuditActionID = (int)AuditActions.AuditAlteredMessage,
								UserID = userId,
								AuditedOn = DateTime.Now,
								MessageID = messageId
							};
				return await adapter.SaveEntityAsync(toLog).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Adds the given IPBan
		/// </summary>
		/// <param name="toAdd">the dto containing the values to add as a new entity</param>
		/// <returns>the ID of the new IPBan, or 0 if it failed</returns>
		public static async Task<int> AddNewIPBanAsync(IPBanDto toAdd)
		{
			if(toAdd == null)
			{
				return 0;
			}

			var toInsert = new IPBanEntity()
						   {
							   IPSegment1 = toAdd.IPSegment1,
							   IPSegment2 = toAdd.IPSegment2,
							   IPSegment3 = toAdd.IPSegment3,
							   IPSegment4 = toAdd.IPSegment4,
							   Range = toAdd.Range,
							   Reason = toAdd.Reason,
							   IPBanSetByUserID = toAdd.IPBanSetByUserID
						   };
			using(var adapter = new DataAccessAdapter())
			{
				var result = await adapter.SaveEntityAsync(toInsert).ConfigureAwait(false);
				return result ? toInsert.IPBanID : 0;
			}
		}


		/// <summary>
		/// Modifies the given IPBan
		/// </summary>
		/// <param name="toUpdate">the dto containing the values to update the associated entity with</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> ModifyIPBanAsync(IPBanDto toUpdate)
		{
			if(toUpdate == null)
			{
				return false;
			}

			var ipBan = await SecurityGuiHelper.GetIPBanAsync(toUpdate.IPBanID);
			if(ipBan == null)
			{
				return false;
			}

			ipBan.UpdateFromIPBan(toUpdate);
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.SaveEntityAsync(ipBan).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Deletes the ipban with the id specified 
		/// </summary>
		/// <param name="idToDelete">the id of the ip ban to delete</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> DeleteIPBanAsync(int idToDelete)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.DeleteEntitiesDirectlyAsync(typeof(IPBanEntity), new RelationPredicateBucket(IPBanFields.IPBanID.Equal(idToDelete)))
									.ConfigureAwait(false) > 0;
			}
		}


		/// <summary>
		/// Creates a new Role in the system. If the user specified a role description that is already available, the unique constraint violation will be 
		/// caught and 0 is returned in that case.
		/// </summary>
		/// <param name="roleDescription">Description to store</param>
		/// <param name="systemActionRightsSet">The id's of the action rights set for system rights for this new role</param>
		/// <param name="auditActionsSet">the ids of the audit actions set for the role</param>
		/// <returns>new RoleID if succeeded. If the description was already available, 0 is returned</returns>
		public static async Task<int> CreateNewRoleAsync(string roleDescription, List<int> systemActionRightsSet, List<int> auditActionsSet)
		{
			if(await CheckIfRoleDescriptionIsPresentAsync(roleDescription))
			{
				// is already present
				return 0;
			}

			using(var adapter = new DataAccessAdapter())
			{
				var newRole = new RoleEntity {RoleDescription = roleDescription};

				// we'll now create the intermediate entities for several m:n relationships. 
				foreach(var actionRightId in systemActionRightsSet)
				{
					// The roleid will be inserted in the recursive graph save below
					newRole.RoleSystemActionRights.Add(new RoleSystemActionRightEntity {ActionRightID = actionRightId});
				}

				foreach(var auditActionId in auditActionsSet)
				{
					// The roleid will be inserted in the recursive graph save below
					newRole.RoleAuditAction.Add(new RoleAuditActionEntity() {AuditActionID = auditActionId});
				}

				var toReturn = await adapter.SaveEntityAsync(newRole).ConfigureAwait(false);
				return toReturn ? newRole.RoleID : 0;
			}
		}


		/// <summary>
		/// Updates the role entity with the id specified, with the role description and system action rights set
		/// It resets the system action rights for the given role to the given set of action rights and it modifies
		/// the role description for the given role. If the user specified a role description that is already available, false will be returned to signal
		/// that the save failed.
		/// </summary>
		/// <param name="roleId">the id of the role</param>
		/// <param name="roleDescription">the new description of the role</param>
		/// <param name="systemActionRightsSet">the system action rights to assign to the role</param>
		/// <param name="auditActionsSet">the ids of the audit actions set for the role</param>
		/// <returns></returns>
		public static async Task<bool> ModifyRoleAsync(int roleId, string roleDescription, List<int> systemActionRightsSet, List<int> auditActionsSet)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Role.Where(RoleFields.RoleID.Equal(roleId));
				var role = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				if(role == null)
				{
					return false;
				}

				// check if the description is different. If so, we've to check if the new roledescription is already present. If so, we'll abort the save
				role.RoleDescription = roleDescription;
				if(role.Fields.GetIsChanged((int)RoleFieldIndex.RoleID))
				{
					if(await CheckIfRoleDescriptionIsPresentAsync(roleDescription))
					{
						// new description, is already present, fail
						return false;
					}
				}

				foreach(var actionRightId in systemActionRightsSet)
				{
					role.RoleSystemActionRights.Add(new RoleSystemActionRightEntity {ActionRightID = actionRightId});
				}

				foreach(var auditActionId in auditActionsSet)
				{
					role.RoleAuditAction.Add(new RoleAuditActionEntity() {AuditActionID = auditActionId});
				}

				// all set. We're going to delete all Role - SystemAction Rights combinations first, as we're going to re-insert them later on. 
				// We'll use a transaction to be able to roll back all our changes if something fails. 
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "ModifyRole").ConfigureAwait(false);
				try
				{
					await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleSystemActionRightEntity),
															  new RelationPredicateBucket(RoleSystemActionRightFields.RoleID.Equal(roleId)));
					await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleAuditActionEntity), new RelationPredicateBucket(RoleAuditActionFields.RoleID.Equal(roleId)));
					await adapter.SaveEntityAsync(role).ConfigureAwait(false);

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
		/// Saves the given set of actionrights as the set of forum action rights for the given forum / role combination.
		/// It first removes all current action rights for that combination.
		/// </summary>
		/// <param name="actionRightIDs">List of actionrights to set of this role</param>
		/// <param name="roleId">Role to use</param>
		/// <param name="forumId">Forum to use</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> SaveForumActionRightsForForumRoleAsync(List<int> actionRightIDs, int roleId, int forumId)
		{
			var forumRightsPerRole = new EntityCollection<ForumRoleForumActionRightEntity>();
			foreach(var actionRightId in actionRightIDs)
			{
				var newForumRightPerRole = new ForumRoleForumActionRightEntity
										   {
											   ActionRightID = actionRightId,
											   ForumID = forumId,
											   RoleID = roleId
										   };
				forumRightsPerRole.Add(newForumRightPerRole);
			}

			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "SaveForumActionRights").ConfigureAwait(false);
				try
				{
					// first remove the existing rows for the role. Do this by a query directly on the database.
					await adapter.DeleteEntitiesDirectlyAsync(typeof(ForumRoleForumActionRightEntity),
															  new RelationPredicateBucket((ForumRoleForumActionRightFields.RoleID.Equal(roleId))
																						  .And(ForumRoleForumActionRightFields.ForumID.Equal(forumId))))
								 .ConfigureAwait(false);

					// then save the new entities
					await adapter.SaveEntityCollectionAsync(forumRightsPerRole).ConfigureAwait(false);

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
		/// <param name="roleId">ID of role the users will be added to</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> AddUsersToRoleAsync(List<int> userIDsToAdd, int roleId)
		{
			if(userIDsToAdd.Count <= 0)
			{
				return true;
			}

			var roleUsers = new EntityCollection<RoleUserEntity>();

			// for each userid in the list, add a new entity to the collection
			foreach(var userId in userIDsToAdd)
			{
				roleUsers.Add(new RoleUserEntity {UserID = userId, RoleID = roleId});
			}

			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.SaveEntityCollectionAsync(roleUsers).ConfigureAwait(false) > 0;
			}
		}


		/// <summary>
		/// Removes the user with the userid specified from the role with ID RoleID.
		/// </summary>
		/// <param name="userId">userid of user to remove from the role with roleid specified</param>
		/// <param name="roleId">ID of role the users will be removed from</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> RemoveUserFromRoleAsync(int roleId, int userId)
		{
			if(userId <= 0)
			{
				return false;
			}

			// we'll delete the role-user combination for the user plus for the given role with a query directly onto the DB.
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleUserEntity),
																 new RelationPredicateBucket(RoleUserFields.UserID.Equal(userId)
																										   .And(RoleUserFields.RoleID.Equal(roleId))))
									.ConfigureAwait(false) > 0;
			}
		}


		/// <summary>
		/// Deletes the given role from the system.
		/// </summary>
		/// <param name="roleId">ID of role to delete</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> DeleteRoleAsync(int roleId)
		{
			var toDelete = await SecurityGuiHelper.GetRoleAsync(roleId);
			if(toDelete == null)
			{
				// not found
				return false;
			}

			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "DeleteRole").ConfigureAwait(false);
				try
				{
					// remove the role - forum - action right entities
					await adapter.DeleteEntitiesDirectlyAsync(typeof(ForumRoleForumActionRightEntity),
															  new RelationPredicateBucket(ForumRoleForumActionRightFields.RoleID.Equal(roleId))).ConfigureAwait(false);

					// Remove role-audit action entities
					await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleAuditActionEntity),
															  new RelationPredicateBucket(RoleAuditActionFields.RoleID.Equal(roleId))).ConfigureAwait(false);
					;

					// remove Role - systemright entities
					await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleSystemActionRightEntity),
															  new RelationPredicateBucket(RoleSystemActionRightFields.RoleID.Equal(roleId))).ConfigureAwait(false);
					;

					// remove Role - user entities
					await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleUserEntity),
															  new RelationPredicateBucket(RoleUserFields.RoleID.Equal(roleId))).ConfigureAwait(false);
					;

					// delete the actual role
					await adapter.DeleteEntityAsync(toDelete).ConfigureAwait(false);
					;
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
		/// Authenticates the user with the given Nickname and the given Password.
		/// </summary>
		/// <param name="nickName">Nickname of the user</param>
		/// <param name="password">Password of the user</param>
		/// <returns>tuple with the authentication result and the user entity if authentication was successful.
		/// authentication result can be: AuthenticateResult.AllOk if the user could be authenticated, 
		///	AuthenticateResult.WrongUsernamePassword if user couldn't be authenticated given the current credentials,
		/// AuthenticateResult.IsBanned if the user is banned. </returns>
		public static async Task<(AuthenticateResult authenticateResult, UserEntity user)> AuthenticateUserAsync(string nickName, string password)
		{
			// fetch the Roles related to the user when fetching the user, using a prefetchPath object.
			var q = new QueryFactory().User.Where(UserFields.NickName.Equal(nickName))
									  .WithPath(UserEntity.PrefetchPathRoles);
			using(var adapter = new DataAccessAdapter())
			{
				var user = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				user = user ?? new UserEntity();
				var fetchResult = user.Fields.State == EntityState.Fetched;

				if(!fetchResult)
				{
					// not found. Simply return that the user has specified a wrong username/password combination. 
					return (AuthenticateResult.WrongUsernamePassword, user);
				}

				// user was found. If the user is banned we're done here
				if(user.IsBanned)
				{
					return (AuthenticateResult.IsBanned, user);
				}

				// check password and UserID. We disallow the user with id 0 to login as that's the anonymous coward ID for a user not logged in.
				if(user.UserID != Globals.UserIDToDenyLogin && HnDGeneralUtils.ComparePbkdf2HashedPassword(user.Password, password))
				{
					// correct username/password combination
					// delete any password reset tokens
					await adapter.DeleteEntitiesDirectlyAsync(typeof(PasswordResetTokenEntity),
															  new RelationPredicateBucket(PasswordResetTokenFields.UserID.Equal(user.UserID)))
								 .ConfigureAwait(false);

					// all ok
					return (AuthenticateResult.AllOk, user);
				}

				// something was wrong, report wrong authentication combination
				return (AuthenticateResult.WrongUsernamePassword, user);
			}
		}


		/// <summary>
		/// Checks if the specified role description is already present.
		/// </summary>
		/// <param name="roleDescription">The role description.</param>
		/// <returns>true if the role description is already present, otherwise false.</returns>
		private static async Task<bool> CheckIfRoleDescriptionIsPresentAsync(string roleDescription)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await new LinqMetaData(adapter).Role.AnyAsync(r => r.RoleDescription == roleDescription).ConfigureAwait(false);
			}
		}
	}
}