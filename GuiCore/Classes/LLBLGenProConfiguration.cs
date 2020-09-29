/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

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
using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Class to bind the LLBLGen Pro section in the appsettings.json values with for easy configuration.
	/// </summary>
	public class LLBLGenProConfiguration
	{
		/// <summary>
		/// Static instance holder, to avoid DI in all controllers which need it. 
		/// </summary>
		public static LLBLGenProConfiguration Current;


		public LLBLGenProConfiguration()
		{
			Current = this;
		}


		/// <summary>
		/// Makes sure the values read from the config are usable. 
		/// </summary>
		public void Sanitize()
		{
			if(!Enum.IsDefined(typeof(SqlServerCompatibilityLevel), this.SqlServerDQECompatibilityLevel))
			{
				this.SqlServerDQECompatibilityLevel = 6;
			}

			this.SqlServerCompatibilityAsEnum = (SqlServerCompatibilityLevel)this.SqlServerDQECompatibilityLevel;
		}


		/// <summary>
		/// Catalog name overwrites to use at runtime
		/// </summary>
		public Dictionary<string, string> CatalogNameOverwrites { get; set; } = new Dictionary<string, string>();
		/// <summary>
		/// The dqe compatibility level as read from the appsettings.json file
		/// </summary>
		public int SqlServerDQECompatibilityLevel { get; set; } = 6;
		/// <summary>
		/// The enum instance of SqlServerDQECompatibilityLevel
		/// </summary>
		public SqlServerCompatibilityLevel SqlServerCompatibilityAsEnum { get; private set; } = SqlServerCompatibilityLevel.SqlServer2012;
		/// <summary>
		/// Connection strings defined in the appsettings.json, if any.
		/// </summary>
		public Dictionary<string, string> ConnectionStrings { get; set; } = new Dictionary<string, string>();
	}
}