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
using System.Collections;
using System.Text.RegularExpressions;

namespace SD.HnD.UBBParser
{
	#region Interface definitions
	/// <summary>
	/// Interface for the TokenDefinition class. 
	/// </summary>
	public interface ITokenDefinition
	{
		/// <summary>
		/// // Token factory, which will create a tokenobject from this definition. Should fill in TokenID and RelatedTokenDefinition
		/// </summary>
		/// <returns>Token definition</returns>
		IToken	CreateTokenFromDefinition();	

		/// <summary>
		/// Gets or sets the token ID.
		/// </summary>
		/// <value></value>
		int		TokenID	{get; set;}
		/// <summary>
		/// Gets or sets the matching regular expression.
		/// </summary>
		/// <value></value>
		Regex	MatchingRegularExpression {get; set;}
	}

	/// <summary>
	/// Interface for the Token class. 
	/// </summary>
	public interface IToken
	{
		/// <summary>
		/// // masquerading property to retrieve data from RelatedTokenDefinition
		/// </summary>
		int	TokenID {get; }		
		/// <summary>
		/// Gets or sets the literal matched token text.
		/// </summary>
		/// <value></value>
		string LiteralMatchedTokenText {get; set;}
		/// <summary>
		/// Gets or sets the related token definition.
		/// </summary>
		/// <value></value>
		ITokenDefinition RelatedTokenDefinition {get; set;}
		/// <summary>
		/// Gets or sets the start index in input stream.
		/// </summary>
		/// <value></value>
		int	StartIndexInInputStream {get; set;}
	}
	#endregion
}