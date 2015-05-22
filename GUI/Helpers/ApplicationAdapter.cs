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
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.BL;
using SD.HnD.Utility;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Xml.Xsl;
using System.IO;
using System.Collections.Generic;


namespace SD.HnD.Gui
{
    /// <summary>
    /// ApplicationAdapter is used to access Application-wide variables stored in the HttpApplicationState collection
    /// </summary>
    public static class ApplicationAdapter
    {
        /// <summary>
        /// Gets the max amount messages per page.
        /// </summary>
        /// <returns>maxAmountMessagesPerPage if available, otherwise 25</returns>
        public static int GetMaxAmountMessagesPerPage()
        {
	        var toReturn = HttpContext.Current.Application["maxAmountMessagesPerPage"];
	        return toReturn == null ? Globals.DefaultMaxNumberOfMessagesPerPage : (int)toReturn;
        }


	    /// <summary>
        /// Gets the default from mail address.
        /// </summary>
        /// <returns>defaultFromEmailAddress if available, otherwise an empty string</returns>
        private static string GetDefaultFromEmailAddress()
        {
			return (HttpContext.Current.Application["defaultFromEmailAddress"] as string) ?? string.Empty;
        }


	    /// <summary>
        /// Gets the default to mail address.
        /// </summary>
        /// <returns>defaultToEmailAddress if available, otherwise an empty string</returns>
        private static string GetDefaultToEmailAddress()
        {
			return (HttpContext.Current.Application["defaultToEmailAddress"] as string) ?? string.Empty;
        }


	    /// <summary>
        /// Gets the email password subject.
        /// </summary>
        /// <returns>emailPasswordSubject if available, otherwise an empty string</returns>
        private static string GetEmailPasswordSubject()
        {
			return (HttpContext.Current.Application["emailPasswordSubject"] as string) ?? string.Empty;
        }


	    /// <summary>
		/// Gets the email thread notification subject.
		/// </summary>
		/// <returns>the threadnodification email subject, or an empty string if not found.</returns>
		private static string GetEmailThreadNotificationSubject()
		{
			return (HttpContext.Current.Application["emailThreadNotificationSubject"] as string) ?? string.Empty;
		}


	    /// <summary>
        /// Gets the name of the site.
        /// </summary>
        /// <returns>siteName if available, otherwise an empty string</returns>
        public static string GetSiteName()
        {
	        return (HttpContext.Current.Application["siteName"] as string) ?? string.Empty;
        }


	    /// <summary>
        /// Gets the virtual root.
        /// </summary>
        /// <returns>virtualRoot if available, otherwise an empty string</returns>
        public static string GetVirtualRoot()
        {
		    if(HttpContext.Current.Application["virtualRoot"] == null)
		    {
			    return string.Empty;
		    }
		    string toReturn = HttpContext.Current.Application["virtualRoot"].ToString();
		    if(!toReturn.EndsWith(@"/"))
		    {
			    toReturn += @"/";
		    }
		    return toReturn;
        }
		

        /// <summary>
        /// Gets the data files folder MapPath.
        /// </summary>
        /// <returns>the data files folder MapPath if available, otherwise an empty string</returns>
        public static string GetDataFilesMapPath()
        {
	        return (HttpContext.Current.Application["datafilesMapPath"] as string) ?? string.Empty;
        }


	    /// <summary>
        /// Gets an email template file path given the template type from the corresponding enum.
        /// </summary>
        /// <returns>the email template file path </returns>
        public static string GetEmailTemplate(EmailTemplate template)
        {
			string toReturn = string.Empty;
            switch (template)
            {
                case EmailTemplate.RegistrationReply:
					toReturn = (string)HttpContext.Current.Application["registrationReplyMailTemplate"];
                    break;
                case EmailTemplate.ThreadUpdatedNotification:
                    toReturn = (string)HttpContext.Current.Application["threadUpdatedNotificationTemplate"];
                    break;
            }
			return toReturn;
        }


        /// <summary>
        /// Create a DTO of all needed e-mail default data.
        /// </summary>
		/// <returns>a dictionary of the following keys (defaultFromEmailAddress, defaultToEmailAddress, defaultSMTPServer, emailPassowrdSubject, siteName, applicationURL)</returns>
        public static Dictionary<string, string> GetEmailData()
        {
            Dictionary<string, string> emailData = new Dictionary<string, string>();
            emailData.Add("defaultFromEmailAddress", GetDefaultFromEmailAddress());
            emailData.Add("defaultToEmailAddress", GetDefaultToEmailAddress());
			emailData.Add("emailPasswordSubject", GetEmailPasswordSubject());
			emailData.Add("emailThreadNotificationSubject", GetEmailThreadNotificationSubject());
            emailData.Add("siteName", GetSiteName());
			emailData.Add("applicationURL", "http://" + HttpContext.Current.Request.Url.Host + GetVirtualRoot());

            return emailData;
        }


		/// <summary>
		/// Gets the message style.
		/// </summary>
		/// <returns>A XslTransform if available, otherwise null</returns>
		private static XslCompiledTransform GetMessageStyle()
		{
			return HttpContext.Current.Application["messageStyle"] as XslCompiledTransform;
		}


	    /// <summary>
		/// Gets the signature style.
		/// </summary>
		/// <returns>A XslTransform if available, otherwise null</returns>
		private static XslCompiledTransform GetSignatureStyle()
	    {
		    return HttpContext.Current.Application["signatureStyle"] as XslCompiledTransform;
	    }


	    /// <summary>
		/// Create a DTO of all needed e-mail default data.
		/// </summary>
		/// <returns>a dictionary of the following keys (grammar, actionTable, gotoTable, messageStyle, signatureStyle)</returns>
		public static ParserData GetParserData()
		{
		    return new ParserData {MessageStyle = GetMessageStyle(), SignatureStyle = GetSignatureStyle()};
		}

		/// <summary>
		/// Gets the noise words.
		/// </summary>
		/// <returns>Hashtable of noise words if available, otherwise null</returns>
		public static HashSet<string> GetNoiseWords()
		{
			return HttpContext.Current.Application["noiseWords"] as HashSet<string>;
		}


	    /// <summary>
		/// Gets the IP ban complain email address.
		/// </summary>
		/// <returns>IPBanComplainEmailAddress if available, otherwise string.Empty</returns>
		public static string GetIPBanComplainEmailAddress()
	    {
		    return (HttpContext.Current.Application["IPBanComplainEmailAddress"] as string) ?? string.Empty;
	    }


	    /// <summary>
		/// Gets the cache flags per forumid
		/// </summary>
		/// <returns>Dictionary of cahce flags if available, otherwise null</returns>
		public static Dictionary<int, bool> GetCacheFlags()
	    {
		    return HttpContext.Current.Application["cacheFlags"]  as Dictionary<int, bool>;
	    }


	    /// <summary>
		/// sets the flag for the cached RSS feed for the given forum to false, so the cache will be invalidated for that forum rss feed
		/// </summary>
		/// <param name="forumID">ID of forum which rss feed to invalidate</param>
		public static void InvalidateCachedForumRSS(int forumID)
		{
			Dictionary<int, bool> cacheFlags = GetCacheFlags();
		    if(cacheFlags == null)
		    {
			    return;
		    }
			try
			{
				HttpContext.Current.Application.Lock();
				cacheFlags[forumID] = false;
			}
			finally 			
			{
				HttpContext.Current.Application.UnLock();
			}
		}


		/// <summary>
		/// Checks if the nickname passed in is among the users which have to be logged out by force. All users which are deleted have to be logged out by force. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		/// <returns>true if the user has to be logged out by force, false otherwise.</returns>
		public static bool UserHasToBeLoggedOutByForce(string nickName)
		{
			return ((HashSet<string>)HttpContext.Current.Application["usersToLogoutByForce"]).Contains(nickName);
		}


		/// <summary>
		/// Adds the user to be logged out by force to the set of usernicknames. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public static void AddUserToListToBeLoggedOutByForce(string nickName)
		{
			var usersToLogOutByForce = (HashSet<string>)HttpContext.Current.Application["usersToLogoutByForce"];
			if(usersToLogOutByForce.Contains(nickName))
			{
				return;
			}
			try
			{
				HttpContext.Current.Application.Lock();
				usersToLogOutByForce.Add(nickName);
			}
			finally
			{
				HttpContext.Current.Application.UnLock();
			}
		}


		/// <summary>
		/// Removes the user from the list to be logged out by force.
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public static void RemoveUserFromListToBeLoggedOutByForce(string nickName)
		{
			var usersToLogOutByForce = (HashSet<string>)HttpContext.Current.Application["usersToLogoutByForce"];
			if(!usersToLogOutByForce.Contains(nickName))
			{
				return;
			}
			try
			{
				HttpContext.Current.Application.Lock();
				usersToLogOutByForce.Remove(nickName);
			}
			finally
			{
				HttpContext.Current.Application.UnLock();
			}
		}
		

        /// <summary>
        /// Loads application wide cached data into the Application Object. This routine
        /// is called at startup, when the Application_Start event is thrown.
        /// </summary>
        public static void LoadApplicationObjectCacheData()
        {
            HttpContext currentHttpContext = HttpContext.Current;
            NameValueCollection appSettingsCollection = (NameValueCollection)ConfigurationManager.GetSection("appSettings");

            // read data from web.config
            string defaultFromEmailAddress = appSettingsCollection["DefaultFromEmailAddress"];
            string defaultToEmailAddress = appSettingsCollection["DefaultToEmailAddress"];
			string emailPasswordSubject = appSettingsCollection["EmailPasswordSubject"];
			string emailThreadNotificationSubject = appSettingsCollection["EmailThreadNotificationSubject"];
			string siteName = appSettingsCollection["SiteName"];
            string virtualRoot = appSettingsCollection["VirtualRoot"];

            string ipBanComplainEmailAddress = appSettingsCollection["IPBanComplainEmailAddress"];
            int maxAmountMessagesPerPage = Convert.ToInt32(appSettingsCollection["MaxAmountMessagesPerPage"]);

            string datafilesPath = currentHttpContext.Server.MapPath(appSettingsCollection["DatafilesPath"]);
            string ubbMessageTransformXSLPathFilename = appSettingsCollection["UBBMessageTransformXSLPathFilename"];
            string ubbSignatureTransformXSLPathFilename = appSettingsCollection["UBBSignatureTransformXSLPathFilename"];

            // Load XML -> HTML transformation XSL
			XslCompiledTransform messageStyle = new XslCompiledTransform();
			XslCompiledTransform signatureStyle = new XslCompiledTransform();

			messageStyle.Load(Path.Combine(datafilesPath, ubbMessageTransformXSLPathFilename));
			signatureStyle.Load(Path.Combine(datafilesPath, ubbSignatureTransformXSLPathFilename));

            var noiseWords = GuiHelper.LoadNoiseWordsIntoHashSet(datafilesPath);

            string registrationReplyMailTemplate = File.ReadAllText(Path.Combine(datafilesPath, "RegistrationReplyMail.template"));
            string threadUpdatedNotificationTemplate = File.ReadAllText(Path.Combine(datafilesPath, "ThreadUpdatedNotification.template"));
			// add other email templates here. 

			DataView bannedNicknames = UserGuiHelper.GetAllBannedUserNicknamesAsDataView();
			var usersToLogoutByForce = new HashSet<string>();
			foreach(DataRowView row in bannedNicknames)
			{
				usersToLogoutByForce.Add(row["Nickname"].ToString());
			}
            HttpApplicationState applicationState = currentHttpContext.Application;
            try
            {
                applicationState.Lock();

                applicationState.Add("defaultFromEmailAddress", defaultFromEmailAddress);
				applicationState.Add("defaultToEmailAddress", defaultToEmailAddress);
                applicationState.Add("siteName", siteName);
                applicationState.Add("virtualRoot", virtualRoot);
                applicationState.Add("datafilesMapPath", datafilesPath);
				applicationState.Add("emailPasswordSubject", emailPasswordSubject);
				applicationState.Add("emailThreadNotificationSubject", emailThreadNotificationSubject);

				applicationState.Add("messageStyle", messageStyle);
				applicationState.Add("signatureStyle", signatureStyle);

                applicationState.Add("noiseWords", noiseWords);
                applicationState.Add("maxAmountMessagesPerPage", maxAmountMessagesPerPage);
                applicationState.Add("IPBanComplainEmailAddress", ipBanComplainEmailAddress);
				applicationState.Add("cacheFlags", new Dictionary<int, bool>());
				applicationState.Add("usersToLogoutByForce", usersToLogoutByForce);
				applicationState.Add("registrationReplyMailTemplate", registrationReplyMailTemplate);
                applicationState.Add("threadUpdatedNotificationTemplate", threadUpdatedNotificationTemplate);
            }
            finally
            {
                applicationState.UnLock();
            }
        }
    }
}
