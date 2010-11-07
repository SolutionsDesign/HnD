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
using System.IO;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Xml;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// Generic UBB interpreter which interprets non-terminals, produced by the UBB parser and produces XML
	/// </summary>
	public class Interpreter
	{
		#region Class Member Declarations
		private MemoryStream		_outputStream;
		private List<NonTerminal>	_parseTree;
		private int					_nonTerminalIndex;
		private XmlWriter			_outputWriter;
		#endregion
		

		/// <summary>
		/// Ctor. Sets up the interpreter
		/// </summary>
		/// <param name="parseTree">List with non-terminals to interpret</param>
		public Interpreter(List<NonTerminal> parseTree)
		{
			_parseTree = parseTree;
			_nonTerminalIndex = 0;
			_outputStream = new MemoryStream(8192);	// reserve 8KB

			XmlWriterSettings outputSettings = new XmlWriterSettings();
			outputSettings.OmitXmlDeclaration=true;
			_outputWriter = XmlWriter.Create(_outputStream, outputSettings);
		}


		/// <summary>
		/// Walks the complete parse tree, and each non-terminal found is handled by its handler. The
		/// handler will check out the member parameters of this class if it can do something.
		/// </summary>
		/// <returns></returns>
		public XmlDocument Interpret()
		{
			// write rootnode, which has to be generaltext.
			_outputWriter.WriteStartElement("generaltext");

			while(_nonTerminalIndex < _parseTree.Count)
			{
				// main loop which handles top level general text elements.
				GeneralTextNTHandler();
				_nonTerminalIndex++;
			}

			// write end node of rootnode.
			_outputWriter.WriteEndElement();
			_outputWriter.Close();

			// done, convert the stream as an XmlDocument
			_outputStream.Seek(0, SeekOrigin.Begin);		// seek to start so load can read from the beginning.
			XmlDocument toReturn = new XmlDocument();
			toReturn.Load(_outputStream);
			_outputStream.Close();
			return toReturn;
		}


		/// <summary>
		/// Handles all nonterminals from the current position. This routine will
		/// return when the passed in nonterminal is seen. The passed in nonterminal is the current nonterminal after this routine ends.
		/// </summary>
		/// <param name="endType">The nonterminal type which marks the end of the tokenstream to walk.</param>
		private void InnerGeneralTextHandler(NonTerminalType endType)
		{
			while((_nonTerminalIndex < _parseTree.Count)&&(_parseTree[_nonTerminalIndex].Type != endType))
			{
				GeneralTextNTHandler();
				_nonTerminalIndex++;
			}
		}


		/// <summary>
		/// Handles all nonterminals from the current position. This routine will
		/// return when the passed in nonterminal is seen. The passed in nonterminal is the current nonterminal after this routine ends.
		/// </summary>
		/// <param name="endType">The nonterminal type which marks the end of the tokenstream to walk.</param>
		/// <param name="allowCrLf">If set to true, CrLf tokens are handled, otherwise skipped as normal text</param>
		/// <remarks>Routine used to handle the nonterminals inside code text and other nonterminals which only allow literal text inside themselves.
		/// This is done in a separate loop because not all nonterminals can be located inside code text for example, see syntaxis</remarks>
		private void InnerLiteralTextHandler(NonTerminalType endType, bool allowCrLf)
		{
			while((_nonTerminalIndex < _parseTree.Count) && (_parseTree[_nonTerminalIndex].Type != endType))
			{
				if(allowCrLf)
				{
					switch(_parseTree[_nonTerminalIndex].Type)
					{
						case NonTerminalType.CRLF:
							HandleCrLf();
							break;
						case NonTerminalType.Tab:
							HandleTab();
							break;
						default:
							HandleLiteralText(false);
							break;
					}
				}
				else
				{
					switch(_parseTree[_nonTerminalIndex].Type)
					{
						case NonTerminalType.Tab:
							HandleTab();
							break;
						default:
							HandleLiteralText(false);
							break;
					}
				}
				_nonTerminalIndex++;
			}
		}

		
		/// <summary>
		/// Handles all nonterminals from the current position. This routine will
		/// return when the passed in nonterminal is seen. The passed in nonterminal is the current nonterminal after this routine ends.
		/// </summary>
		/// <param name="endType">The nonterminal type which marks the end of the tokenstream to walk.</param>
		/// <remarks>Routine used to handle the nonterminals inside formatted text. This is done in a separate loop because not all nonterminals can 
		/// be located inside formatted text, see syntaxis</remarks>
		private void InnerFormattedTextHandler(NonTerminalType endType)
		{
			while((_nonTerminalIndex < _parseTree.Count) && (_parseTree[_nonTerminalIndex].Type != endType))
			{
				FormattedTextNTHandler();
				_nonTerminalIndex++;
			}
		}


		/// <summary>
		/// Handles all nonterminals inside a List nonterminal. It expects listitemstart/end pairs. 
		/// </summary>
		private void InnerListHandler()
		{
			while((_nonTerminalIndex < _parseTree.Count) && (_parseTree[_nonTerminalIndex].Type != NonTerminalType.ListEnd))
			{
				switch(_parseTree[_nonTerminalIndex].Type)
				{
					case NonTerminalType.ListItemStart:
						HandleListItemStart();
						break;
					default:
						// not-allowed nonterminal, like literal text. Ignore this nonterminal, so it's filtered out. 
						break;
				}
				_nonTerminalIndex++;
			}
		}


		/// <summary>
		/// Handles all nonterminals from the current position for formatted text inside nonterminals which can only handle formatted text. This routine will
		/// return when an end element is seen of a nonterminal which can be part of FormattedText. See syntax.
		/// </summary>
		private void FormattedTextNTHandler()
		{
			switch(_parseTree[_nonTerminalIndex].Type)
			{
				case NonTerminalType.BoldTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.ColoredTextStart:
					HandleColoredTextStart();
					break;
				case NonTerminalType.CRLF:
					HandleCrLf();
					break;
				case NonTerminalType.EmailAddress:
					HandleEmailAddress();
					break;
				case NonTerminalType.ItalicTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.LiteralText:
					HandleLiteralText();
					break;
				case NonTerminalType.OfftopicTextStart:
					HandleOfftopicTextStart();
					break;
				case NonTerminalType.SizedTextStart:
					HandleSizedTextStart();
					break;
				case NonTerminalType.SmileyAngry:
				case NonTerminalType.SmileyConfused:
				case NonTerminalType.SmileyCool:
				case NonTerminalType.SmileyDissapointed:
				case NonTerminalType.SmileyEmbarrassed:
				case NonTerminalType.SmileyLaugh:
				case NonTerminalType.SmileyRegular:
				case NonTerminalType.SmileySad:
				case NonTerminalType.SmileyShocked:
				case NonTerminalType.SmileyTongue:
				case NonTerminalType.SmileyWink:
					HandleSmiley();
					break;
				case NonTerminalType.StrikedTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.Tab:
					HandleTab();
					break;
				case NonTerminalType.UnderlinedTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.URI:
					HandleUri();
					break;
				default:
					// error in this scope. This means that a tag is placed inside another tag where it's not allowed. 
					// the token is now pushed as normal literal text 
					HandleLiteralText();
					break;
			}
		}


		/// <summary>
		/// Looks at the non-terminal at position _nonTerminalIndex of the parse result array list and calls the handler.
		/// </summary>
		private void GeneralTextNTHandler()
		{
			switch(_parseTree[_nonTerminalIndex].Type)
			{
				case NonTerminalType.BoldTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.CodeTextStart:
					HandleCodeTextStart();
					break;
				case NonTerminalType.ColoredTextStart:
					HandleColoredTextStart();
					break;
				case NonTerminalType.CRLF:
					HandleCrLf();
					break;
				case NonTerminalType.EmailAddress:
					HandleEmailAddress();
					break;
				case NonTerminalType.ImageStart:
					HandleImageStart();
					break;
				case NonTerminalType.ItalicTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.ListStart:
					HandleListStart();
					break;
				case NonTerminalType.LiteralText:
					HandleLiteralText();
					break;
				case NonTerminalType.OfftopicTextStart:
					HandleOfftopicTextStart();
					break;
				case NonTerminalType.QuotedTextStart:
					HandleQuotedTextStart();
					break;
				case NonTerminalType.SizedTextStart:
					HandleSizedTextStart();
					break;
				case NonTerminalType.SmileyAngry:
				case NonTerminalType.SmileyConfused:
				case NonTerminalType.SmileyCool:
				case NonTerminalType.SmileyDissapointed:
				case NonTerminalType.SmileyEmbarrassed:
				case NonTerminalType.SmileyLaugh:
				case NonTerminalType.SmileyRegular:
				case NonTerminalType.SmileySad:
				case NonTerminalType.SmileyShocked:
				case NonTerminalType.SmileyTongue:
				case NonTerminalType.SmileyWink:
					HandleSmiley();
					break;
				case NonTerminalType.StrikedTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.Tab:
					HandleTab();
					break;
				case NonTerminalType.UnderlinedTextStart:
					HandleSimpleFormattedTextStart();
					break;
				case NonTerminalType.URI:
					HandleUri();
					break;
				case NonTerminalType.URLStart:
					HandleUrlStart();
					break;
				default:
					// no handler found/needed. Skip 
					break;
			}
		}


		/// <summary>
		/// Handles a CRLF nonterminal. 
		/// </summary>
		private void HandleCrLf()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			_outputWriter.WriteStartElement("br");
			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles the tab nonterminal
		/// </summary>
		private void HandleTab()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			_outputWriter.WriteStartElement("tab");
			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles quoted text start. 
		/// </summary>
		private void HandleQuotedTextStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			// current contains the tokens. A quoted text start nonterminal always contains one of the following token sets
			// 0      1    2 3      4  
			// [quote nick = string ]  
			//
			// or:
			// 
			// 0    1 2
			// [quote ]

			bool nickSpecified = current.Tokens.Count == 5;
			string nick = string.Empty;
			if(nickSpecified)
			{
				nick = StripFromQuotes(current.Tokens[3].LiteralMatchedTokenText);
			}
			
			_outputWriter.WriteStartElement("quote");
			if(nickSpecified)
			{
				_outputWriter.WriteAttributeString("nick", nick);
			}

			_nonTerminalIndex++;
			InnerGeneralTextHandler(NonTerminalType.QuotedTextEnd);

			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles url start. This handler handles the complete [url...]URI[/url] sequence.
		/// </summary>
		private void HandleUrlStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			string url = string.Empty;
			// current contains the tokens. An url start nonterminal always contains one of the following token sets
			// 0    1           2 3      4  5   6
			// [url description = string ]  URI [/url]
			//
			// or:
			// 
			// 0    1 2   3
			// [url ] URI [/url]

			bool descriptionSpecified = current.Tokens.Count == 7;
			string descriptionText = string.Empty;
			if(descriptionSpecified)
			{
				descriptionText = StripFromQuotes(current.Tokens[3].LiteralMatchedTokenText);
				url = current.Tokens[5].LiteralMatchedTokenText;
			}
			else
			{
				url = current.Tokens[2].LiteralMatchedTokenText;
			}

			_outputWriter.WriteStartElement("url");
			if(descriptionSpecified)
			{
				_outputWriter.WriteAttributeString("description", descriptionText);
			}
			_outputWriter.WriteString(url);
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles image start. This handler handles the complete [img...]ImageUrl[/img] sequence.
		/// </summary>
		private void HandleImageStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			string imageSrc = string.Empty;
			// current contains the tokens. An image start nonterminal always contains one of the following token sets
			// 0    1   2 3      4  5        6
			// [img alt = string ]  ImageURL [/img]
			//
			// or:
			// 
			// 0    1 2        3
			// [img ] ImageURL [/img]

			bool altSpecified = current.Tokens.Count == 7;
			string altText = string.Empty;
			if(altSpecified)
			{
				altText = StripFromQuotes(current.Tokens[3].LiteralMatchedTokenText);
				imageSrc = current.Tokens[5].LiteralMatchedTokenText;
			}
			else
			{
				imageSrc = current.Tokens[2].LiteralMatchedTokenText;
			}

			_outputWriter.WriteStartElement("image");
			if(altSpecified)
			{
				_outputWriter.WriteAttributeString("alt", altText);
			}
			_outputWriter.WriteString(imageSrc);
			_outputWriter.WriteEndElement();
		}



		/// <summary>
		/// Handles List start. 
		/// </summary>
		private void HandleListStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			// current contains the tokens. A list start nonterminal always contains one of the following token sets
			// 0     1    2 3      4 
			// [list type = string ]
			//
			// or:
			// 
			// 0    1
			// [img ]

			bool typeSpecified = current.Tokens.Count == 5;
			string listType = string.Empty;
			if(typeSpecified)
			{
				string listTypeAsString = StripFromQuotes(current.Tokens[3].LiteralMatchedTokenText).ToUpperInvariant();
				switch(listTypeAsString)
				{
					case "UL":
					case "OL":
						listType = listTypeAsString;
						break;
					default:
						listType = "UL";
						break;
				}
			}

			_outputWriter.WriteStartElement("list");
			if(typeSpecified)
			{
				_outputWriter.WriteAttributeString("type", listType);
			}
			_outputWriter.WriteStartElement("listitems");

			_nonTerminalIndex++;

			// handle list items.
			InnerListHandler();

			_outputWriter.WriteEndElement(); // listitems
			_outputWriter.WriteEndElement(); // list
		}


		/// <summary>
		/// Handles colored text start. colored text contains a token which has to be a 6character long hex string. If the value is off, black is used.
		/// </summary>
		private void HandleColoredTextStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			string defaultColor = "000000";
			NonTerminalType endType = NonTerminalType.ColoredTextEnd;
			// current contains the tokens. A color start nonterminal always contains the following tokens 
			// 0      1     2 3
			// [color value = string ]

			string colorValueAsString = StripFromQuotes(current.Tokens[3].LiteralMatchedTokenText);
			if(colorValueAsString.Length != 6)
			{
				colorValueAsString = defaultColor;
			}

			_outputWriter.WriteStartElement("color");
			_outputWriter.WriteAttributeString("value", colorValueAsString);

			_nonTerminalIndex++;

			// as the text inside a formatted text block has limited scope, we have to call a special handler. 
			InnerFormattedTextHandler(endType);

			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles the EmailAddress nonterminal. 
		/// </summary>
		private void HandleEmailAddress()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];
			// current contains the tokens. An emailaddress nonterminal always contains just one token, the actual emailaddress
			string emailaddress = current.Tokens[0].LiteralMatchedTokenText;
			_outputWriter.WriteElementString("emailaddress", emailaddress);
		}


		/// <summary>
		/// Handles the literal text nonterminal.
		/// </summary>
		private void HandleLiteralText()
		{
			HandleLiteralText(true);
		}


		/// <summary>
		/// Handles the literal text nonterminal.
		/// </summary>
		/// <param name="emitSurroundingElement">if set to true, it will emit the surrounding element literaltext as well. </param>
		private void HandleLiteralText(bool emitSurroundingElement)
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];
			if(emitSurroundingElement)
			{
				_outputWriter.WriteStartElement("literaltext");
			}
			foreach(IToken token in current.Tokens)
			{
				// simply dump the token's literal text as literal text into the output
				string text = token.LiteralMatchedTokenText;
				_outputWriter.WriteElementString("literaltextelement", text);
			}
			if(emitSurroundingElement)
			{
				_outputWriter.WriteEndElement();
			}
		}


		/// <summary>
		/// Handles code text start. 
		/// </summary>
		private void HandleCodeTextStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			NonTerminalType endType = NonTerminalType.CodeTextEnd;
			_outputWriter.WriteStartElement("code");

			_nonTerminalIndex++;

			// as the text inside a formatted text block has limited scope, we have to call a special handler. 
			InnerLiteralTextHandler(endType, true);

			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles offtopic text start. 
		/// </summary>
		private void HandleOfftopicTextStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			_outputWriter.WriteStartElement("offtopic");

			_nonTerminalIndex++;

			// as the text inside a formatted text block has limited scope, we have to call a special handler. 
			InnerFormattedTextHandler(NonTerminalType.OfftopicTextEnd);

			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles listitem start. 
		/// </summary>
		private void HandleListItemStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			_outputWriter.WriteStartElement("listitem");

			_nonTerminalIndex++;

			InnerGeneralTextHandler(NonTerminalType.ListItemEnd);

			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles sized text start. Sized text contains a token which has to be a 1 character long string. If the value is wrong, 3 (default) is used
		/// </summary>
		private void HandleSizedTextStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			string defaultSize = "3";
			NonTerminalType endType = NonTerminalType.SizedTextEnd;
			// current contains the tokens. A sized text start nonterminal always contains the following tokens 
			// 0     1     2 3
			// [size value = string ]

			string sizedValueAsString = StripFromQuotes(current.Tokens[3].LiteralMatchedTokenText);
			if((sizedValueAsString.Length != 1) && !Char.IsDigit(sizedValueAsString, 0))
			{
				sizedValueAsString = defaultSize;
			}

			_outputWriter.WriteStartElement("size");
			_outputWriter.WriteAttributeString("value", sizedValueAsString);

			_nonTerminalIndex++;

			// as the text inside a formatted text block has limited scope, we have to call a special handler. 
			InnerFormattedTextHandler(endType);

			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles a smiley nonterminal.
		/// </summary>
		private void HandleSmiley()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];
			string tag = "smileyregular";
			switch((Token)current.Tokens[0].TokenID)
			{
				case Token.SmileyAngry:
					tag = "smileyangry";
					break;
				case Token.SmileyConfused:
					tag = "smileyconfused";
					break;
				case Token.SmileyCool:
					tag = "smileycool";
					break;
				case Token.SmileyDissapointed:
					tag = "smileydissapointed";
					break;
				case Token.SmileyEmbarrassed:
					tag = "smileyembarrassed";
					break;
				case Token.SmileyLaugh:
					tag = "smileylaugh";
					break;
				case Token.SmileyRegular:
					tag = "smileyregular";
					break;
				case Token.SmileySad:
					tag = "smileysad";
					break;
				case Token.SmileyShocked:
					tag = "smileyshocked";
					break;
				case Token.SmileyTongue:
					tag = "smileytongue";
					break;
				case Token.SmileyWink:
					tag = "smileywink";
					break;
			}

			_outputWriter.WriteStartElement(tag);
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Handles the URI nonterminal. 
		/// </summary>
		private void HandleUri()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];
			// current contains the tokens. An URI nonterminal always contains just one token, the actual URI
			string uri = current.Tokens[0].LiteralMatchedTokenText;
			_outputWriter.WriteElementString("url", uri);
		}


		/// <summary>
		/// Handles simply formatted text start. Simple formatted text is text surrounded with bold,italic, striked or underlined. 
		/// </summary>
		private void HandleSimpleFormattedTextStart()
		{
			NonTerminal current = _parseTree[_nonTerminalIndex];

			string tag = string.Empty;
			NonTerminalType endType = NonTerminalType.BoldTextEnd;
			switch(current.Type)
			{
				case NonTerminalType.BoldTextStart:
					tag = "bold";
					endType = NonTerminalType.BoldTextEnd;
					break;
				case NonTerminalType.ItalicTextStart:
					tag = "italic";
					endType = NonTerminalType.ItalicTextEnd;
					break;
				case NonTerminalType.StrikedTextStart:
					tag = "striked";
					endType = NonTerminalType.StrikedTextEnd;
					break;
				case NonTerminalType.UnderlinedTextStart:
					tag = "underlined";
					endType = NonTerminalType.UnderlinedTextEnd;
					break;
				default:
					// error
					return;
			}

			_outputWriter.WriteStartElement(tag);

			_nonTerminalIndex++;

			// as the text inside a formatted text block has limited scope, we have to call a special handler. 
			InnerFormattedTextHandler(endType);

			// done
			_outputWriter.WriteEndElement();
		}


		/// <summary>
		/// Strips the passed in string from quotes (double or single)
		/// </summary>
		/// <param name="toStrip">To strip.</param>
		/// <returns>toStrip without the surrounding quotes.</returns>
		private string StripFromQuotes(string toStrip)
		{
			if(toStrip.Length < 3)
			{
				return string.Empty;
			}
			return toStrip.Substring(1, toStrip.Length - 2);
		}

	}
}
