/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	http:s//www.sd.nl

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
using SD.HnD.BL;
using System.Linq;
using System.Collections.Generic;
using SD.HnD.Gui.Classes;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui
{
	/// <summary>
	/// ApplicationAdapter is used to access Application-wide variables stored in the HnDConfiguration.
	/// </summary>
	/// <remarks>
	/// In previous versions this class wrapped access to the HttpApplication object, however in ASP.NET Core this object is no longer present.
	/// To avoid refactoring a lot of code, this class is kept as a central access point to global configuration data and instead
	/// of reading/writing into HttpApplication, it's using HnDConfiguration.Current instead.
	/// </remarks> 
	public static class ApplicationAdapter
	{
		/// <summary>
		/// Gets the max amount messages per page.
		/// </summary>
		/// <returns>maxAmountMessagesPerPage if available, otherwise 25</returns>
		public static int GetMaxAmountMessagesPerPage()
		{
			return HnDConfiguration.Current.MaxAmountMessagesPerPage;
		}


		/// <summary>
		/// Gets the name of the site.
		/// </summary>
		/// <returns>siteName if available, otherwise an empty string</returns>
		public static string GetSiteName()
		{
			return HnDConfiguration.Current.SiteName;
		}


		/// <summary>
		/// Gets the virtual root.
		/// </summary>
		/// <returns>virtualRoot if available, otherwise an empty string</returns>
		public static string GetVirtualRoot()
		{
			return HnDConfiguration.Current.VirtualRoot;
		}


		/// <summary>
		/// Gets the maximum number of minutes search results should be cached
		/// </summary>
		/// <returns></returns>
		public static int GetMaxNumberOfMinutesToCacheSearchResults()
		{
			return HnDConfiguration.Current.MaxNumberOfMinutesToCacheSearchResults;
		}


		/// <summary>
		/// Create a DTO of all needed e-mail default data.
		/// </summary>
		/// <param name="hostName">The name of the host, e.g. www.llblgen.com. Obtained from HttpContext.Request.Host.Host
		/// object in the controller ctor.</param>
		/// <param name="template">The template to add to the emailData. (optional</param>
		/// <returns>a dictionary of the following keys (defaultFromEmailAddress, defaultToEmailAddress, defaultSMTPServer, emailPassowrdSubject,
		/// siteName, applicationURL, smtpHost, smtpPort, smtpUserName, smtpPassword, smtpEnableSsl, emailTemplate)</returns>
		public static Dictionary<string, string> GetEmailData(string hostName, EmailTemplate template = EmailTemplate.Undefined)
		{
			Dictionary<string, string> emailData = new Dictionary<string, string>();
			emailData.Add("defaultFromEmailAddress", HnDConfiguration.Current.DefaultFromEmailAddress);
			emailData.Add("defaultToEmailAddress", HnDConfiguration.Current.DefaultToEmailAddress);
			emailData.Add("emailPasswordSubject", HnDConfiguration.Current.EmailPasswordSubject);
			emailData.Add("emailThreadNotificationSubject", HnDConfiguration.Current.EmailThreadNotificationSubject);
			emailData.Add("passwordResetRequestSubject", HnDConfiguration.Current.PasswordResetRequestSubject);
			emailData.Add("siteName", GetSiteName());
			emailData.Add("applicationURL", "https://" + hostName + GetVirtualRoot());
			emailData.Add("smtpHost", HnDConfiguration.Current.SmtpConfiguration.GetValue("MailServer"));
			emailData.Add("smtpPort", HnDConfiguration.Current.SmtpConfiguration.GetValue("MailPort"));
			emailData.Add("smtpUserName", HnDConfiguration.Current.SmtpConfiguration.GetValue("UserName"));
			emailData.Add("smtpPassword", HnDConfiguration.Current.SmtpConfiguration.GetValue("Password"));
			emailData.Add("smtpEnableSsl", HnDConfiguration.Current.SmtpConfiguration.GetValue("EnableSsl"));
			var emailTemplate = template switch
			{
				EmailTemplate.RegistrationReply => HnDConfiguration.Current.RegistrationReplyMailTemplate,
				EmailTemplate.ThreadUpdatedNotification => HnDConfiguration.Current.ThreadUpdatedNotificationTemplate,
				EmailTemplate.ResetPasswordLink => HnDConfiguration.Current.ResetPasswordLinkTemplate,
				_ => string.Empty
			};
			emailData.Add("emailTemplate", emailTemplate);
			return emailData;
		}


		/// <summary>
		/// Gets the noise words to filter out in searches
		/// </summary>
		/// <returns>Hashtable of noise words if available, otherwise null</returns>
		public static HashSet<string> GetNoiseWords()
		{
			return HnDConfiguration.Current.NoiseWords ?? new HashSet<string>();
		}


		/// <summary>
		/// Gets a dictionary with per name of the emoji (key) the filename the picture is located in (value)
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetEmojiFilenamesPerName()
		{
			return HnDConfiguration.Current.EmojiFilenamesPerName;
		}


		/// <summary>
		/// Gets a dictionary with the mappings between smiley shortcuts (e.g. ':)') and the emoji names
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetSmileyMappings()
		{
			return HnDConfiguration.Current.SmileyMappingsLookup;
		}


		/// <summary>
		/// Gets the cached value representing the number of unapproved attachments
		/// </summary>
		/// <returns></returns>
		public static int GetCachedNumberOfUnapprovedAttachments()
		{
			return HnDConfiguration.Current.GetCachedNumberOfUnapprovedAttachments();
		}


		/// <summary>
		/// Removes the cached value representing the number of unapproved attachments 
		/// </summary>
		/// <returns></returns>
		public static int InvalidateCachedNumberOfUnapprovedAttachments()
		{
			return HnDConfiguration.Current.InvalidateCachedNumberOfUnapprovedAttachments();
		}


		/// <summary>
		/// Gets the cached value representing the number of threads in the support queues
		/// </summary>
		/// <returns></returns>
		public static int GetCachedNumberOfThreadsInSupportQueues()
		{
			return HnDConfiguration.Current.GetCachedNumberOfThreadsInSupportQueues();
		}


		/// <summary>
		/// Removes the cached value representing the number of threads in the support queues
		/// </summary>
		/// <returns></returns>
		public static int InvalidateCachedNumberOfThreadsInSupportQueues()
		{
			return HnDConfiguration.Current.InvalidateCachedNumberOfThreadsInSupportQueues();
		}


		/// <summary>
		/// Checks if the nickname passed in is among the users which have to be logged out by force. All users which are deleted have to be logged out by force. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		/// <returns>true if the user has to be logged out by force, false otherwise.</returns>
		public static bool UserHasToBeLoggedOutByForce(string nickName)
		{
			return HnDConfiguration.Current.UserHasToBeLoggedOutByForce(nickName);
		}


		/// <summary>
		/// Adds the user to be logged out by force to the set of usernicknames. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public static void AddUserToListToBeLoggedOutByForce(string nickName)
		{
			HnDConfiguration.Current.AddUserToListToBeLoggedOutByForce(nickName);
		}


		/// <summary>
		/// Removes the user from the list to be logged out by force.
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public static void RemoveUserFromListToBeLoggedOutByForce(string nickName)
		{
			HnDConfiguration.Current.RemoveUserFromListToBeLoggedOutByForce(nickName);
		}
	}
}