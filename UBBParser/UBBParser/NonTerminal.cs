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
using System.Collections.Generic;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// Generic implementation of a NonTerminal object, which is a result of 
	/// the token parse process. 
	/// </summary>
	public class NonTerminal
	{
		#region Class Member Declarations
		private List<IToken>		_tokens;					// List which holds all the tokens which form this nonterminal. 
		private NonTerminalType		_type;
		private int					_correspondingEndNTIndex;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="typeOfNonTerminal">The type of this nonterminal</param>
		public NonTerminal(NonTerminalType typeOfNonTerminal)
		{
			_type = typeOfNonTerminal;
			_tokens = new List<IToken>();
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets correspondingEndNTIndex. THis is the index of the corresponding end NonTerminal of the current Non Terminal.
		/// if the current nonterminal is an end nonterminal (CodeTextEnd, QuotedTextEnd etc.) or doesn't have an end NonTerminal, this index is the
		/// same as the index of the current NonTerminal. The index is the index in the parserResult list of nonterminals.
		/// </summary>
		public virtual int CorrespondingEndNTIndex
		{
			get
			{
				return _correspondingEndNTIndex;
			}
			set
			{
				_correspondingEndNTIndex = value;
			}
		}

		/// <summary>
		/// Gets the token collection.
		/// </summary>
		public List<IToken> Tokens
		{
			get
			{
				return _tokens;
			}
		}

		/// <summary>
		/// Gets / sets the nonterminal type
		/// </summary>
		public NonTerminalType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}
		#endregion
	}
}
