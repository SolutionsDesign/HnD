/*
	This file is part of HnD.
	HnD is (c) 2002-2006 Solutions Design.
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
using System.Text.RegularExpressions;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// UBBTokenDefinition. Implements ITokenDefinition
	/// </summary>
	public class UBBTokenDefinition : ITokenDefinition
	{
		#region Class Member Declarations
		private int		_tokenID;
		private Regex	_matchingRegularExpression;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public UBBTokenDefinition()
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		public UBBTokenDefinition(int tokenID, string matchingRegularExpression, RegexOptions regularExpressionOptions)
		{
			_tokenID = tokenID;
			_matchingRegularExpression = new Regex(matchingRegularExpression, regularExpressionOptions);
		}
		

		/// <summary>
		/// Creates a new token object using this definition and prefills it. 
		/// </summary>
		/// <returns>An TDLToken token</returns>
		public IToken CreateTokenFromDefinition()
		{
			UBBToken toReturn = new UBBToken();
			toReturn.RelatedTokenDefinition = this;
			return toReturn;
		}


		#region Class Property Definitions
		/// <summary>
		/// gets / sets the tokenid for this tokenobject
		/// </summary>
		public int TokenID
		{
			get { return _tokenID; }
			set { _tokenID = value; }
		}
			
		/// <summary>
		/// gets/ sets the matching regular expression object
		/// </summary>
		public Regex MatchingRegularExpression
		{
			get { return _matchingRegularExpression; }
			set { _matchingRegularExpression = value; }
		}
		#endregion

	}
}
