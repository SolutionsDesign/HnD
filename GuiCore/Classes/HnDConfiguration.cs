using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using SD.HnD.BL;
using SD.Tools.BCLExtensions.CollectionsRelated;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Class to bind the HnD section in the appsettings.json values with for easy configuration.
	/// </summary>
	public class HnDConfiguration
	{
		#region Members
		private ReaderWriterLockSlim _volatileDataLock;
		private HashSet<string> _usersToLogoutByForce;
		private int? _cachedNumberOfUnapprovedAttachments, _cachedNumberOfThreadsInSupportQueues;

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
			_volatileDataLock = new ReaderWriterLockSlim();
			_cachedNumberOfUnapprovedAttachments = null;
			_cachedNumberOfThreadsInSupportQueues = null;
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
			
			if(string.IsNullOrWhiteSpace(this.VirtualRoot))
			{
				this.VirtualRoot = "/";
			}
			if(!this.VirtualRoot.EndsWith("/"))
			{
				this.VirtualRoot += "/";
			}
			if(this.DataFilesPath == null)
			{
				this.DataFilesPath = string.Empty;
			}
			// replace / with \ if we're on windows, or \ with / if we're on linux. 
			this.DataFilesPath = this.DataFilesPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			// clamp search result caching timeout between 1 and 60 minutes.
			this.MaxNumberOfMinutesToCacheSearchResults = Math.Max(1, Math.Min(60, this.MaxNumberOfMinutesToCacheSearchResults));

			foreach(var mapping in this.SmileyMappings)
			{
				this.SmileyMappingsLookup[mapping.From] = mapping.To ?? string.Empty;
			}
		}


		/// <summary>
		/// Gets the number of unapproved attachments, which is a cached number. If it's not initialized, the method will initialize
		/// the value from the database. 
		/// </summary>
		/// <returns></returns>
		public int GetCachedNumberOfUnapprovedAttachments()
	    {
			_volatileDataLock.EnterUpgradeableReadLock();
		    try
		    {
			    if(_cachedNumberOfUnapprovedAttachments.HasValue)
			    {
				    return _cachedNumberOfUnapprovedAttachments.Value;
			    }
			    return InvalidateCachedNumberOfUnapprovedAttachments();
		    }
			finally
		    {
				_volatileDataLock.ExitUpgradeableReadLock();
		    }
	    }


		/// <summary>
		/// Invalidates the number of unapproved attachments by fetching the total number of unapproved attachments from the database.   
		/// </summary>
		/// <returns></returns>
		/// <remarks>Not using async as it relies on locks to work so we need predictability.</remarks>
	    public int InvalidateCachedNumberOfUnapprovedAttachments()
	    {
			_volatileDataLock.EnterWriteLock();
		    try
		    {
				_cachedNumberOfUnapprovedAttachments = MessageGuiHelper.GetTotalNumberOfAttachmentsToApprove();
			    return _cachedNumberOfUnapprovedAttachments.Value;
		    }
		    finally
		    {
				_volatileDataLock.ExitWriteLock();
		    }
	    }


		/// <summary>
		/// Gets the number of threads in support queues, which is a cached number in this object. If not initialized, this method will
		/// fetch the number from the database. 
		/// </summary>
		/// <returns></returns>
	    public int GetCachedNumberOfThreadsInSupportQueues()
	    {
			_volatileDataLock.EnterUpgradeableReadLock();
			try
			{
				if(_cachedNumberOfThreadsInSupportQueues.HasValue)
				{
					return _cachedNumberOfThreadsInSupportQueues.Value;
				}
				return InvalidateCachedNumberOfThreadsInSupportQueues();
			}
			finally
			{
				_volatileDataLock.ExitUpgradeableReadLock();
			}
	    }


		/// <summary>
		/// Invalidates the number of threads in support queues by fetching the total number from the database. 
		/// </summary>
		/// <returns></returns>
	    public int InvalidateCachedNumberOfThreadsInSupportQueues()
	    {
			_volatileDataLock.EnterWriteLock();
			try
			{
				_cachedNumberOfThreadsInSupportQueues = SupportQueueGuiHelper.GetTotalNumberOfThreadsInSupportQueues();
				return _cachedNumberOfThreadsInSupportQueues.Value;
			}
			finally
			{
				_volatileDataLock.ExitWriteLock();
			}
	    }


		/// <summary>
		/// Removes the user from the list to be logged out by force.
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public void RemoveUserFromListToBeLoggedOutByForce(string nickName)
		{
			_volatileDataLock.EnterUpgradeableReadLock();
			try
			{
				if(!_usersToLogoutByForce.Contains(nickName))
				{
					return;
				}
				_volatileDataLock.EnterWriteLock();
				try
				{
					_usersToLogoutByForce.Remove(nickName);
				}
				finally
				{
					_volatileDataLock.ExitWriteLock();
				}
			}
			finally
			{
				_volatileDataLock.ExitUpgradeableReadLock();
			}
		}
		

		/// <summary>
		/// Checks if the nickname passed in is among the users which have to be logged out by force. All users which are deleted have to be logged out by force. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		/// <returns>true if the user has to be logged out by force, false otherwise.</returns>
		public bool UserHasToBeLoggedOutByForce(string nickName)
		{
			_volatileDataLock.EnterReadLock();
			try
			{
				return _usersToLogoutByForce.Contains(nickName);
			}
			finally
			{
				_volatileDataLock.ExitReadLock();
			}
		}


		/// <summary>
		/// Adds the user to be logged out by force to the set of usernicknames. 
		/// </summary>
		/// <param name="nickName">Name of the nick.</param>
		public void AddUserToListToBeLoggedOutByForce(string nickName)
		{
			_volatileDataLock.EnterUpgradeableReadLock();
			try
			{
				if(_usersToLogoutByForce.Contains(nickName))
				{
					return;
				}
				_volatileDataLock.EnterWriteLock();
				try
				{
					_usersToLogoutByForce.Add(nickName);
				}
				finally
				{
					_volatileDataLock.ExitWriteLock();
				}
			}
			finally
			{
				_volatileDataLock.ExitUpgradeableReadLock();
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
			this.NoiseWords = GuiHelper.LoadNoiseWordsIntoHashSet(this.FullDataFilesPath);
			this.RegistrationReplyMailTemplate = File.ReadAllText(Path.Combine(this.DataFilesPath, "RegistrationReplyMail.template"));
			this.ThreadUpdatedNotificationTemplate = File.ReadAllText(Path.Combine(this.DataFilesPath, "ThreadUpdatedNotification.template"));
			this.ResetPasswordLinkTemplate = File.ReadAllText(Path.Combine(this.DataFilesPath, "ResetPasswordLink.template"));

			// Don't prefix the urlpath with the virtual root yet, as we use the path also for folder names below
			var emojiUrlPath = this.EmojiFilesPath ?? string.Empty;
			// replace / with \ if we're on windows and / with \ if we're on linux
			var emojiUrlPathForFilename = emojiUrlPath.TrimStart('\\', '/').Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar); 
			var emojiFilesPath = Path.Combine(webRootPath ?? string.Empty, emojiUrlPathForFilename);
			// We have to prefix the emojiUrlPath with the virtual root now. 
			emojiUrlPath = (this.VirtualRoot + emojiUrlPath).Replace("//", "/");
	        this.EmojiFilenamesPerName = LoadEmojiFilenames(emojiFilesPath, emojiUrlPath);
			// load nicks of banned users
			var bannedNicknames = UserGuiHelper.GetAllBannedUserNicknames();
			_volatileDataLock.EnterWriteLock();
			try
			{
				_usersToLogoutByForce.AddRange(bannedNicknames);
			}
			finally
			{
				_volatileDataLock.ExitWriteLock();
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
		public List<FromToMapping> SmileyMappings { get; set; } = new List<FromToMapping>();
		public Dictionary<string, string> SmileyMappingsLookup { get; } = new Dictionary<string, string>();
		public Dictionary<string, string> SmtpConfiguration { get; set; } = new Dictionary<string, string>();
		public string VirtualRoot { get; set; } = "/";
		public string DefaultFromEmailAddress { get; set; } = string.Empty;
		public string DefaultToEmailAddress { get; set; } = string.Empty;
		public string SiteName { get; set; } = string.Empty;
		public string EmailPasswordSubject { get; set; } = string.Empty;
		public string PasswordResetRequestSubject { get; set; } = string.Empty;
		public string EmailThreadNotificationSubject { get; set; } = string.Empty;
		public string EmojiFilesPath { get; set; } = "/pics/emojis";
		public string DataFilesPath { get; set; } = "/DataFiles";
		public string FullDataFilesPath { get; set; } = string.Empty;
		public int MaxAmountMessagesPerPage { get; set; } = Globals.DefaultMaxNumberOfMessagesPerPage;
		public HashSet<string> NoiseWords { get; set; } = new HashSet<string>();
		public Dictionary<string, string> EmojiFilenamesPerName { get; set; } = new Dictionary<string, string>();
		public string RegistrationReplyMailTemplate { get; set; }
		public string ThreadUpdatedNotificationTemplate { get; set; }
		public string ResetPasswordLinkTemplate { get; set; }
		public int MaxNumberOfMinutesToCacheSearchResults { get; set; }
	}
}