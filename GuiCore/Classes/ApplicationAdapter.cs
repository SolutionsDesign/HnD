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
    /// In previous versions
    /// this class wrapped access to the HttpApplication object, however in ASP.NET Core this object is no longer present.
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
        /// Gets the data files folder MapPath.
        /// </summary>
        /// <returns>the data files folder MapPath if available, otherwise an empty string</returns>
        public static string GetDataFilesMapPath()
		{
			return HnDConfiguration.Current.DataFilesPath;
        }


		public static int GetMaxNumberOfMinutesToCacheSearchResults()
		{
			return HnDConfiguration.Current.MaxNumberOfMinutesToCacheSearchResults;
		}


	    /// <summary>
        /// Gets an email template file path given the template type from the corresponding enum.
        /// </summary>
        /// <returns>the email template file path </returns>
        public static string GetEmailTemplate(EmailTemplate template)
		{
			return template switch
			{
				EmailTemplate.RegistrationReply => HnDConfiguration.Current.RegistrationReplyMailTemplate,
				EmailTemplate.ThreadUpdatedNotification => HnDConfiguration.Current.ThreadUpdatedNotificationTemplate,
				_ => string.Empty
			};
		}


        /// <summary>
        /// Create a DTO of all needed e-mail default data.
        /// </summary>
        /// <param name="hostName">The name of the host, e.g. www.llblgen.com. Obtained from HttpContext.Request.Host.Host
        /// object in the controller ctor.</param>
		/// <returns>a dictionary of the following keys (defaultFromEmailAddress, defaultToEmailAddress, defaultSMTPServer, emailPassowrdSubject,
		/// siteName, applicationURL)</returns>
        public static Dictionary<string, string> GetEmailData(string hostName)
        {
            Dictionary<string, string> emailData = new Dictionary<string, string>();
            emailData.Add("defaultFromEmailAddress", HnDConfiguration.Current.DefaultFromEmailAddress);
            emailData.Add("defaultToEmailAddress", HnDConfiguration.Current.DefaultToEmailAddress);
			emailData.Add("emailPasswordSubject", HnDConfiguration.Current.EmailPasswordSubject);
			emailData.Add("emailThreadNotificationSubject", HnDConfiguration.Current.EmailThreadNotificationSubject);
            emailData.Add("siteName", GetSiteName());
			emailData.Add("applicationURL", "https://" + hostName + GetVirtualRoot());
			emailData.Add("smtpHost", HnDConfiguration.Current.SmtpConfiguration.GetValue("MailServer"));
			emailData.Add("smtpPort", HnDConfiguration.Current.SmtpConfiguration.GetValue("MailPort"));
			emailData.Add("smtpUserName", HnDConfiguration.Current.SmtpConfiguration.GetValue("UserName"));
			emailData.Add("smtpPassword", HnDConfiguration.Current.SmtpConfiguration.GetValue("Password"));
			emailData.Add("smtpEnableSsl", HnDConfiguration.Current.SmtpConfiguration.GetValue("EnableSsl"));

            return emailData;
        }

		/// <summary>
		/// Gets the noise words.
		/// </summary>
		/// <returns>Hashtable of noise words if available, otherwise null</returns>
		public static HashSet<string> GetNoiseWords()
		{
			return HnDConfiguration.Current.NoiseWords ?? new HashSet<string>();
		}


	    /// <summary>
		/// Gets the IP ban complain email address.
		/// </summary>
		/// <returns>IPBanComplainEmailAddress if available, otherwise string.Empty</returns>
		public static string GetIPBanComplainEmailAddress()
		{
			return HnDConfiguration.Current.IPBanComplainEmailAddress ?? string.Empty;
	    }


	    /// <summary>
		/// Gets the cache flags per forumid
		/// </summary>
		/// <returns>Dictionary of cache flags if available, otherwise null</returns>
		public static Dictionary<int, bool> GetCacheFlags()
		{
			return HnDConfiguration.Current.GetCacheFlags();
	    }


	    public static Dictionary<string, string> GetEmojiFilenamesPerName()
		{
			return HnDConfiguration.Current.EmojiFilenamesPerName;
	    }


		public static Dictionary<string, string> GetSmileyMappings()
		{
			return HnDConfiguration.Current.SmileyMappingsLookup;
		}


	    public static int GetCachedNumberOfUnapprovedAttachments()
		{
			return HnDConfiguration.Current.GetCachedNumberOfUnapprovedAttachments();
	    }


	    public static int InvalidateCachedNumberOfUnapprovedAttachments()
		{
			return HnDConfiguration.Current.InvalidateCachedNumberOfUnapprovedAttachments();
	    }


	    public static int GetCachedNumberOfThreadsInSupportQueues()
		{
			return HnDConfiguration.Current.GetCachedNumberOfThreadsInSupportQueues();
	    }


	    public static int InvalidateCachedNumberOfThreadsInSupportQueues()
		{
			return HnDConfiguration.Current.InvalidateCachedNumberOfThreadsInSupportQueues();
	    }


		/// <summary>
		/// sets the flag for the cached RSS feed for the given forum to false, so the cache will be invalidated for that forum rss feed
		/// </summary>
		/// <param name="forumID">ID of forum which rss feed to invalidate</param>
		public static void InvalidateCachedForumRSS(int forumID)
		{
			HnDConfiguration.Current.InvalidateCachedForumRSS(forumID);
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
