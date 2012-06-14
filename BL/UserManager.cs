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
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using SD.HnD.Utility;
using SD.HnD.DAL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.RelationClasses;
using SD.HnD.DAL.DaoClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Security.Cryptography;
using System.Web;
using SD.LLBLGen.Pro.QuerySpec;

namespace SD.HnD.BL
{
	/// <summary>
	/// Special exception which is thrown when a password reset action was executed but the nickname specified wasn't found.
	/// </summary>
	public class NickNameNotFoundException: System.ApplicationException
	{
		public NickNameNotFoundException(string sMessage):base(sMessage)
		{
		}
	}


	/// <summary>
	/// Special exception which is thrown when a password reset action was executed but the email specified doesn't match the nickname specified.
	/// </summary>
	public class EmailAddressDoesntMatchException: System.ApplicationException
	{
		public EmailAddressDoesntMatchException(string sMessage):base(sMessage)
		{
		}
	}


	/// <summary>
	/// General class for Usermanagement related tasks
	/// </summary>
	public static class UserManager
	{
		/// <summary>
		/// Adds the thread to bookmarks.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <param name="threadID">Thread ID.</param>
		/// <returns>true if save succeeded, false otherwise</returns>
		public static bool AddThreadToBookmarks(int userID, int threadID)
		{
			BookmarkEntity newBookmark = new BookmarkEntity();
			newBookmark.UserID = userID;
			newBookmark.ThreadID = threadID;
			return newBookmark.Save();
		}

		
		/// <summary>
		/// Unsubscribes the specified user from the specified thread. 
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="userID">The user ID.</param>
		/// <returns>true if delete succeeded, false otherwise</returns>
		public static bool RemoveSingleSubscription(int threadID, int userID)
		{
			ThreadSubscriptionEntity subscription = ThreadGuiHelper.GetThreadSubscription(threadID, userID);
			if(subscription != null)
			{
				// there's a subscription, delete it
				return subscription.Delete();
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// Subscribes the user specified to the thread specified for notifications. A transaction can be specified to save the information inside the
		/// transaction specified. If the user is already subscribed to this thread, nothing is done
		/// </summary>
		/// <param name="threadID">The thread ID.</param>
		/// <param name="userID">The user ID.</param>
		/// <param name="transactionToUse">The transaction to use. If no transaction is specified, no transaction is created</param>
		/// <returns></returns>
		public static bool AddThreadToSubscriptions(int threadID, int userID, Transaction transactionToUse)
		{
			// check if this user is already subscribed to this thread. If not, add a new subscription.
			ThreadSubscriptionEntity subscription = ThreadGuiHelper.GetThreadSubscription(threadID, userID, transactionToUse);
			if(subscription == null)
			{
				// user isn't yet subscribed, add the subscription
				subscription = new ThreadSubscriptionEntity();
				subscription.UserID = userID;
				subscription.ThreadID = threadID;
				if(transactionToUse != null)
				{
					transactionToUse.Add(subscription);
				}
				return subscription.Save();
			}
			// already subscribed, no-op.
			return true;
		}


		/// <summary>
		/// Updates the last visit date for user.
		/// </summary>
		/// <param name="userID">The user ID of the user to update the date for.</param>
		public static void UpdateLastVisitDateForUser(int userID)
		{
			UserEntity user = UserGuiHelper.GetUser(userID);
			if(user == null)
			{
				// not found
				return;
			}
			user.LastVisitedDate = DateTime.Now;
			user.Save();
			return;
		}


		/// <summary>
		/// Toggles the ban flag value.
		/// </summary>
		/// <param name="userID">The user ID of the user to toggle the ban flag.</param>
		/// <returns>true if toggle was succesful, false otherwise</returns>
		public static bool ToggleBanFlagValue(int userID, out bool newBanFlagValue)
		{
			newBanFlagValue = false;
			UserEntity user = UserGuiHelper.GetUser(userID);
			if(user == null)
			{
				return false;
			}

			newBanFlagValue = !user.IsBanned;
			user.IsBanned = newBanFlagValue;
			return user.Save();
		}


		/// <summary>
		/// Deletes the user with the ID passed in. Will reset all posts made by the user to the userid 0. 
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <remarks>Can't delete user 0</remarks>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool DeleteUser(int userID)
		{
			if(userID == 0)
			{
				// can't delete the Anonymous coward user. 
				return false;
			}

			UserEntity toDelete = UserGuiHelper.GetUser(userID);
			if(toDelete==null)
			{
				// user doesn't exist
				return false;
			}

			// all actions have to take place in a transaction.
			Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "DeleteUser");

			try
			{
				// we'll first update all PostedByUserId fields of all messages which are posted by the user to delete. 
				MessageEntity messageUpdater = new MessageEntity();
				messageUpdater.PostedByUserID = 0;	// reset to AC.
				MessageCollection messages = new MessageCollection();
				trans.Add(messages);	// add to the transaction
				// update all entities directly in the DB, which match the following filter and update them with the new values set in messageUpdater.
				messages.UpdateMulti(messageUpdater, (MessageFields.PostedByUserID == userID));
				
				// set the startuser of threads started by this user to 0
				ThreadEntity threadUpdater = new ThreadEntity();
				threadUpdater.StartedByUserID = 0;
				ThreadCollection threads = new ThreadCollection();
				trans.Add(threads);
				threads.UpdateMulti(threadUpdater, (ThreadFields.StartedByUserID == userID));

				// remove the user from the UserRoles set, as the user shouldn't be in any roles. 
				RoleUserCollection roleUsersDeleter = new RoleUserCollection();
				trans.Add(roleUsersDeleter);
				// delete all entities directly from the DB which match the following filter. 
				roleUsersDeleter.DeleteMulti(RoleUserFields.UserID == userID);

				// delete all bookmarks of user
				BookmarkCollection bookmarkDeleter = new BookmarkCollection();
				trans.Add(bookmarkDeleter);
				// delete all bookmarks for this user directly from the DB using the following filter. 
				bookmarkDeleter.DeleteMulti(BookmarkFields.UserID == userID);

				// delete all audit data
				AuditDataCoreCollection auditDataDeleter = new AuditDataCoreCollection();
				// first fetch it, then delete all entities from the collection, as the audit data is in an inheritance hierarchy of TargetPerEntity which can't
				// be deleted directly from the db.
				trans.Add(auditDataDeleter);
				auditDataDeleter.GetMulti(AuditDataCoreFields.UserID == userID);
				auditDataDeleter.DeleteMulti();

				// set IP bans set by this user to userid 0
				IPBanEntity ipbanUpdater = new IPBanEntity();
				ipbanUpdater.IPBanSetByUserID = 0;
				IPBanCollection ipBans = new IPBanCollection();
				trans.Add(ipBans);
				ipBans.UpdateMulti(ipbanUpdater, (IPBanFields.IPBanSetByUserID == userID));

				// delete threadsubscriptions
				ThreadSubscriptionCollection threadSubscriptionsDeleter = new ThreadSubscriptionCollection();
				trans.Add(threadSubscriptionsDeleter);
				threadSubscriptionsDeleter.DeleteMulti(ThreadSubscriptionFields.UserID == userID);

				// remove supportqueuethread claims
				SupportQueueThreadCollection supportQueueThreads = new SupportQueueThreadCollection();
				trans.Add(supportQueueThreads);
				supportQueueThreads.DeleteMulti(SupportQueueThreadFields.ClaimedByUserID == userID);

				// set all placed in queue references to userid 0, so the threads stay in the queues.
				SupportQueueThreadEntity supportQueueThreadUpdater = new SupportQueueThreadEntity();
				supportQueueThreadUpdater.PlacedInQueueByUserID=0;
				supportQueueThreads.UpdateMulti(supportQueueThreadUpdater, (SupportQueueThreadFields.PlacedInQueueByUserID == userID));

				// now delete the actual user entity
				trans.Add(toDelete);
				toDelete.Delete();

				// all done
				trans.Commit();
				return true;
			}
			catch
			{
				trans.Rollback();
				throw;
			}
			finally
			{
				trans.Dispose();
			}
		}


		/// <summary>
		/// Removes the threads with threadid in the arraylist passed in from the bookmarks
		/// </summary>
		/// <param name="threadIDsToRemove">Thread I ds to remove.</param>
		/// <param name="userID">user for whom these bookmarks have to be deleted</param>
		public static void RemoveBookmarks(ArrayList threadIDsToRemove, int userID)
		{
			BookmarkCollection bookmarks = new BookmarkCollection();
			// delete the bookmarks matching the filter directly from the database. 
			bookmarks.DeleteMulti((BookmarkFields.ThreadID == threadIDsToRemove).And(BookmarkFields.UserID == userID));
		}


		/// <summary>
		/// Removes the single bookmark passed in
		/// </summary>
		/// <param name="threadID">Thread ID.</param>
		/// <param name="userID">User ID.</param>
		/// <returns></returns>
		public static void RemoveSingleBookmark(int threadID, int userID)
		{
			BookmarkCollection bookmarks = new BookmarkCollection();
			// delete the bookmark directly from the database, no need for fetching it first.
			bookmarks.DeleteMulti((BookmarkFields.ThreadID == threadID).And(BookmarkFields.UserID == userID));
		}


		/// <summary>
		/// Resets the user's Password by generating a new random password which is mailed to
		/// the emailaddress specified. Will fail if the nickname doesn't exist or the emailaddress
		/// doesn't match with the specified emailaddress of the nickname in the database.
		/// </summary>
		/// <param name="nickName">Nickname of user which password should be reset</param>
		/// <param name="emailAddress">Emailaddress of user</param>
		/// <param name="emailTemplate">The email template.</param>
		/// <param name="emailData">The email data.</param>
		/// <returns>true if succeed, false otherwise</returns>
		/// <exception cref="NickNameNotFoundException">Throws NickNameNotFoundException when the nickname isn't found.</exception>
		/// <exception cref="EmailAddressDoesntMatchException">Throws EmailAddressDoesntMatchException when the emailaddress of the nickname isn't matching
		/// with the emailaddress specified.</exception>
		public static bool ResetPassword(string nickName, string emailAddress, string emailTemplate, Dictionary<string, string> emailData)
		{
			UserEntity user = new UserEntity();
			// fetch the user using the unique constraint fetch logic on nickname
			bool fetchResult = user.FetchUsingUCNickName(nickName);
			if(!fetchResult)
			{
				// not found
				throw new NickNameNotFoundException("Nickname: '" + nickName + "' not found");
			}

			// check emailaddress
			if(user.EmailAddress.ToLowerInvariant() != emailAddress.ToLowerInvariant())
			{
				// no match
				throw new EmailAddressDoesntMatchException("Emailaddress '" + emailAddress + "' doesn't match.");
			}

			// does match, reset the password
			string newPassword = HnDGeneralUtils.GenerateRandomPassword();

			// hash the password with an MD5 hash and store that hashed value into the database.
			user.Password = HnDGeneralUtils.CreateMD5HashedBase64String(newPassword);

			// store it
			bool result = user.Save();
			if(result)
			{
				// mail it
				result = HnDGeneralUtils.EmailPassword(newPassword, emailAddress, emailTemplate, emailData);
			}
				
			//done
			return result;
		}


		/// <summary>
		/// Updates the given user's profile data using the values of the properties of this class.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="dateOfBirth">The date of birth.</param>
		/// <param name="emailAddress">The email address.</param>
		/// <param name="emailAddressIsPublic">flag to signal if the emailaddress is visible for everyone or not</param>
		/// <param name="iconURL">The icon URL.</param>
		/// <param name="location">The location.</param>
		/// <param name="occupation">The occupation.</param>
		/// <param name="password">The password.</param>
		/// <param name="signature">The signature.</param>
		/// <param name="website">The website.</param>
		/// <param name="userTitleID">The user title ID.</param>
        /// <param name="parserData">The parser data.</param>
        /// <param name="autoSubscribeThreads">Default value when user creates new threads.</param>
        /// <param name="defaultMessagesPerPage">Messages per page to display</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool UpdateUserProfile(int userID, DateTime? dateOfBirth, string emailAddress, bool emailAddressIsPublic, string iconURL,
				string location, string occupation, string password, string signature, string website, int userTitleID, ParserData parserData,
                bool autoSubscribeThreads, short defaultMessagesPerPage)
		{
            UserEntity user = UserGuiHelper.GetUser(userID);
            if (user == null)
            {
                // not found
                return false;
            }

			user.DateOfBirth = dateOfBirth;
			user.EmailAddress = emailAddress;
			user.EmailAddressIsPublic = emailAddressIsPublic;
			user.IconURL = iconURL;
			user.Location = location;
			user.Occupation = occupation;
			user.UserTitleID = userTitleID;
		
			if(!string.IsNullOrEmpty(password))
			{
				user.Password = HnDGeneralUtils.CreateMD5HashedBase64String(password);
			}
			user.Signature = signature;
			if(!string.IsNullOrEmpty(signature))
			{
				user.SignatureAsHTML = TextParser.TransformSignatureUBBStringToHTML(signature, parserData);
			}
			else
			{
				user.SignatureAsHTML = "";
			}

			user.Website = website;

            //Preferences
            user.AutoSubscribeToThread = autoSubscribeThreads;
            user.DefaultNumberOfMessagesPerPage = defaultMessagesPerPage;

			// first encode fields which could lead to cross-site-scripting attacks
			EncodeUserTextFields(user);

			// Update the record
			return user.Save(true);
		}


		/// <summary>
		/// Registers a new user, using the properties of this class.
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		/// <param name="dateOfBirth">The date of birth.</param>
		/// <param name="emailAddress">The email address.</param>
		/// <param name="emailAddressIsPublic">flag to signal if the emailaddress is visible for everyone or not</param>
		/// <param name="iconURL">The icon URL.</param>
		/// <param name="ipNumber">The ip number.</param>
		/// <param name="location">The location.</param>
		/// <param name="occupation">The occupation.</param>
		/// <param name="signature">The signature.</param>
		/// <param name="website">The website.</param>
		/// <param name="emailTemplatePath">The email template path.</param>
		/// <param name="emailData">The email data.</param>
        /// <param name="autoSubscribeThreads">Default value when user creates new threads.</param>
        /// <param name="defaultMessagesPerPage">Messages per page to display</param>
        /// <returns>
		/// UserID of new user or 0 if registration failed.
		/// </returns>
		public static int RegisterNewUser(string nickName, DateTime? dateOfBirth, string emailAddress, bool emailAddressIsPublic, string iconURL,
				string ipNumber, string location, string occupation, string signature, string website, string emailTemplatePath, Dictionary<string, string> emailData, ParserData parserData,
                bool autoSubscribeThreads, short defaultMessagesPerPage)
		{
			UserEntity newUser = new UserEntity();

			// initialize objects
			newUser.AmountOfPostings = 0;
			newUser.DateOfBirth = dateOfBirth;
			newUser.EmailAddress = emailAddress;
			newUser.EmailAddressIsPublic = emailAddressIsPublic;
			newUser.IPNumber = ipNumber;
			newUser.IconURL = iconURL;
			newUser.IsBanned = false;
			newUser.JoinDate = DateTime.Now;
			newUser.Location = location;
			newUser.NickName = nickName;
			newUser.Occupation = occupation;			
			newUser.Signature = signature;
            newUser.Website = website;
            string password = HnDGeneralUtils.GenerateRandomPassword();
            newUser.Password = HnDGeneralUtils.CreateMD5HashedBase64String(password);

            //Preferences
            newUser.AutoSubscribeToThread = autoSubscribeThreads;
            newUser.DefaultNumberOfMessagesPerPage = defaultMessagesPerPage;

			if(!string.IsNullOrEmpty(signature))
			{
				newUser.SignatureAsHTML = TextParser.TransformSignatureUBBStringToHTML(signature, parserData);
			}
			else
			{
				newUser.SignatureAsHTML = "";
			}
            //Fetch the SystemDataEntity to use the "DefaultUserTitleNewUser" as the user title & the "DefaultRoleNewUser"
            // as the roleID of the newly created RoleUserEntity.
            SystemDataEntity systemData = SystemGuiHelper.GetSystemSettings();
            newUser.UserTitleID = systemData.DefaultUserTitleNewUser;

			RoleUserEntity roleUser = new RoleUserEntity();
			roleUser.RoleID = systemData.DefaultRoleNewUser;
			roleUser.User = newUser;

			// first encode fields which could lead to cross-site-scripting attacks
			EncodeUserTextFields(newUser);

			// now save the new user entity and the new RoleUser entity recursively in one go. This will create a transaction for us
			// under the hood so we don't have to do that ourselves. 
            if (newUser.Save(true))
            {
                // all ok, Email the password
				bool result = HnDGeneralUtils.EmailPassword(password, emailAddress, emailTemplatePath, emailData);

            }

			return newUser.UserID;
		}


		/// <summary>
		/// Encodes some of the user text fields in the passed in entity. Encoding is done here so the data is HtmlEncoded when it's saved into the database.
		/// This routine is used in code to store data. It's stored encoded so viewing logic isn't relying on the encoding code inside the page, which might be
		/// absent and which then would create a potential cross-site scripting error. 
		/// </summary>
		/// <param name="toEncode">To encode.</param>
		/// <remarks>Fields which are filled in by the user are encoded using HtmlEncoding. The signature is parsed by the UBB parser and therefore already 
		/// is free from potential scripting code as tag markers are already converted to html encoded characters. </remarks>
		private static void EncodeUserTextFields(UserEntity toEncode)
		{
			toEncode.EmailAddress = HttpUtility.HtmlEncode(toEncode.EmailAddress);
			toEncode.Occupation = HttpUtility.HtmlEncode(toEncode.Occupation);
			toEncode.Location = HttpUtility.HtmlEncode(toEncode.Location);
			toEncode.Website = HttpUtility.HtmlEncode(toEncode.Website);
			toEncode.IconURL = HttpUtility.HtmlEncode(toEncode.IconURL);
		}
	}
}
