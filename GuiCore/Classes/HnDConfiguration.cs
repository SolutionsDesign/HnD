using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using SD.HnD.BL;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Class to bind the HnD section in the appsettings.json values with for easy configuration.
	/// </summary>
	public class HnDConfiguration
	{
		#region Members
		private object _lock = new object();
		private HashSet<string> _usersToLogoutByForce;
		private Dictionary<int, bool> _cacheFlags;

		/// <summary>
		/// Static instance holder, to avoid DI in all controllers which need it. 
		/// </summary>
		public static HnDConfiguration Current;
		#endregion

		#region Contained classes
		/// <summary>
		/// Class to contain a runtime cache configuration
		/// </summary>
		public class CacheConfiguration
		{
			/// <summary>
			/// Converts this instance's data into a NameValueCollection for usage with System.Runtime.Caching's MemoryCache's constructor.
			/// </summary>
			/// <returns></returns>
			public NameValueCollection ToNameValueCollection()
			{
				var toReturn = new NameValueCollection(3);
				toReturn["CacheMemoryLimitMegabytes"] = this.CacheMemoryLimitMegabytes.ToString();
				toReturn["PhysicalMemoryLimitPercentage"] = this.PhysicalMemoryLimitPercentage.ToString();
				toReturn["PollingInterval"] = this.PollingInterval.ToString();
				return toReturn;
			}
			
			public int CacheMemoryLimitMegabytes { get; set;  }
			public int PhysicalMemoryLimitPercentage { get; set; }
			public TimeSpan PollingInterval { get; set; }
		}
		#endregion

		public HnDConfiguration()
		{
			Current = this;
			_usersToLogoutByForce = new HashSet<string>();
			_cacheFlags = new Dictionary<int, bool>();
		}

		/// <summary>
		/// Makes sure the values read from the config are usable. 
		/// </summary>
		public void Sanitize()
		{
			if(this.MaxAmountMessagesPerPage < 1)
			{
				this.MaxAmountMessagesPerPage = 25;
			}

			var keysToReset = new List<string>();
			foreach(var kvp in this.SmileyMappings)
			{
				if(kvp.Value == null)
				{
					keysToReset.Add(kvp.Key);
				}
			}
			foreach(var key in keysToReset)
			{
				this.SmileyMappings[key] = string.Empty;
			}
		}
		

		/// <summary>
		/// sets the flag for the cached RSS feed for the given forum to false, so the cache will be invalidated for that forum rss feed
		/// </summary>
		/// <param name="forumID">ID of forum which rss feed to invalidate</param>
		public void InvalidateCachedForumRSS(int forumID)
		{
			lock(_lock)
			{
				if(_cacheFlags.Count<=0)
				{
					return;
				}
				_cacheFlags[forumID] = false;
			}
		}
		

		/// <summary>
		/// Removes the user from the list to be logged out by force.
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public void RemoveUserFromListToBeLoggedOutByForce(string nickName)
		{
			lock(_lock)
			{
				if(!_usersToLogoutByForce.Contains(nickName))
				{
					return;
				}
				_usersToLogoutByForce.Remove(nickName);
			}
		}
		

		/// <summary>
		/// Checks if the nickname passed in is among the users which have to be logged out by force. All users which are deleted have to be logged out by force. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		/// <returns>true if the user has to be logged out by force, false otherwise.</returns>
		public bool UserHasToBeLoggedOutByForce(string nickName)
		{
			lock(_lock)
			{
				return _usersToLogoutByForce.Contains(nickName);
			}
		}


		/// <summary>
		/// Adds the user to be logged out by force to the set of usernicknames. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public void AddUserToListToBeLoggedOutByForce(string nickName)
		{
			lock(_lock)
			{
				if(_usersToLogoutByForce.Contains(nickName))
				{
					return;
				}
				_usersToLogoutByForce.Add(nickName);
			}
		}
		

		/// <summary>
		/// Meant to be run at startup
		/// </summary>
		/// <param name="webRootPath"></param>
		/// <param name="contentRootPath"></param>
		public void LoadStaticData(string webRootPath, string contentRootPath)
		{
			this.FullDataFilesPath = Path.Combine(contentRootPath, this.DataFilesPath);
			this.NoiseWords = GuiHelper.LoadNoiseWordsIntoHashSet(this.DataFilesPath);
#warning  IMPLEMENT
			// string registrationReplyMailTemplate = File.ReadAllText(Path.Combine(datafilesPath, "RegistrationReplyMail.template"));
			// string threadUpdatedNotificationTemplate = File.ReadAllText(Path.Combine(datafilesPath, "ThreadUpdatedNotification.template"));

			var emojiUrlPath = this.EmojiFilesPath;
			var emojiFilesPath = Path.Combine(webRootPath, emojiUrlPath);
	        this.EmojiFilenamesPerName = LoadEmojiFilenames(emojiFilesPath, emojiUrlPath);
			// load nicks of banned users
			var bannedNicknames = UserGuiHelper.GetAllBannedUserNicknamesAsDataView();
			lock(_lock)
			{
				foreach(DataRowView row in bannedNicknames)
				{
					_usersToLogoutByForce.Add(row["Nickname"].ToString());
				}
			}
		}


		/// <summary>
		/// Loads all the filenames of png/jpg/gif files in the path specified.
		/// </summary>
		/// <param name="emojiFilesPath"></param>
		/// <param name="emojiUrlPath"></param>
		/// <returns>dictionary with key the filename without path/extension, and as value the filename with url path and extension</returns>
		private static Dictionary<string, string> LoadEmojiFilenames(string emojiFilesPath, string emojiUrlPath)
		{
			if(string.IsNullOrWhiteSpace(emojiFilesPath))
			{
				return new Dictionary<string, string>();
			}
			var emojiUrlPathToUse = (emojiUrlPath ?? string.Empty).TrimEnd('\\', '/');
			return Directory
				   .EnumerateFiles(emojiFilesPath, "*.png")
				   .Union(Directory.EnumerateFiles(emojiFilesPath, "*.jpg"))
				   .Union(Directory.EnumerateFiles(emojiFilesPath, "*.gif"))
				   .ToDictionary(f=>Path.GetFileNameWithoutExtension(f), f=>emojiUrlPathToUse + '/' + Path.GetFileName(f));
		}
		
		
		public CacheConfiguration ResultsetCacheConfiguration { get; set; }
		public Dictionary<string, string> SmileyMappings { get; set; } = new Dictionary<string, string>();
		public string VirtualRoot { get; set; } = "/";
		public string DefaultFromEmailAddress { get; set; } = string.Empty;
		public string DefaultToEmailAddress { get; set; } = string.Empty;
		public string IPBanComplainEmailAddress { get; set; } = string.Empty;
		public string SiteName { get; set; } = string.Empty;
		public string EmailPasswordSubject { get; set; } = string.Empty;
		public string EmailThreadNotificationSubject { get; set; } = string.Empty;
		public string EmojiFilesPath { get; set; } = "/pics/emojis";
		public string DataFilesPath { get; set; } = "/DataFiles";
		public string FullDataFilesPath { get; set; } = string.Empty;
		public int MaxAmountMessagesPerPage { get; set; } = 25;
		public HashSet<string> NoiseWords { get; set; } = new HashSet<string>();
		public Dictionary<string, string> EmojiFilenamesPerName { get; set; } = new Dictionary<string, string>();
	}
}