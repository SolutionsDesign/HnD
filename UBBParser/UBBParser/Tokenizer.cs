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
	/// Tokenizer class. This class tokenizes the given input using the given tokentables to a queue of tokens. 
	/// </summary>
	internal class Tokenizer
	{
		#region Class Member Declarations
		private string					_stringToTokenize;					// The input which has to be tokenized.
		private	ITokenDefinition		_untokenizedLiteralStringToken;	// The token definition for the UntokenizedLiteralString token.
		private	ITokenDefinition		_eofToken;						// The token definition for the EOF token.
		private bool					_removeOverlappedTokens;
		#endregion

		
		/// <summary>
		/// CTor.
		/// </summary>
		public Tokenizer()
		{
			_stringToTokenize = String.Empty;
		}


		/// <summary>
		/// Starts the tokenization of the value set into ToTokenize and will return a Queue with IToken objects
		/// </summary>
		/// <exception cref="NoTokenDefinitionsSpecifiedException">Thrown when no TokenDefinition list is specified</exception>
		/// <returns>Queue with IToken objects which represent a tokenized version of the inputstring ToTokenize</returns>
		public Queue<IToken> Tokenize()
		{
			if(Parser.TokenDefinitions == null)
			{
				throw new NoTokenDefinitionsSpecifiedException("No Token Definitions Found.");
			}

			foreach(ITokenDefinition currentTokenDefinition in Parser.TokenDefinitions)
			{
				if(currentTokenDefinition.TokenID == (int)BuildInTokenID.UntokenizedLiteralString)
				{
					_untokenizedLiteralStringToken = currentTokenDefinition;
					continue;
				}
				if(currentTokenDefinition.TokenID == (int)BuildInTokenID.EOF)
				{
					_eofToken = currentTokenDefinition;
					continue;
				}
			}

			// all clear. Now walk all tokendefinitions for their regular expressions and collect MatchCollections of these
			// regular expressions. Store all found tokens in a sorted list, with the starting char as the key. These will
			// be then sorted on that key and based on the sorting result the result queue is build. When regular expressions
			// are build badly, overlapping tokens can be found. The parser should be handling this. 

			// create sorted list of result tokens
			SortedList<int, IToken> tokensFound = new SortedList<int, IToken>(_stringToTokenize.Length / 10);

			// start the tokenization process
			// walk all token definitions. Match all regular expressions with the string to tokenize.
			// all matches are tokenized into tokens belonging with the token definition
			// All tokens are then added to the sorted list with the index as the key
			foreach(ITokenDefinition currentToken in Parser.TokenDefinitions)
			{
				if((currentToken.TokenID == (int)BuildInTokenID.UntokenizedLiteralString) ||
					(currentToken.TokenID == (int)BuildInTokenID.EOF))
				{
					// skip this token definition
					continue;
				}

				MatchCollection matchesFound = currentToken.MatchingRegularExpression.Matches(_stringToTokenize);
				if(matchesFound.Count > 0)
				{
					// found matches, convert the matches to tokens, if there is not already a token present at
					// the current position. This is necessary since we're using regular expressions. 
					foreach(Match matchedSnippet in matchesFound)
					{
						// create a token using the factory object. TokenID and RelatedTokenDefinition are already filled in.
						IToken toAdd = currentToken.CreateTokenFromDefinition();
						toAdd.LiteralMatchedTokenText = matchedSnippet.Value;
						toAdd.StartIndexInInputStream = matchedSnippet.Index;

						if(!tokensFound.ContainsKey(matchedSnippet.Index))
						{
							// no token found on this spot. Add it.
							// add to sorted list
							tokensFound.Add(matchedSnippet.Index, toAdd);
						}
						else
						{
							// it does have already a token on the spot. If that token is longer than the current token,
							// keep it, otherwise replace the token with this token.
							if(tokensFound[matchedSnippet.Index].LiteralMatchedTokenText.Length < toAdd.LiteralMatchedTokenText.Length)
							{
								tokensFound[matchedSnippet.Index] = toAdd;
							}
						}
					}
				}
			}

			// now walk the resulted sorted list. Insert untokenizedliteralstring tokens for all unmatched characters in the
			// inputstream. Do this at the same time as we transform the sorted list into a queue
			Queue<IToken> toReturn = new Queue<IToken>(tokensFound.Count);

			int currentIndex = 0;
			int firstIndexWithoutOverlap = 0;
			//for(int i = 0; i < tokensFound.Count; i++)
			foreach(KeyValuePair<int, IToken> pair in tokensFound)
			{
				IToken currentToken = pair.Value;

				if(_removeOverlappedTokens)
				{
					// check if the index of this token falls inside another token. This is checked
					// using iFirstIndxWithoutOverlap
					if(currentToken.StartIndexInInputStream < firstIndexWithoutOverlap)
					{
						// this token is overlapped by another token. Skip it, it will then
						// not be added to the queue
						continue;
					}
				}
				// check the index of the token with the current index. If there is a difference, the
				// snippet formed by the difference is an UntokenizedLiteralString token.
				if(currentIndex < currentToken.StartIndexInInputStream)
				{
					// there is difference, add an UntokenizedLiteralString token first. 
					IToken untokenizedLiteralString = _untokenizedLiteralStringToken.CreateTokenFromDefinition();
					untokenizedLiteralString.LiteralMatchedTokenText = _stringToTokenize.Substring(currentIndex, (currentToken.StartIndexInInputStream - currentIndex));
					untokenizedLiteralString.StartIndexInInputStream = currentIndex;
					// add it directly to queue
					toReturn.Enqueue(untokenizedLiteralString);
				}
				currentIndex = currentToken.StartIndexInInputStream + currentToken.LiteralMatchedTokenText.Length;
				firstIndexWithoutOverlap = currentIndex;
				toReturn.Enqueue(currentToken);
			}

			// check if there is an unmatched snippet behind the last token found...
			if(currentIndex < _stringToTokenize.Length)
			{
				// there is difference, add an UntokenizedLiteralString token first. 
				IToken untokenizedLiteralString = _untokenizedLiteralStringToken.CreateTokenFromDefinition();
				untokenizedLiteralString.LiteralMatchedTokenText = _stringToTokenize.Substring(currentIndex, (_stringToTokenize.Length - currentIndex));
				untokenizedLiteralString.StartIndexInInputStream = currentIndex;
				// add it directly to queue
				toReturn.Enqueue(untokenizedLiteralString);
			}


			// Add the EOF token, by definition token ID 0, to the queue at the end.
			IToken eofToken = _eofToken.CreateTokenFromDefinition();
			toReturn.Enqueue(eofToken);

			// Done, return the queue
			return toReturn;
		}
		
		
		#region Class Property Declarations
		/// <summary>
		/// If true, will remove encapsulated tokens found. For example ForEach contains 'For'. When RemoveOverlappedTokens is true, 'For' would
		/// be removed as a found token.
		/// </summary>
		public bool RemoveOverlappedTokens
		{
			set { _removeOverlappedTokens = value; }
		}
		
		/// <summary>
		/// Sets the string to tokenize
		/// </summary>
		public string ToTokenize
		{
			set	{ _stringToTokenize = value; }
		}
		#endregion
		
	}
}
