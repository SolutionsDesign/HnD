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
	/// General Enumeration of build in tokens, which are tokens which should always have these IDs
	/// </summary>
	public enum BuildInTokenID:int
	{
		/// <summary>
		/// TokenID for the marking of EOF or '$', which means the end of the tokenstream. No special actions required. 
		/// </summary>
		EOF=0,
		/// <summary>
		/// TokenID for the literal unquoted string, i.e. the literal text which doesn't match with any token definition.
		/// All parsers using this Lexical analyzer should support this token. It contains all scanned characters which 
		/// didn't lead to a match with the passed in set of tokendefinitions.
		/// </summary>
		UntokenizedLiteralString
	}


	/// <summary>
	/// Tokendefinitions for this parser
	/// </summary>
	public enum Token:int
	{
		EOF=0,						// Mandatory First TokenID
		UntokenizedLiteralString,	//  , Mandatory Second TokenID
		AltTerminal,				// 	'alt'
		Assignment,					//	'='
		BoldTextStartTag,			// 	'[b]'
		BoldTextEndTag,				// 	'[/b]'
		CodeTextStartTag,			// 	'[code'
		CodeTextEndTag,				// 	'[/code]'
		ColoredTextStartTag,		// 	'[color'
		ColoredTextEndTag,			// 	'[/color]'
		CR,							//  \r
		DescriptionTerminal,		// 	'description'
		EmailAddress,				// 	any legitimate emailaddress representation
		ImageStartTag,				// 	'[img'
		ImageEndTag,				// 	'[/img]'
		ImageURL,					// 	URI starting with http:// and ending with .png, .jpg, .gif
		ItalicTextStartTag,			// 	'[i]'
		ItalicTextEndTag,			// 	'[/i]'
		ListEndTag,					// 	'[/list]'
		ListItemEndTag,				// 	'[/*]'
		ListItemStartTag,			// 	'[*]'
		ListStartTag,				// 	'[list'
		LF,							//  \n
		NickTerminal,				//  'nick'
		OfftopicTextStartTag,		// 	'[offtopic]'
		OfftopicTextEndTag,			// 	'[/offtopic]'
		QuotedString,				// 	"text"
		QuotedTextStartTag,			//  '[quote'
		QuotedTextEndTag,			// 	'[/quote]'
		SizedTextStartTag,			// 	'[size'
		SizedTextEndTag,			// 	'[/size]'
		SingleQuotedNumericString,	//  ''0', '1', ..., '9''
		SmileyLaugh,				// 	':D'
		SmileyAngry,				// 	':('
		SmileyRegular,				// 	':)'
		SmileyWink,					//  ';)'
		SmileyCool,					//	'8)'
		SmileyTongue,				//  ':P'
		SmileyConfused,				//	':?'
		SmileyShocked,				//	':o'
		SmileyDissapointed,			//	':/'
		SmileySad,					//	';('
		SmileyEmbarrassed,			//	':!'
		StrikedTextStartTag,		// 	'[s]'
		StrikedTextEndTag,			// 	'[/s]'
		Tab,						//  '    ' or '\t'
		TagCloseBracket,			// 	']'
		TypeTerminal,				// 	'type'
		UnderlinedTextStartTag,		// 	'[u]'
		UnderlinedTextEndTag,		// 	'[/u]'
		URLStartTag,				// 	'[url '
		URLEndTag,					// 	'[/url]'
		URI,						// 	URL starting with http://, https:// or www
		ValueTerminal,				// 	'value'
		WhiteSpace					//  ' '
		// insert more smiley tokens here
	}


	/// <summary>
	/// Non-terminal type definitions. These values are used to specify the nonterminal type of a
	/// NonTerminal object. The interpreter can then handle the nonterminal objects according
	/// to their nonterminal Type.
	/// </summary>
	public enum NonTerminalType:int
	{
		BoldTextStart,
		BoldTextEnd,
		CodeTextStart,
		CodeTextEnd,
		ColoredTextStart,
		ColoredTextEnd,
		CRLF,
		EmailAddress,
		ImageStart,	
		ImageEnd,
		ImageURL,
		ItalicTextStart,
		ItalicTextEnd,
		ListStart,
		ListItemStart,
		ListItemEnd,
		ListEnd,
		LiteralText,
		OfftopicTextStart,
		OfftopicTextEnd,
		QuotedTextStart,
		QuotedTextEnd,
		SizedTextStart,
		SizedTextEnd,
		SmileyLaugh,
		SmileyAngry,		
		SmileyRegular,
		SmileyWink,	
		SmileyCool,	
		SmileyTongue,
		SmileyConfused,
		SmileyShocked,
		SmileyDissapointed,
		SmileySad,
		SmileyEmbarrassed,
		StrikedTextStart,
		StrikedTextEnd,
		Tab,
		UnderlinedTextStart,
		UnderlinedTextEnd,
		URLStart,
		URLEnd,
		URI,
		// add more here
		AmountOfNonTerminalTypes
	}
}
