////////////////////////////////////////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2013 Solutions Design. All rights reserved.
// http://www.llblgen.com
////////////////////////////////////////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2013 Solutions Design. All rights reserved.
// http://www.llblgen.com
// 
// This LLBLGen Pro Contrib library is released under the following license: (BSD2)
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
//   
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SD.LLBLGen.Pro.ORMSupportClasses.Contrib.Caching
{
	/// <summary>
	/// Class which keeps track of cachekeys and creates memorycache keys. It purges keys if necessary on time. 
	/// </summary>
	public class CacheKeyStore
	{
		#region Members
		private Dictionary<CacheKey, Guid> _cacheKeyToMemoryCacheKey;
		private MultiValueHashtable<string, CacheKey> _cacheKeysPerTag;
		private List<ValuePair<CacheKey, DateTime>> _cacheKeysAndExpireDates;
		private object _semaphore;
		private Timer _purgeTimer;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CacheKeyStore"/> class.
		/// </summary>
		public CacheKeyStore()
		{
			_cacheKeysPerTag = new MultiValueHashtable<string, CacheKey>();
			_cacheKeyToMemoryCacheKey = new Dictionary<CacheKey, Guid>();
			_cacheKeysAndExpireDates = new List<ValuePair<CacheKey, DateTime>>();
			_semaphore = new object();
			_purgeTimer = new Timer(5.0);
			_purgeTimer.Elapsed += _purgeTimer_Elapsed;
			_purgeTimer.Enabled = true;
		}


		/// <summary>
		/// Gets a memorycache usable key for the original cachekey specified which is stored in this store, if it doesn't exist already, otherwise the
		/// existing one is returned.
		/// </summary>
		/// <param name="originalKey">The original key.</param>
		/// <param name="duration">The duration. Should not be Zero.</param>
		/// <param name="tag">The tag.</param>
		/// <returns></returns>
		public string GetPersistentCacheKey(CacheKey originalKey, TimeSpan duration, string tag)
		{
			return GetMemoryCacheKey(originalKey, true, duration, tag);
		}


		/// <summary>
		/// Gets a non-persistent key usable for memorycache for the specified original key. The key isn't stored in this store, however if a key is found for
		/// the specified original cachekey in this store, that key is returned.
		/// </summary>
		/// <param name="originalKey">The original key.</param>
		/// <returns></returns>
		public string GetNonPersistentCacheKey(CacheKey originalKey)
		{
			return GetMemoryCacheKey(originalKey, false, TimeSpan.Zero, string.Empty);
		}


		/// <summary>
		/// Gets the cache keys stored in this store which are associated with the tag specified, if not empty.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <returns></returns>
		public List<CacheKey> GetCacheKeysForTag(string tag)
		{
			var toReturn = new List<CacheKey>();
			using(TimedLock.Lock(_semaphore))
			{
				if(!string.IsNullOrEmpty(tag) && _cacheKeysPerTag.ContainsKey(tag))
				{
					toReturn.AddRange(_cacheKeysPerTag.GetValue(tag));
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Gets the memory cache key to use for the cachekey specified.
		/// </summary>
		/// <param name="originalKey">The original key.</param>
		/// <param name="keepMemoryCacheKey">if set to <c>true</c> it will keep the key in the storage</param>
		/// <param name="duration">The duration, if available, the cachekey is valid. Only used if keepMemoryCacheKey is true. If TimeSpan.Zero, it's considered
		/// not available/specified</param>
		/// <param name="tag">The tag, if available. Only used if keepMemoryCacheKey is true.</param>
		/// <returns>
		/// the string equivalent of the guid associated with the cachekey specified
		/// </returns>
		private string GetMemoryCacheKey(CacheKey originalKey, bool keepMemoryCacheKey, TimeSpan duration, string tag)
		{
			Guid toReturn = Guid.Empty;
			using(TimedLock.Lock(_semaphore))
			{
				if(!_cacheKeyToMemoryCacheKey.TryGetValue(originalKey, out toReturn))
				{
					toReturn = Guid.NewGuid();
					if(keepMemoryCacheKey)
					{
						_cacheKeyToMemoryCacheKey.Add(originalKey, toReturn);
						if(!string.IsNullOrEmpty(tag))
						{
							_cacheKeysPerTag.Add(tag, originalKey);
						}
						if(duration != TimeSpan.Zero)
						{
							_cacheKeysAndExpireDates.Add(new ValuePair<CacheKey, DateTime>(originalKey, DateTime.Now.ToUniversalTime().Add(duration)));
						}
					}
				}
			}
			return toReturn.ToString();
		}


		/// <summary>
		/// Purges the expired cachekeys from the store. 
		/// </summary>
		private void PurgeExpiredElements()
		{
			using(TimedLock.Lock(_semaphore))
			{
				var now = DateTime.Now.ToUniversalTime();
				var toPurge = _cacheKeysAndExpireDates.Where(kvp => kvp.Value2 < now).Select(kvp=>kvp.Value1).ToList();
				_cacheKeysAndExpireDates = _cacheKeysAndExpireDates.Where(kvp => kvp.Value2 >= now).ToList();

				foreach(var key in toPurge)
				{
					_cacheKeyToMemoryCacheKey.Remove(key);
					var tagsToRemove = new List<string>();
					foreach(var kvp in _cacheKeysPerTag)
					{
						if(kvp.Value.Contains(key))
						{
							((ICollection<CacheKey>)kvp.Value).Remove(key);
							if(kvp.Value.Count <= 0)
							{
								tagsToRemove.Add(kvp.Key);
							}
						}
					}
					foreach(var tag in tagsToRemove)
					{
						_cacheKeysPerTag.Remove(tag);
					}
				}
			}
		}
		

		/// <summary>
		/// Handles the Elapsed event of the _purgeTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="ElapsedEventArgs" /> instance containing the event data.</param>
		void _purgeTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			PurgeExpiredElements();
		}
	}
}
