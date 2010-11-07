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

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// Implements the IToken interface for the UBB parser for HnD
	/// </summary>
	public class UBBToken : IToken
	{
		#region Class Member Declarations
		private UBBTokenDefinition		_relatedTokenDefinition;
		private	string					_literalMatchedTokenText;
		private int						_startIndexInInputStream;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public UBBToken()
		{
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the token ID.
		/// </summary>
		/// <value></value>
		public int TokenID
		{
			get { return _relatedTokenDefinition.TokenID; }
		}
			
		/// <summary>
		/// Gets or sets the literal matched token text.
		/// </summary>
		/// <value></value>
		public string LiteralMatchedTokenText
		{
			get { return _literalMatchedTokenText; }
			set { _literalMatchedTokenText = value; }
		}
			
		/// <summary>
		/// Gets or sets the related token definition.
		/// </summary>
		/// <value></value>
		public ITokenDefinition RelatedTokenDefinition
		{
			get { return _relatedTokenDefinition; }
			set { _relatedTokenDefinition = (UBBTokenDefinition)value; }
		}
			
		/// <summary>
		/// Gets or sets the start index in input stream.
		/// </summary>
		/// <value></value>
		public int StartIndexInInputStream
		{
			get { return _startIndexInInputStream; }
			set { _startIndexInInputStream = value; }
		}
		#endregion

	}
}
