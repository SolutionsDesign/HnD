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
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Configuration;
using System.Xml.Xsl;
using System.IO;
using System.Text.RegularExpressions;

using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

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
		/// Loads the noise words into hashtable. Noise words are words which can be ignored during message indexing and searches.
		/// </summary>
		/// <param name="dataFilesPath">Path to the datafiles folder</param>
		/// <returns>A hashtable with all the noisewords found in the file Datafiles/Noise.txt</returns>
		public static Hashtable LoadNoiseWordsIntoHashtable(string dataFilesPath)
		{
			string fullPath = Path.Combine(dataFilesPath, "Noise.txt");
			StreamReader reader = new StreamReader(fullPath);
			bool eofReached = false;
			Hashtable noiseWords = new Hashtable(256);
			while(!eofReached)
			{
				string noiseWord = reader.ReadLine();
				eofReached=(noiseWord==null);
				if(!eofReached)
				{
					if(!noiseWords.ContainsKey(noiseWord))
					{
						noiseWords.Add(noiseWord, null);
					}
				}
			}

			return noiseWords;
		}
	}
}