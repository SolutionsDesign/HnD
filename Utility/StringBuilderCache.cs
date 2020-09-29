// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


/*============================================================
**
** Class:  StringBuilderCache
**
** Purpose: provide a cached reusable instance of stringbuilder
**          per thread  it's an optimization that reduces the 
**          number of instances constructed and collected.
**
**  Acquire - is used to get a string builder to use of a 
**            particular size.  It can be called any number of 
**            times, if a stringbuilder is in the cache then
**            it will be returned and the cache emptied.
**            subsequent calls will return a new stringbuilder.
**
**            A StringBuilder instance is cached in 
**            Thread Local Storage and so there is one per thread
**
**  Release - Place the specified builder in the cache if it is 
**            not too big.
**            The stringbuilder should not be used after it has 
**            been released.
**            Unbalanced Releases are perfectly acceptable.  It
**            will merely cause the runtime to create a new 
**            stringbuilder next time Acquire is called.
**
**  GetStringAndRelease
**          - ToString() the stringbuilder, Release it to the 
**            cache and return the resulting string
**
===========================================================*/

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SD.HnD.Utility
{
	/// <summary>
	/// [FB] See comments at the top of the file. From CoreFX (https://github.com/dotnet/corefx/blob/bffef76f6af208e2042a2f27bc081ee908bb390b/src/Common/src/System/IO/StringBuilderCache.cs),
	/// adjusted the max size. Also added support for multiple cached instances, and it returns the instance with the minimal size matching the requested size
	/// </summary>
	public static class StringBuilderCache
	{
		private const int MAX_BUILDER_SIZE = 2048;
		private const int DEFAULT_CAPACITY = 16;
		private const int MAX_CACHED_INSTANCES = 4;

		[ThreadStatic]
		private static List<StringBuilder> _cachedInstances;


		/// <summary>
		/// Acquires a string builder with the capacity specified. If no cached string builder is found with the requested capacity a new one is returned. If there are 
		/// cached stringbuilders with at least the requested capacity, the one with the minimal capacity is returned.  
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		/// <returns></returns>
		public static StringBuilder Acquire(int capacity = DEFAULT_CAPACITY)
		{
			var cachedInstances = AssureCachedInstancesStore();
			if(capacity <= MAX_BUILDER_SIZE)
			{
				// find the instance which has the lowest size matching the requested capacity, if any.
				StringBuilder minimalMatchingCachedInstance = null;
				StringBuilder minimalOverallInstance = null;
				int indexToRemove = -1;
				int indexMinimalOverall = -1;
				for(int i = 0; i < cachedInstances.Count; i++)
				{
					var cachedInstance = cachedInstances[i];
					if(minimalOverallInstance == null || minimalOverallInstance.Capacity > cachedInstance.Capacity)
					{
						minimalOverallInstance = cachedInstance;
						indexMinimalOverall = i;
					}

					if(capacity <= cachedInstance.Capacity && (minimalMatchingCachedInstance == null || minimalMatchingCachedInstance.Capacity > cachedInstance.Capacity))
					{
						minimalMatchingCachedInstance = cachedInstance;
						indexToRemove = i;
					}
				}

				if(minimalMatchingCachedInstance == null)
				{
					// check if the cache is at capacity. If so, remove the one with the lowest capacity, which we determined in the previous loop. The cleared space is then
					// to be filled with the new string builder we'll return which is of the capacity requested.
					if(cachedInstances.Count >= MAX_CACHED_INSTANCES)
					{
						cachedInstances.RemoveAt(indexMinimalOverall);
					}
				}
				else
				{
					cachedInstances.RemoveAt(indexToRemove);
					minimalMatchingCachedInstance.Length = 0;
					return minimalMatchingCachedInstance;
				}
			}

			// not a matching cached instance found, return a brand new one.
			return new StringBuilder(capacity);
		}


		/// <summary>
		/// Releases the specified string builder and add it to the cache, if it's not at capacity already.
		/// </summary>
		/// <param name="sb">The string builder to release.</param>
		public static void Release(StringBuilder sb)
		{
			if(sb == null)
			{
				return;
			}

			var cachedInstances = AssureCachedInstancesStore();
			if(cachedInstances.Count >= MAX_CACHED_INSTANCES)
			{
				// already at capacity, ignore
				return;
			}

			if(sb.Capacity <= MAX_BUILDER_SIZE)
			{
				cachedInstances.Add(sb);
			}
		}


		/// <summary>
		/// Gets the string from the string builder specified and calls release on it
		/// </summary>
		/// <param name="sb">The stringbuilder</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetStringAndRelease(StringBuilder sb)
		{
			if(sb == null)
			{
				return string.Empty;
			}

			string result = sb.ToString();
			Release(sb);
			return result;
		}


		/// <summary>
		/// Makes sure the cached instances store is present for this thread.
		/// </summary>
		/// <returns>The cached instances created or the one already present</returns>
		private static List<StringBuilder> AssureCachedInstancesStore()
		{
			List<StringBuilder> toReturn = _cachedInstances;
			if(_cachedInstances == null)
			{
				toReturn = new List<StringBuilder>(MAX_CACHED_INSTANCES);
				_cachedInstances = toReturn;
			}

			return toReturn;
		}
	}
}