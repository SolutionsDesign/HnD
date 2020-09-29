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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SD.HnD.BL
{
	/// <summary>
	/// General helper class for the GUI of HnD. This class provides
	/// general purpose routines to get special things done for the gui, but which
	/// are not that important, BL wise. The class is still in the BL-tier, because
	/// it provides a service to the GUI, but isn't part of it.
	/// </summary>
	public static class GuiHelper
	{
		/// <summary>
		/// Loads the noise words into hashset. Noise words are words which can be ignored during message indexing and searches.
		/// </summary>
		/// <param name="dataFilesPath">Path to the datafiles folder</param>
		/// <returns>A hashset with all the noisewords found in the file Datafiles/Noise.txt</returns>
		public static HashSet<string> LoadNoiseWordsIntoHashSet(string dataFilesPath)
		{
			var fullPath = Path.Combine(dataFilesPath, "Noise.txt");
			using(var reader = new StreamReader(fullPath))
			{
				var noiseWords = new HashSet<string>();
				var eofReached = false;
				while(!eofReached)
				{
					var noiseWord = reader.ReadLine();
					eofReached = (noiseWord == null);
					if(!eofReached)
					{
						noiseWords.Add(noiseWord);
					}
				}

				return noiseWords;
			}
		}


		/// <summary>
		/// Strips the protocol specification like http:// and https:// from the url specified
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static string StripProtocolsFromUrl(string url)
		{
			var toReturn = url;
			if(!string.IsNullOrEmpty(toReturn))
			{
				var urlAsUri = new Uri(url);
				toReturn = urlAsUri.Host + urlAsUri.PathAndQuery + urlAsUri.Fragment;
			}

			return toReturn;
		}


		/// <summary>
		/// Sanitizes the string specified, which means it will prefix the string with https:// if there's no http:// or https:// at the start.
		/// </summary>
		/// <param name="toSanitize"></param>
		/// <returns></returns>
		public static string SanitizeUrl(string toSanitize)
		{
			var toReturn = toSanitize;
			if(!string.IsNullOrEmpty(toReturn))
			{
				if(!(toReturn.StartsWith("http://", true, CultureInfo.InvariantCulture) || toReturn.StartsWith("https://", true, CultureInfo.InvariantCulture)))
				{
					toReturn = "https://" + toReturn;
				}
			}

			return toReturn;
		}
	}
}