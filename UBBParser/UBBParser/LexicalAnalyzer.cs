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
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// Lexical Analyzer class. A parser creates an instance of this class and uses this class to construct
	/// a list of tokens to parse.
	/// </summary>
	public class LexicalAnalyzer
	{

		/// <summary>
		/// Starts the tokenization of the string ToTokenize and returns the tokenization as a FIFO Queue
		/// This method will throw exceptions when necessary input isn't useable:
		/// </summary>
		/// <exception cref="NoTokenDefinitionsSpecifiedException">Thrown when the Tokenize method is called and there are
		/// no TokenDefinitions found</exception>
		/// <param name="stringToTokenize">The string which has to be tokenized. If stringToTokenize is empty, an empty Queue object
		/// is returned.</param>
		/// <param name="removeOverlappedTokens">Flag to signal the tokenizer to remove overlapped tokens found. This is necessary
		/// when your parser logic shouldn't be bothered with overlapped tokens, like: (UBB syntaxis + strings) "this [b]is[/b] overlapping"
		/// will result in a string token (if specified) and 2 tokens of the UBB syntax: [b] and [/b]. If you don't want these last
		/// 2 tokens to appear, since they're included in another token, the string token, set removeOverlappedTokens to true</param>
		/// <returns>Queue with the tokens or null if an internal error occured.</returns>
		public Queue<IToken> Tokenize(string stringToTokenize, bool removeOverlappedTokens)
		{
			Queue<IToken> resultTokenList;				// Queue list of IToken objects.
			
			try
			{
				// initialize and start tokenizer
				Tokenizer tokenizerObject = new Tokenizer();
				tokenizerObject.ToTokenize = stringToTokenize;
				tokenizerObject.RemoveOverlappedTokens = removeOverlappedTokens;
				
				// start it.
				resultTokenList = tokenizerObject.Tokenize();
				
				// return result
				return resultTokenList;
			}
			catch(NoTokenDefinitionsSpecifiedException)
			{
				// bubble
				throw;
			}
			catch
			{
				// other error, return null
				return null;
			}
		}
	}
}
