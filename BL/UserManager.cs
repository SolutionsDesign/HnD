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
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using SD.HnD.Utility;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using System.Web;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace SD.HnD.BL
{
	/// <summary>
	/// General class for Usermanagement related tasks
	/// </summary>
	public static class UserManager
	{
		/// <summary>
		/// Adds the thread to bookmarks.
		/// </summary>
		/// <param name="threadId">Thread ID.</param>
		/// <param name="userId">User ID.</param>
		/// <returns>true if save succeeded, false otherwise</returns>
		public static async Task<bool> AddThreadToBookmarksAsync(int threadId, int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.SaveEntityAsync(new BookmarkEntity {UserID = userId, ThreadID = threadId}).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Unsubscribes the specified user from the specified thread. 
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="userId">The user ID.</param>
		/// <returns>true if delete succeeded, false otherwise</returns>
		public static async Task<bool> RemoveSingleSubscriptionAsync(int threadId, int userId)
		{
			var subscription = await ThreadGuiHelper.GetThreadSubscriptionAsync(threadId, userId);
			if(subscription != null)
			{
				// there's a subscription, delete it
				using(var adapter = new DataAccessAdapter())
				{
					return await adapter.DeleteEntityAsync(subscription).ConfigureAwait(false);
				}
			}

			return true;
		}


		/// <summary>
		/// Subscribes the user specified to the thread specified for notifications. A transaction can be specified to save the information inside the
		/// transaction specified. If the user is already subscribed to this thread, nothing is done
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="userId">The user ID.</param>
		/// <param name="adapter">The live adapter with an active transaction. Can be null, in which case a local adapter is used.</param>
		/// <returns></returns>
		public static async Task<bool> AddThreadToSubscriptionsAsync(int threadId, int userId, IDataAccessAdapter adapter)
		{
			var localAdapter = adapter == null;
			var adapterToUse = adapter ?? new DataAccessAdapter();
			try
			{
				// check if this user is already subscribed to this thread. If not, add a new subscription.
				if(await ThreadGuiHelper.GetThreadSubscriptionAsync(threadId, userId, adapterToUse) == null)
				{
					// user isn't yet subscribed, add the subscription
					return await adapterToUse.SaveEntityAsync(new ThreadSubscriptionEntity {UserID = userId, ThreadID = threadId}).ConfigureAwait(false);
				}

				// already subscribed, no-op.
				return true;
			}
			finally
			{
				if(localAdapter)
				{
					adapterToUse.Dispose();
				}
			}
		}


		/// <summary>
		/// Updates the last visit date for user.
		/// </summary>
		/// <param name="userId">The user ID of the user to update the date for.</param>
		public static async Task UpdateLastVisitDateForUserAsync(int userId)
		{
			var user = await UserGuiHelper.GetUserAsync(userId);
			if(user == null)
			{
				// not found
				return;
			}

			user.LastVisitedDate = DateTime.Now;
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.SaveEntityAsync(user).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Toggles the ban flag value.
		/// </summary>
		/// <param name="userId">The user ID of the user to toggle the ban flag.</param>
		/// <returns>Tuple with two boolean flags. First value is toggle result, Second value is the new banflag value.
		/// true if toggle was succesful, false otherwise
		/// </returns>
		public static async Task<(bool toggleResult, bool newBanFlagValue)> ToggleBanFlagValueAsync(int userId)
		{
			var user = await UserGuiHelper.GetUserAsync(userId);
			if(user == null)
			{
				return (false, false);
			}

			var newBanFlagValue = !user.IsBanned;
			user.IsBanned = newBanFlagValue;
			using(var adapter = new DataAccessAdapter())
			{
				var saveResult = await adapter.SaveEntityAsync(user).ConfigureAwait(false);
				return (saveResult, newBanFlagValue);
			}
		}


		/// <summary>
		/// Deletes the user with the ID passed in. Will reset all posts made by the user to the userid 0. 
		/// </summary>
		/// <param name="userId">The user ID.</param>
		/// <remarks>Can't delete user 0</remarks>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> DeleteUserAsync(int userId)
		{
			if(userId <= 1)
			{
				// can't delete the Anonymous user nor the admin user 
				return false;
			}

			var toDelete = await UserGuiHelper.GetUserAsync(userId);
			if(toDelete == null)
			{
				// user doesn't exist
				return false;
			}

			if(toDelete.NickName == "Admin")
			{
				// can't delete admin
				return false;
			}

			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "DeleteUser").ConfigureAwait(false);
				try
				{
					// we'll first update all PostedByUserId fields of all messages which are posted by the user to delete. 
					var messageUpdater = new MessageEntity {PostedByUserID = 0};

					// reset to AC.
					await adapter.UpdateEntitiesDirectlyAsync(messageUpdater, new RelationPredicateBucket(MessageFields.PostedByUserID.Equal(userId)))
								 .ConfigureAwait(false);

					// set the startuser of threads started by this user to 0
					var threadUpdater = new ThreadEntity {StartedByUserID = 0};
					await adapter.UpdateEntitiesDirectlyAsync(threadUpdater, new RelationPredicateBucket(ThreadFields.StartedByUserID.Equal(userId)))
								 .ConfigureAwait(false);

					// remove the user from the UserRoles set, as the user shouldn't be in any roles. 
					await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleUserEntity), new RelationPredicateBucket(RoleUserFields.UserID.Equal(userId)))
								 .ConfigureAwait(false);

					// delete all bookmarks of user
					await adapter.DeleteEntitiesDirectlyAsync(typeof(BookmarkEntity), new RelationPredicateBucket(BookmarkFields.UserID.Equal(userId)))
								 .ConfigureAwait(false);

					// delete all audit data
					// first fetch it, then delete all entities from the collection, as the audit data is in an inheritance hierarchy of TargetPerEntity which can't
					// be deleted directly from the db.
					var auditData = await adapter.FetchQueryAsync(new QueryFactory().User.Where(UserFields.UserID.Equal(userId))).ConfigureAwait(false);
					await adapter.DeleteEntityCollectionAsync(auditData).ConfigureAwait(false);

					// set IP bans set by this user to userid 0
					var ipbanUpdater = new IPBanEntity {IPBanSetByUserID = 0};
					await adapter.UpdateEntitiesDirectlyAsync(ipbanUpdater, new RelationPredicateBucket(IPBanFields.IPBanSetByUserID.Equal(userId)))
								 .ConfigureAwait(false);

					// delete threadsubscriptions
					await adapter.DeleteEntitiesDirectlyAsync(typeof(ThreadSubscriptionEntity), new RelationPredicateBucket(ThreadSubscriptionFields.UserID.Equal(userId)))
								 .ConfigureAwait(false);

					// remove supportqueuethread claims
					await adapter.DeleteEntitiesDirectlyAsync(typeof(SupportQueueThreadEntity),
															  new RelationPredicateBucket(SupportQueueThreadFields.ClaimedByUserID.Equal(userId)))
								 .ConfigureAwait(false);

					// set all placed in queue references to userid 0, so the threads stay in the queues.
					var supportQueueThreadUpdater = new SupportQueueThreadEntity {PlacedInQueueByUserID = 0};
					await adapter.UpdateEntitiesDirectlyAsync(supportQueueThreadUpdater,
															  new RelationPredicateBucket(SupportQueueThreadFields.PlacedInQueueByUserID.Equal(userId)))
								 .ConfigureAwait(false);

					// now delete the actual user entity
					await adapter.DeleteEntityAsync(toDelete).ConfigureAwait(false);
					adapter.Commit();
					return true;
				}
				catch
				{
					adapter.Rollback();
					throw;
				}
			}
		}


		/// <summary>
		/// Removes the threads with threadid in the arraylist passed in from the bookmarks
		/// </summary>
		/// <param name="threadIdsToRemove">Thread I ds to remove.</param>
		/// <param name="userId">user for whom these bookmarks have to be deleted</param>
		public static async Task RemoveBookmarksAsync(IEnumerable<int> threadIdsToRemove, int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.DeleteEntitiesDirectlyAsync(typeof(BookmarkEntity),
														  new RelationPredicateBucket(BookmarkFields.ThreadID.In(threadIdsToRemove)
																									.And(BookmarkFields.UserID.Equal(userId))))
							 .ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Removes the single bookmark passed in
		/// </summary>
		/// <param name="threadId">Thread ID.</param>
		/// <param name="userId">User ID.</param>
		/// <returns></returns>
		public static async Task RemoveSingleBookmarkAsync(int threadId, int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				await adapter.DeleteEntitiesDirectlyAsync(typeof(BookmarkEntity),
														  new RelationPredicateBucket((BookmarkFields.ThreadID.Equal(threadId)).And(BookmarkFields.UserID.Equal(userId))))
							 .ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Emails to the user with the nickname specified a unique link which allows the user to reset their password
		/// </summary>
		/// <param name="nickName">Nickname of user which password should be reset</param>
		/// <param name="emailData">The email data.</param>
		/// <returns>true if succeed, false otherwise</returns>
		public static async Task<bool> EmailPasswordResetLink(string nickName, Dictionary<string, string> emailData)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().User.Where(UserFields.NickName.Equal(nickName)).WithPath(UserEntity.PrefetchPathPasswordResetToken);
				var user = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				if(user == null)
				{
					// not found
					return false;
				}

				if(user.PasswordResetToken == null)
				{
					user.PasswordResetToken = new PasswordResetTokenEntity();
				}

				user.PasswordResetToken.PasswordResetToken = Guid.NewGuid();
				user.PasswordResetToken.PasswordResetRequestedOn = DateTime.Now;

				// first persist the token
				var result = await adapter.SaveEntityAsync(user, refetchAfterSave: true).ConfigureAwait(false);
				if(!result)
				{
					return false;
				}

				// then email an email to the user with the link to reset the password.
				// use template to construct message to send. 
				var emailTemplate = emailData.GetValue("emailTemplate") ?? string.Empty;
				var mailBody = SD.HnD.Utility.StringBuilderCache.Acquire(emailTemplate.Length + 256);
				mailBody.Append(emailTemplate);
				var applicationURL = emailData.GetValue("applicationURL") ?? string.Empty;
				var siteName = emailData.GetValue("siteName") ?? string.Empty;
				if(!string.IsNullOrEmpty(emailTemplate))
				{
					// Use the existing template to format the body
					mailBody.Replace("[URL]", applicationURL);
					mailBody.Replace("[SiteName]", siteName);
					mailBody.Replace("[Token]", user.PasswordResetToken.PasswordResetToken.ToString());
				}

				// format the subject
				var subject = (emailData.GetValue("passwordResetRequestSubject") ?? string.Empty) + siteName;
				var fromAddress = emailData.GetValue("defaultFromEmailAddress") ?? string.Empty;

				try
				{
					//send message
					result = await HnDGeneralUtils.SendEmail(subject, SD.HnD.Utility.StringBuilderCache.GetStringAndRelease(mailBody), fromAddress,
															 new[] {user.EmailAddress}, emailData)
												  .ConfigureAwait(false);
				}
				catch(SmtpFailedRecipientsException)
				{
					// swallow as it shouldn't have any effect on further operations
				}
				catch(SmtpException)
				{
					// swallow, as there's nothing we can do
				}

				// rest: problematic, so bubble upwards.
				return result;
			}
		}


		/// <summary>
		/// Updates the given user's profile data using the values of the properties of this class.
		/// </summary>
		/// <param name="userId">The user ID.</param>
		/// <param name="dateOfBirth">The date of birth.</param>
		/// <param name="emailAddress">The email address.</param>
		/// <param name="emailAddressIsPublic">flag to signal if the emailaddress is visible for everyone or not</param>
		/// <param name="iconUrl">The icon URL.</param>
		/// <param name="location">The location.</param>
		/// <param name="occupation">The occupation.</param>
		/// <param name="password">The password.</param>
		/// <param name="signature">The signature.</param>
		/// <param name="website">The website.</param>
		/// <param name="userTitleId">The user title ID.</param>
		/// <param name="autoSubscribeThreads">Default value when user creates new threads.</param>
		/// <param name="defaultMessagesPerPage">Messages per page to display</param>
		/// <param name="isBanned">flag whether the user is banned or not. Can be null, in which case the value is left untouched</param>
		/// <param name="roleIds">The RoleIDs of the roles the user is in. Can be null, in which case no roles are updated</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> UpdateUserProfileAsync(int userId, DateTime? dateOfBirth, string emailAddress, bool emailAddressIsPublic, string iconUrl,
															  string location, string occupation, string password, string signature, string website, int userTitleId,
															  bool autoSubscribeThreads, short defaultMessagesPerPage, bool? isBanned = null, List<int> roleIds = null)
		{
			var user = await UserGuiHelper.GetUserAsync(userId);
			if(user == null)
			{
				// not found
				return false;
			}

			user.DateOfBirth = dateOfBirth;
			user.EmailAddress = emailAddress;
			user.EmailAddressIsPublic = emailAddressIsPublic;
			user.IconURL = iconUrl;
			user.Location = location;
			user.Occupation = occupation;
			user.UserTitleID = userTitleId;
			if(isBanned.HasValue)
			{
				user.IsBanned = isBanned.Value;
			}

			if(!string.IsNullOrWhiteSpace(password))
			{
				user.Password = HnDGeneralUtils.HashPassword(password, performPreMD5Hashing: true);
			}

			user.Signature = signature;
			user.Website = website;

			//Preferences
			user.AutoSubscribeToThread = autoSubscribeThreads;
			user.DefaultNumberOfMessagesPerPage = defaultMessagesPerPage;

			// first encode fields which could lead to cross-site-scripting attacks
			EncodeUserTextFields(user);

			if(roleIds != null)
			{
				// Add new entities for the user for all roleid's in the list specified. We'll first delete the ones the user is already in below directly
				foreach(var roleId in roleIds)
				{
					user.RoleUser.Add(new RoleUserEntity() {RoleID = roleId});
				}
			}

			using(var adapter = new DataAccessAdapter())
			{
				await adapter.StartTransactionAsync(IsolationLevel.ReadCommitted, "Update User Info").ConfigureAwait(false);
				try
				{
					if(roleIds != null)
					{
						// first remove the user from all roles, we'll do that directly.
						await adapter.DeleteEntitiesDirectlyAsync(typeof(RoleUserEntity),
																  new RelationPredicateBucket(RoleUserFields.UserID.Equal(userId)))
									 .ConfigureAwait(false);
					}

					// then save everything in one go.
					var toReturn = await adapter.SaveEntityAsync(user).ConfigureAwait(false);
					adapter.Commit();
					return toReturn;
				}
				catch
				{
					adapter.Rollback();
					throw;
				}
			}
		}


		/// <summary>
		/// Registers a new user, using the properties of this class.
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		/// <param name="dateOfBirth">The date of birth.</param>
		/// <param name="emailAddress">The email address.</param>
		/// <param name="emailAddressIsPublic">flag to signal if the emailaddress is visible for everyone or not</param>
		/// <param name="iconUrl">The icon URL.</param>
		/// <param name="ipNumber">The ip number.</param>
		/// <param name="location">The location.</param>
		/// <param name="occupation">The occupation.</param>
		/// <param name="signature">The signature.</param>
		/// <param name="website">The website.</param>
		/// <param name="emailData">The email data.</param>
		/// <param name="autoSubscribeThreads">Default value when user creates new threads.</param>
		/// <param name="defaultMessagesPerPage">Messages per page to display</param>
		/// <returns>
		/// UserID of new user or 0 if registration failed.
		/// </returns>
		public static async Task<int> RegisterNewUserAsync(string nickName, DateTime? dateOfBirth, string emailAddress, bool emailAddressIsPublic, string iconUrl,
														   string ipNumber, string location, string occupation, string signature, string website,
														   Dictionary<string, string> emailData, bool autoSubscribeThreads, short defaultMessagesPerPage)
		{
			var newUser = new UserEntity
						  {
							  AmountOfPostings = 0,
							  DateOfBirth = dateOfBirth,
							  EmailAddress = emailAddress,
							  EmailAddressIsPublic = emailAddressIsPublic,
							  IPNumber = ipNumber,
							  IconURL = iconUrl,
							  IsBanned = false,
							  JoinDate = DateTime.Now,
							  Location = location,
							  NickName = nickName,
							  Occupation = occupation,
							  Signature = signature,
							  Website = website
						  };

			var password = HnDGeneralUtils.GenerateRandomPassword();
			newUser.Password = HnDGeneralUtils.HashPassword(password, performPreMD5Hashing: true);

			//Preferences
			newUser.AutoSubscribeToThread = autoSubscribeThreads;
			newUser.DefaultNumberOfMessagesPerPage = defaultMessagesPerPage;

			//Fetch the SystemDataEntity to use the "DefaultUserTitleNewUser" as the user title & the "DefaultRoleNewUser" as the roleID of the newly
			//created RoleUserEntity.
			var systemData = await SystemGuiHelper.GetSystemSettingsAsync();
			newUser.UserTitleID = systemData.DefaultUserTitleNewUser;
			newUser.RoleUser.Add(new RoleUserEntity {RoleID = systemData.DefaultRoleNewUser});

			// first encode fields which could lead to cross-site-scripting attacks
			EncodeUserTextFields(newUser);

			// now save the new user entity and the new RoleUser entity recursively in one go. 
			using(var adapter = new DataAccessAdapter())
			{
				if(await adapter.SaveEntityAsync(newUser).ConfigureAwait(false))
				{
					// all ok, Email the password
					await HnDGeneralUtils.EmailPassword(password, emailAddress, emailData);
				}
			}

			return newUser.UserID;
		}


		/// <summary>
		/// Resets the password for the user related to the password token specified to the newPassword specified
		/// It'll then remove the password reset token entity specified
		/// </summary>
		/// <param name="newPassword">the new password specified</param>
		/// <param name="passwordResetToken">the reset token. Will be removed in this method if password reset is successful</param>
		/// <returns>true if successful, false otherwise</returns>
		public static async Task<bool> ResetPasswordAsync(string newPassword, PasswordResetTokenEntity passwordResetToken)
		{
			if(string.IsNullOrWhiteSpace(newPassword) || passwordResetToken == null)
			{
				return false;
			}

			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().User.Where(UserFields.UserID.Equal(passwordResetToken.UserID));
				var user = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				if(user == null)
				{
					return false;
				}

				user.Password = HnDGeneralUtils.HashPassword(newPassword, performPreMD5Hashing: true);
				var uow = new UnitOfWork2();
				uow.AddForSave(user);
				uow.AddForDelete(passwordResetToken);
				var toReturn = await uow.CommitAsync(adapter);
				return toReturn == 2;
			}
		}


		/// <summary>
		/// Encodes some of the user text fields in the passed in entity. Encoding is done here so the data is HtmlEncoded when it's saved into the database.
		/// This routine is used in code to store data. It's stored encoded so viewing logic isn't relying on the encoding code inside the page, which might be
		/// absent and which then would create a potential cross-site scripting error. 
		/// </summary>
		/// <param name="toEncode">To encode.</param>
		/// <remarks>Fields which are filled in by the user are encoded using HtmlEncoding. </remarks>
		private static void EncodeUserTextFields(UserEntity toEncode)
		{
			toEncode.EmailAddress = HttpUtility.HtmlEncode(toEncode.EmailAddress);
			toEncode.Occupation = HttpUtility.HtmlEncode(toEncode.Occupation);
			toEncode.Location = HttpUtility.HtmlEncode(toEncode.Location);
			toEncode.Website = HttpUtility.HtmlEncode(toEncode.Website);
			toEncode.IconURL = HttpUtility.HtmlEncode(toEncode.IconURL);
			toEncode.Signature = HttpUtility.HtmlEncode(toEncode.Signature);
		}
	}
}