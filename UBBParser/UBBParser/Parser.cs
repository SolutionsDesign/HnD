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
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// UBB Parser. Parses the input passed in into tokens which are interpreted by the UBB Interpreter
	/// </summary>
	public class Parser
	{
		#region Static member declarations
		/// <summary>
		/// Static declared tokendefinition collection. As token regex objects are threadsafe, re-creating them is not necessary.
		/// </summary>
		public static List<ITokenDefinition> TokenDefinitions = new List<ITokenDefinition>();
		#endregion

		#region Class Member Declarations
		private List<NonTerminal>	_nonTerminalStream;
		private string				_stringToParse;
		private Queue<IToken>		_tokenStream;
		private Dictionary<NonTerminalType, Stack<NonTerminal>> _startNTStacks;		// per non-terminal which needs it, there's a stack of start nonterminals for matching end NTs
		#endregion


		/// <summary>
		/// Initializes the <see cref="Parser"/> class' static members, which is the tokendefinition collection
		/// </summary>
		static Parser()
		{
			CreateTokenDefinitions();
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="stringToParse">the text string to parse.</param>
		public Parser(string stringToParse)
		{
			_nonTerminalStream = new List<NonTerminal>();
			_stringToParse = stringToParse;
			_startNTStacks = new Dictionary<NonTerminalType, Stack<NonTerminal>>();
		}


		/// <summary>
		/// Starts the parse process
		/// </summary>
		/// <returns>List object with nonterminal objects. This can be fed to the interpreter.</returns>
		public List<NonTerminal> StartParseProcess()
		{
			_nonTerminalStream.Clear();
			_startNTStacks.Clear();
			
			// tokenize the string
			LexicalAnalyzer lex = new LexicalAnalyzer();
			_tokenStream = lex.Tokenize(_stringToParse, true);

			// parse the tokenstream into _nonTerminals for the interpreter.
			ParseTokens();
			return _nonTerminalStream;
		}


		/// <summary>
		/// Parses the token stream into nonterminal objects. Uses simple LL(1) algo.
		/// Fills _nonTerminalStream;
		/// </summary>
		private void ParseTokens()
		{
			IToken literalTextToken = null;

			// parse the tokens
			bool eofFound = false;
			while((_tokenStream.Count > 0)&&!eofFound)
			{
				IToken currentToken = (IToken)_tokenStream.Peek();

				int index = 0;
				switch((Token)currentToken.TokenID)
				{
					case Token.EOF:
						// done 
						eofFound = true;
						break;
					case Token.BoldTextStartTag:
					case Token.BoldTextEndTag:
					case Token.CodeTextStartTag:
					case Token.CodeTextEndTag:
					case Token.ColoredTextStartTag:
					case Token.ColoredTextEndTag:
					case Token.LF:
					case Token.EmailAddress:
					case Token.ImageStartTag:
					case Token.ImageURL:
					case Token.ItalicTextStartTag:
					case Token.ItalicTextEndTag:
					case Token.ListEndTag:
					case Token.ListItemEndTag:
					case Token.ListItemStartTag:
					case Token.ListStartTag:
					case Token.OfftopicTextStartTag:
					case Token.OfftopicTextEndTag:
					case Token.QuotedTextStartTag:
					case Token.QuotedTextEndTag:
					case Token.SizedTextStartTag:
					case Token.SizedTextEndTag:
					case Token.SmileyLaugh:
					case Token.SmileyAngry:
					case Token.SmileyRegular:
					case Token.SmileyWink:
					case Token.SmileyCool:
					case Token.SmileyTongue:
					case Token.SmileyConfused:
					case Token.SmileyShocked:
					case Token.SmileyDissapointed:
					case Token.SmileySad:
					case Token.SmileyEmbarrassed:
					case Token.StrikedTextStartTag:
					case Token.StrikedTextEndTag:
					case Token.Tab:
					case Token.UnderlinedTextStartTag:
					case Token.UnderlinedTextEndTag:
					case Token.URLStartTag:
					case Token.URI:					
						// Tag or otherwise nonterminal start. Handle statement. First create new nonterminal with current collected text, if available.
						if(literalTextToken!=null)
						{
							NonTerminal scannedText = new NonTerminal(NonTerminalType.LiteralText);
							scannedText.Tokens.Add(literalTextToken);
							literalTextToken=null;

							_nonTerminalStream.Add(scannedText);
							index = (_nonTerminalStream.Count - 1);
							scannedText.CorrespondingEndNTIndex=index;
						}

						// token is still in the queue.
						NonTerminal parsedNonTerminal = ParseNonTerminal();
						_nonTerminalStream.Add(parsedNonTerminal);
						index = (_nonTerminalStream.Count - 1);
						parsedNonTerminal.CorrespondingEndNTIndex = index;
						Stack<NonTerminal> ntStack = null;
						switch(parsedNonTerminal.Type)
						{
							case NonTerminalType.BoldTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.BoldTextStart);
								break;
							case NonTerminalType.CodeTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.CodeTextStart);
								break;
							case NonTerminalType.ColoredTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.ColoredTextStart);
								break;
							case NonTerminalType.ItalicTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.ItalicTextStart);
								break;
							case NonTerminalType.ListItemEnd:
								ntStack = GetStartNTStack(NonTerminalType.ListItemStart);
								break;
							case NonTerminalType.ListEnd:
								ntStack = GetStartNTStack(NonTerminalType.ListStart);
								break;
							case NonTerminalType.OfftopicTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.OfftopicTextStart);
								break;
							case NonTerminalType.QuotedTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.QuotedTextStart);
								break;
							case NonTerminalType.SizedTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.SizedTextStart);
								break;
							case NonTerminalType.StrikedTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.StrikedTextStart);
								break;
							case NonTerminalType.UnderlinedTextEnd:
								ntStack = GetStartNTStack(NonTerminalType.UnderlinedTextStart);
								break;
						}
						if((ntStack!=null) && (ntStack.Count > 0))
						{
							NonTerminal startNT = ntStack.Pop();
							startNT.CorrespondingEndNTIndex = index;
						}

						break;
					case Token.CR:
						// skip. We only use LF tokens for linefeeds. 
						_tokenStream.Dequeue();
						break;
					case Token.ImageEndTag:
					case Token.URLEndTag:
					default:
						// literal text or token which isn't defined properly. Push the complete text as
						// literal text into the current literal text token.
						currentToken = _tokenStream.Dequeue();
						if(literalTextToken==null)
						{
							literalTextToken = new UBBToken();
							literalTextToken.RelatedTokenDefinition = Parser.TokenDefinitions[(int)Token.UntokenizedLiteralString];
						}
						literalTextToken.LiteralMatchedTokenText += currentToken.LiteralMatchedTokenText;
						break;
				}
			}

			// handle resulting text which is processed but is not transformed to a nonterminal yet.
			if(literalTextToken!=null)
			{
				NonTerminal scannedText = new NonTerminal(NonTerminalType.LiteralText);
				scannedText.Tokens.Add(literalTextToken);
				literalTextToken=null;

				_nonTerminalStream.Add(scannedText);
				int index = (_nonTerminalStream.Count - 1);
				scannedText.CorrespondingEndNTIndex=index;
			}

			// change all nonterminals still on one of the stacks into literal text statements, since there are no matching endtokens found.
			foreach(Stack<NonTerminal> startNTStack in _startNTStacks.Values)
			{
				foreach(NonTerminal current in startNTStack)
				{
					current.Type = NonTerminalType.LiteralText;
				}
			}
		}

		
		/// <summary>
		/// Parses the current statement at the head of the token stream. It assumes the
		/// statement start token is still at the start of the stream.
		/// </summary>
		/// <returns>
		/// Filled NonTerminal object with the data of the statement parsed.
		/// </returns>
		private NonTerminal ParseNonTerminal()
		{
			List<IToken> tokensInStatement = new List<IToken>();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.LiteralText);

			// peek at the current token at the start of the stream. Do not pop it, it's thus not yet
			// removed from the stream.
			IToken currentToken = _tokenStream.Peek();

			// check which statement we're looking at.
			switch((Token)currentToken.TokenID)
			{
				case Token.ColoredTextStartTag:
					toReturn = HandleColoredTextStart(tokensInStatement);
					break;
				case Token.ImageStartTag:
					toReturn = HandleImageStart(tokensInStatement);
					break;
				case Token.ListStartTag:
					toReturn = HandleListStart(tokensInStatement);
					break;
				case Token.QuotedTextStartTag:
					toReturn = HandleQuotedTextStart(tokensInStatement);
					break;
				case Token.SizedTextStartTag:
					toReturn = HandleSizedTextStart(tokensInStatement);
					break;
				case Token.URLStartTag:
					toReturn = HandleURLStart(tokensInStatement);
					break;
				case Token.BoldTextStartTag:
				case Token.BoldTextEndTag:
				case Token.CodeTextStartTag:
				case Token.CodeTextEndTag:
				case Token.ColoredTextEndTag:
				case Token.LF:
				case Token.EmailAddress:
				case Token.ImageURL:
				case Token.ItalicTextStartTag:
				case Token.ItalicTextEndTag:
				case Token.ListEndTag:
				case Token.ListItemEndTag:
				case Token.ListItemStartTag:
				case Token.OfftopicTextStartTag:
				case Token.OfftopicTextEndTag:
				case Token.QuotedTextEndTag:
				case Token.SizedTextEndTag:
				case Token.SmileyLaugh:
				case Token.SmileyAngry:
				case Token.SmileyRegular:
				case Token.SmileyWink:
				case Token.SmileyCool:
				case Token.SmileyTongue:
				case Token.SmileyConfused:
				case Token.SmileyShocked:
				case Token.SmileyDissapointed:
				case Token.SmileySad:
				case Token.SmileyEmbarrassed:
				case Token.StrikedTextStartTag:
				case Token.StrikedTextEndTag:
				case Token.Tab:
				case Token.UnderlinedTextStartTag:
				case Token.UnderlinedTextEndTag:
				case Token.URI:		
					// single token tag
					toReturn = HandleSingleTokenTag(tokensInStatement);
					break;
				case Token.CR:
					// skip
					break;
				default:
					// error.
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Handles the URL start tokens and converts them into a nontermimal, if the syntax is correct. 
		/// </summary>
		/// <param name="tokensInStatement">The tokens in statement.</param>
		/// <returns></returns>
		private NonTerminal HandleURLStart(List<IToken> tokensInStatement)
		{
			// first token has to be '[url', this routine gets called when the current token is [url
			if(!TestCurrentToken(Token.URLStartTag, "HandleURLStart", true))
			{
				// failed. Exception is thrown by TestCurrentToken
			}

			// if is in the queue. Pop it.
			IToken currentToken = _tokenStream.Dequeue();
			tokensInStatement.Add(currentToken);

			// we're inside a tag, therefor we can throw away whitespace.
			StripWhiteSpace();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.URLStart);

			// Next token is either tag end, or descriptionterminal.
			currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.TagCloseBracket:
					// valid argument. Pop it.
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				case Token.DescriptionTerminal:
					// description specified. Assignment and quoted string have to follow.
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();
					// next token has to he assignment.

					if(!TestCurrentToken(Token.Assignment, "HandleURLStart", false))
					{
						// not an assignment seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					// assignment seen. Pop it
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();
					if(!TestCurrentToken(Token.QuotedString, "HandleURLStart", false))
					{
						// not a quoted string seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					// next token has to be a tagclosebracket
					StripWhiteSpace();
					if(!TestCurrentToken(Token.TagCloseBracket, "HandleURLStart", false))
					{
						// not an endbracket seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				default:
					// error
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					// return now.
					return toReturn;
			}
			// now strip whitespace and continue parsing. 
			StripWhiteSpace();
			// next token has to be an URI or ImageURL
			if((!TestCurrentToken(Token.URI, "HandleURLStart", false)) && (!TestCurrentToken(Token.ImageURL, "HandleURLStart", false)))
			{
				// not an URI / ImageURL seen. Error.
				toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
				// return now.
				return toReturn;
			}
			tokensInStatement.Add(_tokenStream.Dequeue());

			StripWhiteSpace();
			// now an urlend tag has to be there
			if(!TestCurrentToken(Token.URLEndTag, "HandleURLStart", false))
			{
				// not an url end tag seen. Error.
				toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
				// return now.
				return toReturn;
			}
			tokensInStatement.Add(_tokenStream.Dequeue());

			// done
			toReturn.Tokens.AddRange(tokensInStatement);
			return toReturn;
		}


		/// <summary>
		/// Handles the Sized start tokens and converts them into a nontermimal, if the syntax is correct. 
		/// </summary>
		/// <param name="tokensInStatement">The tokens in statement.</param>
		/// <returns></returns>
		private NonTerminal HandleSizedTextStart(List<IToken> tokensInStatement)
		{
			// first token has to be '[size', this routine gets called when the current token is [size
			if(!TestCurrentToken(Token.SizedTextStartTag, "HandleSizedTextStart", true))
			{
				// failed. Exception is thrown by TestCurrentToken
			}

			// if is in the queue. Pop it.
			IToken currentToken = _tokenStream.Dequeue();
			tokensInStatement.Add(currentToken);

			// we're inside a tag, therefor we can throw away whitespace.
			StripWhiteSpace();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.SizedTextStart);

			// Next token has to be valueTerminal. 
			currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.ValueTerminal:
					// value specified. Assignment and (single) quoted string have to follow.
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// next token has to he assignment.
					if(!TestCurrentToken(Token.Assignment, "HandleSizedTextStart", false))
					{
						// not an assignment seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					// assignment seen. Pop it
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// next token either is a quoted string or a single quoted string. 
					currentToken = (IToken)_tokenStream.Peek();
					switch((Token)currentToken.TokenID)
					{
						case Token.QuotedString:
						case Token.SingleQuotedNumericString:
							// valid
							break;
						default:
							// error
							toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
							// return now.
							return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					
					// next token has to be a tagclosebracket
					StripWhiteSpace();
					if(!TestCurrentToken(Token.TagCloseBracket, "HandleSizedTextStart", false))
					{
						// not an endbracket seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				default:
					// error
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					// return now.
					return toReturn;
			}
			// done
			toReturn.Tokens.AddRange(tokensInStatement);

			// store this nonterminal onto its stack so a matching end tag can be linked with it.
			Stack<NonTerminal> stack = GetStartNTStack(NonTerminalType.SizedTextStart);
			stack.Push(toReturn);

			return toReturn;
		}


		/// <summary>
		/// Handles the Quoted start tokens and converts them into a nontermimal, if the syntax is correct. 
		/// </summary>
		/// <param name="tokensInStatement">The tokens in statement.</param>
		/// <returns></returns>
		private NonTerminal HandleQuotedTextStart(List<IToken> tokensInStatement)
		{
			// first token has to be '[quote', this routine gets called when the current token is [quote
			if(!TestCurrentToken(Token.QuotedTextStartTag, "HandleQuotedTextStart", true))
			{
				// failed. Exception is thrown by TestCurrentToken
			}

			// if is in the queue. Pop it.
			IToken currentToken = _tokenStream.Dequeue();
			tokensInStatement.Add(currentToken);

			// we're inside a tag, therefor we can throw away whitespace.
			StripWhiteSpace();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.QuotedTextStart);

			// Next token is either tag end, or nickterminal.
			currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.TagCloseBracket:
					// valid argument. Pop it.
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				case Token.NickTerminal:
					// Nick terminal specified. Assignment and quoted string have to follow.
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// next token has to he assignment.
					if(!TestCurrentToken(Token.Assignment, "HandleQuotedTextStart", false))
					{
						// not an assignment seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					// assignment seen. Pop it
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// quoted string has to follow
					if(!TestCurrentToken(Token.QuotedString, "HandleQuotedTextStart", false))
					{
						// not a quoted string seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());

					// next token has to be a tagclosebracket
					StripWhiteSpace();
					if(!TestCurrentToken(Token.TagCloseBracket, "HandleQuotedTextStart", false))
					{
						// not an endbracket seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				default:
					// error
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					// return now.
					return toReturn;
			}
			// done
			toReturn.Tokens.AddRange(tokensInStatement);

			// store this nonterminal onto its stack so a matching end tag can be linked with it.
			Stack<NonTerminal> stack = GetStartNTStack(NonTerminalType.QuotedTextStart);
			stack.Push(toReturn);
			return toReturn;
		}


		/// <summary>
		/// Handles the List start tokens and converts them into a nontermimal, if the syntax is correct. 
		/// </summary>
		/// <param name="tokensInStatement">The tokens in statement.</param>
		/// <returns></returns>
		private NonTerminal HandleListStart(List<IToken> tokensInStatement)
		{
			// first token has to be '[list', this routine gets called when the current token is [list
			if(!TestCurrentToken(Token.ListStartTag, "HandleListStart", true))
			{
				// failed. Exception is thrown by TestCurrentToken
			}

			// if is in the queue. Pop it.
			IToken currentToken = _tokenStream.Dequeue();
			tokensInStatement.Add(currentToken);

			// we're inside a tag, therefor we can throw away whitespace.
			StripWhiteSpace();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.ListStart);

			// Next token is either tag end, or typeterminal.
			currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.TagCloseBracket:
					// valid argument. Pop it.
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				case Token.TypeTerminal:
					// type terminal specified. Assignment and quoted string have to follow.
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// next token has to he assignment.
					if(!TestCurrentToken(Token.Assignment, "HandleListStart", false))
					{
						// not an assignment seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					// assignment seen. Pop it
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// quoted string has to follow
					if(!TestCurrentToken(Token.QuotedString, "HandleListStart", false))
					{
						// not a quoted string seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());

					// next token has to be a tagclosebracket
					StripWhiteSpace();
					if(!TestCurrentToken(Token.TagCloseBracket, "HandleListStart", false))
					{
						// not an endbracket seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				default:
					// error
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					// return now.
					return toReturn;
			}
			// done
			toReturn.Tokens.AddRange(tokensInStatement);

			// store this nonterminal onto its stack so a matching end tag can be linked with it.
			Stack<NonTerminal> stack = GetStartNTStack(NonTerminalType.ListStart);
			stack.Push(toReturn);
			return toReturn;
		}


		/// <summary>
		/// Handles the Image start tokens and converts them into a nontermimal, if the syntax is correct. 
		/// </summary>
		/// <param name="tokensInStatement">The tokens in statement.</param>
		/// <returns></returns>
		/// <remarks>Handles the complete [img...]...[/img] sequence</remarks>
		private NonTerminal HandleImageStart(List<IToken> tokensInStatement)
		{
			// first token has to be '[img', this routine gets called when the current token is [img
			if(!TestCurrentToken(Token.ImageStartTag, "HandleImageStart", true))
			{
				// failed. Exception is thrown by TestCurrentToken
			}

			// if is in the queue. Pop it.
			IToken currentToken = _tokenStream.Dequeue();
			tokensInStatement.Add(currentToken);

			// we're inside a tag, therefor we can throw away whitespace.
			StripWhiteSpace();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.ImageStart);

			// Next token is either tag end, or altterminal.
			currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.TagCloseBracket:
					// valid argument. Pop it.
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				case Token.AltTerminal:
					// alt terminal specified. Assignment and quoted string have to follow.
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// next token has to he assignment.
					if(!TestCurrentToken(Token.Assignment, "HandleImageStart", false))
					{
						// not an assignment seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					// assignment seen. Pop it
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// quoted string has to follow
					if(!TestCurrentToken(Token.QuotedString, "HandleImageStart", false))
					{
						// not a quoted string seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());

					// next token has to be a tagclosebracket
					StripWhiteSpace();
					if(!TestCurrentToken(Token.TagCloseBracket, "HandleImageStart", false))
					{
						// not an endbracket seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				default:
					// error
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					// return now.
					return toReturn;
			}
			// now strip whitespace and continue parsing. 
			StripWhiteSpace();
			// next token has to be an ImageURL
			if(!TestCurrentToken(Token.ImageURL, "HandleImageStart", false))
			{
				// not an imageurl seen. Error.
				toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
				// return now.
				return toReturn;
			}
			tokensInStatement.Add(_tokenStream.Dequeue());

			StripWhiteSpace();
			// now an imageend tag has to be there
			if(!TestCurrentToken(Token.ImageEndTag, "HandleImageStart", false))
			{
				// not an image end tag seen. Error.
				toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
				// return now.
				return toReturn;
			}
			tokensInStatement.Add(_tokenStream.Dequeue());

			// done
			toReturn.Tokens.AddRange(tokensInStatement);
			return toReturn;
		}


		/// <summary>
		/// Handles the Color start tokens and converts them into a nontermimal, if the syntax is correct. 
		/// </summary>
		/// <param name="tokensInStatement">The tokens in statement.</param>
		/// <returns></returns>
		private NonTerminal HandleColoredTextStart(List<IToken> tokensInStatement)
		{
			// first token has to be '[size', this routine gets called when the current token is [size
			if(!TestCurrentToken(Token.ColoredTextStartTag, "HandleColoredTextStart", true))
			{
				// failed. Exception is thrown by TestCurrentToken
			}

			// if is in the queue. Pop it.
			IToken currentToken = _tokenStream.Dequeue();
			tokensInStatement.Add(currentToken);

			// we're inside a tag, therefor we can throw away whitespace.
			StripWhiteSpace();

			NonTerminal toReturn = new NonTerminal(NonTerminalType.ColoredTextStart);

			// Next token has to be valueTerminal. 
			currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.ValueTerminal:
					// value specified. Assignment and (single) quoted string have to follow.
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// next token has to he assignment.
					if(!TestCurrentToken(Token.Assignment, "HandleColoredTextStart", false))
					{
						// not an assignment seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					// assignment seen. Pop it
					tokensInStatement.Add(_tokenStream.Dequeue());
					StripWhiteSpace();

					// quoted string has to follow
					if(!TestCurrentToken(Token.QuotedString, "HandleColoredTextStart", false))
					{
						// not a quoted string seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());

					// next token has to be a tagclosebracket
					StripWhiteSpace();
					if(!TestCurrentToken(Token.TagCloseBracket, "HandleColoredTextStart", false))
					{
						// not an endbracket seen. Error.
						toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
						// return now.
						return toReturn;
					}
					tokensInStatement.Add(_tokenStream.Dequeue());
					break;
				default:
					// error
					toReturn = ConvertPoppedTokensToLiteralText(tokensInStatement);
					// return now.
					return toReturn;
			}
			// done
			toReturn.Tokens.AddRange(tokensInStatement);

			// store this nonterminal onto its stack so a matching end tag can be linked with it.
			Stack<NonTerminal> stack = GetStartNTStack(NonTerminalType.ColoredTextStart);
			stack.Push(toReturn);

			return toReturn;
		}


		/// <summary>
		/// Handles the StatementStart single-token-statement-token StatementEnd statement 
		/// </summary>
		/// <param name="tokensInStatement">Tokens already scanned</param>
		/// <returns>Filled NonTerminal with the tokens scanned. If there were no errors, this nonterminal will be 
		/// of type EndIf. If there were errors, this nonterminal will be of type literaltext.</returns>
		private NonTerminal HandleSingleTokenTag(List<IToken> tokensInStatement)
		{
			NonTerminal toReturn = null;

			// store this nonterminal onto its stack so a matching end tag can be linked with it.
			Stack<NonTerminal> ntStack = null;

			IToken currentToken = (IToken)_tokenStream.Peek();
			switch((Token)currentToken.TokenID)
			{
				case Token.BoldTextStartTag:
					toReturn = new NonTerminal(NonTerminalType.BoldTextStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.BoldTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.BoldTextEnd);
					break;
				case Token.CodeTextStartTag:
					toReturn = new NonTerminal(NonTerminalType.CodeTextStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.CodeTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.CodeTextEnd);
					break;
				case Token.ColoredTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.ColoredTextEnd);
					break;
				case Token.LF:
					toReturn = new NonTerminal(NonTerminalType.CRLF);
					break;
				case Token.EmailAddress:
					toReturn = new NonTerminal(NonTerminalType.EmailAddress);
					break;
				case Token.ImageURL:
					toReturn = new NonTerminal(NonTerminalType.ImageURL);
					break;
				case Token.ItalicTextStartTag:
					toReturn = new NonTerminal(NonTerminalType.ItalicTextStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.ItalicTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.ItalicTextEnd);
					break;
				case Token.ListEndTag:
					toReturn = new NonTerminal(NonTerminalType.ListEnd);
					break;
				case Token.ListItemEndTag:
					toReturn = new NonTerminal(NonTerminalType.ListItemEnd);
					break;
				case Token.ListItemStartTag:
					toReturn = new NonTerminal(NonTerminalType.ListItemStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.OfftopicTextStartTag:
					toReturn = new NonTerminal(NonTerminalType.OfftopicTextStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.OfftopicTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.OfftopicTextEnd);
					break;
				case Token.QuotedTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.QuotedTextEnd);
					break;
				case Token.SizedTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.SizedTextEnd);
					break;
				case Token.SmileyLaugh:
					toReturn = new NonTerminal(NonTerminalType.SmileyLaugh);
					break;
				case Token.SmileyAngry:
					toReturn = new NonTerminal(NonTerminalType.SmileyAngry);
					break;
				case Token.SmileyRegular:
					toReturn = new NonTerminal(NonTerminalType.SmileyRegular);
					break;
				case Token.SmileyWink:
					toReturn = new NonTerminal(NonTerminalType.SmileyWink);
					break;
				case Token.SmileyCool:
					toReturn = new NonTerminal(NonTerminalType.SmileyCool);
					break;
				case Token.SmileyTongue:
					toReturn = new NonTerminal(NonTerminalType.SmileyTongue);
					break;
				case Token.SmileyConfused:
					toReturn = new NonTerminal(NonTerminalType.SmileyConfused);
					break;
				case Token.SmileyShocked:
					toReturn = new NonTerminal(NonTerminalType.SmileyShocked);
					break;
				case Token.SmileyDissapointed:
					toReturn = new NonTerminal(NonTerminalType.SmileyDissapointed);
					break;
				case Token.SmileySad:
					toReturn = new NonTerminal(NonTerminalType.SmileySad);
					break;
				case Token.SmileyEmbarrassed:
					toReturn = new NonTerminal(NonTerminalType.SmileyEmbarrassed);
					break;
				case Token.StrikedTextStartTag:
					toReturn = new NonTerminal(NonTerminalType.StrikedTextStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.StrikedTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.StrikedTextEnd);
					break;
				case Token.Tab:
					toReturn = new NonTerminal(NonTerminalType.Tab);
					break;
				case Token.UnderlinedTextStartTag:
					toReturn = new NonTerminal(NonTerminalType.UnderlinedTextStart);
					ntStack = GetStartNTStack(toReturn.Type);
					break;
				case Token.UnderlinedTextEndTag:
					toReturn = new NonTerminal(NonTerminalType.UnderlinedTextEnd);
					break;
				case Token.URI:
					toReturn = new NonTerminal(NonTerminalType.URI);
					break;
				default:
					// error. This error is only caused by an internal parser error
					throw new ApplicationException("Internal parser error detected. 'HandleSingleStatement' expected a singel statement token but received token '" + ((IToken)_tokenStream.Peek()).TokenID.ToString() + "'.");
			}

			tokensInStatement.Add(_tokenStream.Dequeue());
			toReturn.Tokens.AddRange(tokensInStatement);

			if(ntStack != null)
			{
				// push nonterminal as start nonterminal onto its stack so a related end nonterminal can relate to it.
				ntStack.Push(toReturn);
			}

			return toReturn;
		}


		/// <summary>
		/// Tests the current token on the stack if it is the token passed in as tokenToTest. If so, true is returned.
		/// If not, false is returned. If testCantFail is true, the caller assumes a token at the start of the queue. If that's
		/// not the case, an internal parser error has been detected and an exception is thrown. The token at the start of the queue
		/// is not popped from the queue.
		/// </summary>
		/// <param name="tokenToTest">Token which should be the first token in the queue</param>
		/// <param name="nameCaller">name of the caller of this method. Used in the exception thrown when an internal parser error
		/// is detected</param>
		/// <param name="testCantFail">flag to signal if failure of the test results in an internal parser error</param>
		/// <returns>true if the token at the start of the queue is equal to tokenToTest, false otherwise</returns>
		/// <exception cref="ApplicationException">When testCantFail is true and the test fails.</exception>
		private bool TestCurrentToken(Token tokenToTest, string nameCaller, bool testCantFail)
		{
			return TestCurrentToken(tokenToTest, nameCaller, testCantFail, _tokenStream);
		}


		/// <summary>
		/// Tests the current token on the stack if it is the token passed in as tokenToTest. If so, true is returned.
		/// If not, false is returned. If testCantFail is true, the caller assumes a token at the start of the queue. If that's
		/// not the case, an internal parser error has been detected and an exception is thrown. The token at the start of the queue
		/// is not popped from the queue.
		/// </summary>
		/// <param name="tokenToTest">Token which should be the first token in the queue</param>
		/// <param name="nameCaller">name of the caller of this method. Used in the exception thrown when an internal parser error
		/// is detected</param>
		/// <param name="testCantFail">flag to signal if failure of the test results in an internal parser error</param>
		/// <param name="tokens">token queue to test</param>
		/// <returns>true if the token at the start of the queue is equal to tokenToTest, false otherwise</returns>
		/// <exception cref="ApplicationException">When testCantFail is true and the test fails.</exception>
		private bool TestCurrentToken(Token tokenToTest, string nameCaller, bool testCantFail, Queue<IToken> tokens)
		{
			bool toReturn = (tokens.Peek().TokenID==(int)tokenToTest);
			if((!toReturn)&&testCantFail)
			{
				// internal parser error
				throw new ApplicationException("Internal parser error detected. '" + nameCaller + "' expected token '" + tokenToTest.ToString() + "' but received token '" + ((Token)((IToken)tokens.Peek()).TokenID).ToString() + "'.");
			}

			return toReturn;
		}


		/// <summary>
		/// Converts the passed in set of popped tokens to one nonterminal of type LiteralText. This
		/// routine is used when an error is found in the stream so the currently popped tokens are
		/// apparantly not part of a statement, therefor should be converted to a literal string nonterminal,
		/// which will be transformed by the interpreter as a textstream. The error causing token is <i>not</i> included
		/// in the tokensPopped collection.
		/// </summary>
		/// <param name="tokensPopped">Set of tokens popped, EXCLUDING the error causing token, which will be used as one set
		/// of tokens of one nonterminal of type literal text</param>
		/// <returns>the literal text nonterminal with all the tokens passed in.</returns>
		private NonTerminal ConvertPoppedTokensToLiteralText(List<IToken> tokensPopped)
		{
			NonTerminal toReturn = new NonTerminal(NonTerminalType.LiteralText);

			IToken literalTextToken = new UBBToken();
			literalTextToken.RelatedTokenDefinition = Parser.TokenDefinitions[(int)Token.UntokenizedLiteralString];

			IToken currentToken = null;
			for(int i=0;i<tokensPopped.Count;i++)
			{
				currentToken = (IToken)tokensPopped[i];
				literalTextToken.LiteralMatchedTokenText += currentToken.LiteralMatchedTokenText;
			}

			toReturn.Tokens.Add(literalTextToken);
			return toReturn;
		}


		/// <summary>
		/// Will remove all tokens which are considered whitespace from the tokenstream. 
		/// These are the tokens:
		/// 'WhiteSpace'.
		/// </summary>
		private void StripWhiteSpace()
		{
			StripWhiteSpace(_tokenStream);
		}


		/// <summary>
		/// Will remove all tokens which are considered whitespace from the tokenstream passed in
		/// These are the tokens:
		/// 'WhiteSpace'.
		/// </summary>
		private void StripWhiteSpace(Queue<IToken> toStrip)
		{
			// loop through the whitespace tokens. Will stop at the end of the stream or when another token
			// is 'seen'. 
			while(toStrip.Peek().TokenID==(int)Token.WhiteSpace)
			{
				// pop token and get rid of it.
				IToken popped = toStrip.Dequeue();
			}
		}


		/// <summary>
		/// Create the tokendefinitions. Tokendefinitions are regular expressions which match a textsnippet so the snippet can be represented by the token
		/// </summary>
		private static void CreateTokenDefinitions()
		{
			// EOF, Mandatory token
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.EOF, "", RegexOptions.None));
			// Untokenized string. Mandatory token.
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.UntokenizedLiteralString, "", RegexOptions.None));
			// alt token (Alt)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.AltTerminal, @"alt", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// '=' token (Assignment)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.Assignment, @"=", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [b] token (BoldTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.BoldTextStartTag, @"\[b\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/b] token (BoldTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.BoldTextEndTag, @"\[/b\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [code token (CodeTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.CodeTextStartTag, @"\[code]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/code] token (CodeTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.CodeTextEndTag, @"\[/code\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [color token (ColorStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ColoredTextStartTag, @"\[color", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/color] token (ColorEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ColoredTextEndTag, @"\[/color]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// \r token (CR)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.CR, @"\r", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// description token (Description)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.DescriptionTerminal, @"description", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// Emailaddress token (EmailAddress)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.EmailAddress, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [img token (ImageStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ImageStartTag, @"\[img", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/img] token (ImageEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ImageEndTag, @"\[/img\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ImageURL token (ImageURL). 
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ImageURL, @"(http://www.|http://)([\w-]+\.)+[\w-]+(/[\w-./?%&amp+,#;~=]*)?/[\w-]+\.(jpg|gif|png)", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [i] token (ItalicTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ItalicTextStartTag, @"\[i\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/i] token (ItalicTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ItalicTextEndTag, @"\[/i\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [*] token (ListItemStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ListItemStartTag, @"\[\*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/*] token (ListItemEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ListItemEndTag, @"\[/\*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/list] token (ListEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ListEndTag, @"\[/list\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [list token (ListStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ListStartTag, @"\[list", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// \n token (LF)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.LF, @"\n", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// 'nick' token (Nick)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.NickTerminal, @"nick", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [offtopic] token (OfftopicTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.OfftopicTextStartTag, @"\[offtopic\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/offtopic] token (OfftopicTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.OfftopicTextEndTag, @"\[/offtopic\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// QuotedString token
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.QuotedString, "(\".*?\")", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [quote token (QuoteTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.QuotedTextStartTag, @"\[quote", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/quote] token (QuoteTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.QuotedTextEndTag, @"\[/quote\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [size token (SizeStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SizedTextStartTag, @"\[size", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/size] token (SizeEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SizedTextEndTag, @"\[/size\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [s] token (StrikedTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.StrikedTextStartTag, @"\[s\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/s] token (StrikedTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.StrikedTextEndTag, @"\[/s\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [u] token (UnderlinedTextStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.UnderlinedTextStartTag, @"\[u\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/u] token (UnderlinedTextEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.UnderlinedTextEndTag, @"\[/u\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// SingleQuotedString token
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SingleQuotedNumericString, @"('\d')", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':D' token (SmileyLaugh)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyLaugh, @":D", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':(' token (SmileyAngry)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyAngry, @":\(", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':)' token (SmileyRegular)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyRegular, @":\)", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ';)' token (SmileyWink)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyWink, @";\)", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// '8)' token (SmileyCool)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyCool, @"8\)", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':P' token (SmileyTongue)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyTongue, @":P", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':?' token (SmileyConfused)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyConfused, @":\?", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':o' token (SmileyShocked)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyShocked, @":o", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':/' token (SmileyDissapointed)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyDissapointed, @":/", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ';(' token (SmileySad)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileySad, @";\(", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ':!' token (SmileyEmbarassed)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.SmileyEmbarrassed, @":\!", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// '    ' (4 * space) or TAB
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.Tab, @"[ ]{4}|\t", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ']' token (TagCloseBracket)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.TagCloseBracket, @"\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// type token (Type)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.TypeTerminal, @"type", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// URI token (URI)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.URI, @"(http://www.|http://|https://www.|https://)([\w-]+\.)+[\w-]+(/[\w-./?%&amp;+,~=#]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [url token (URLStartTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.URLStartTag, @"\[url", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// [/url] token (URLEndTag)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.URLEndTag, @"\[/url\]", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// value token (Value)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.ValueTerminal, @"value", RegexOptions.Compiled | RegexOptions.IgnoreCase));
			// ' ' (space)
			Parser.TokenDefinitions.Add(new UBBTokenDefinition((int)Token.WhiteSpace, @"[ ]{1,3}", RegexOptions.Compiled | RegexOptions.IgnoreCase));
		}


		/// <summary>
		/// Gets the start NT stack for the nonterminal type passed in. If the stack isn't available, a new one is created. 
		/// </summary>
		/// <param name="ntType">Type of the nt.</param>
		/// <returns></returns>
		private Stack<NonTerminal> GetStartNTStack(NonTerminalType ntType)
		{
			Stack<NonTerminal> toReturn = null;
			if(!_startNTStacks.TryGetValue(ntType, out toReturn))
			{
				// create a new one
				toReturn = new Stack<NonTerminal>();
				_startNTStacks.Add(ntType, toReturn);
			}

			return toReturn;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets stringToParse
		/// </summary>
		public string StringToParse
		{
			get
			{
				return _stringToParse;
			}
			set
			{
				_stringToParse = value;
			}
		}
		#endregion

	}
}
