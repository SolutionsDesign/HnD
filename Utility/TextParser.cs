/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
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
using System.Xml;
using System.Xml.Xsl;
using System.Text;

using SD.HnD.UBBParser;
using System.IO;

namespace SD.HnD.Utility
{
	/// <summary>
	/// Structure used to store data related to the parser in the application object.
	/// </summary>
	public struct ParserData
	{
		public XslCompiledTransform MessageStyle;
		public XslCompiledTransform SignatureStyle;
	}
	
	/// <summary>
	/// General Text Code parser. This class converts passed in texts with UBB/other codes to texts with HTML code.
	/// It uses a UBB Special parser build with the parser framework. It assumes the parser engine tables are
	/// already serialized into objects located in the Application Object.
	/// </summary>
	public static class TextParser
	{
		/// <summary>
		/// Used by the re-parser to parse a message to xml.
		/// </summary>
		/// <param name="messageText">the text of the message in UBB format</param>
		/// <param name="reGenerateHTML">if true, HTML is also re-generated</param>
		/// <param name="parserData">The parser data.</param>
		/// <param name="messageTextXML">the XML parse result for the ubbstring</param>
		/// <param name="messageTextHTML">if reGenerateHTML is set to true, this contains the HTML output for the message</param>
		public static void ReParseMessage(string messageText, bool reGenerateHTML, ParserData parserData, out string messageTextXML, out string messageTextHTML)
		{
			bool errorsOccured = false;
			string parseLog = string.Empty;
			messageTextXML = string.Empty;
			messageTextHTML = TransformUBBStringToHTML(messageText, true, reGenerateHTML, parserData, out parseLog, out errorsOccured, out messageTextXML);
		}


		/// <summary>
		/// Transforms the given message with all its forumtags to HTML using the specified XSL template and returns that HTML string. The
		/// XSL template is cached inside the Application object, so the name specified is the name of the Application object's property holding the
		/// XSL template.
		/// </summary>
		/// <param name="ubbString">Text to transform</param>
		/// <param name="parserData">The parser data.</param>
		/// <param name="parserLog">Output parameter, contains the parserlog of the parse process</param>
		/// <param name="errorsOccured">Output parameter, contains true if the parser found one or more errors in sUBBString, false otherwise</param>
		/// <param name="messageTextXML">The parse result in XML format (string)</param>
		/// <returns>ubbString in HTML format</returns>
		public static string TransformUBBMessageStringToHTML(string ubbString, ParserData parserData, out string parserLog, out bool errorsOccured, out string messageTextXML)
		{
			return TransformUBBStringToHTML(ubbString, true, true, parserData, out parserLog, out errorsOccured, out messageTextXML);
		}


		/// <summary>
		/// Will transform a given signature to HTML using the UBB parser. Only several tags are supported. These tags are filtered by the
		/// special signature xsl sheet. The input is already limited to the maximum signature size.
		/// </summary>
		/// <param name="signature">Signature to transform to HTML</param>
		/// <param name="parserData">The parser data.</param>
		/// <returns>Signature in HTML format.</returns>
		public static string TransformSignatureUBBStringToHTML(string signature, ParserData parserData)
		{
			string parserLog, messageTextXML;
			bool errorsOccured;
			return TransformUBBStringToHTML(signature, false, true, parserData, out parserLog, out errorsOccured, out messageTextXML);
		}


		/// <summary>
		/// Transforms the given text with all its forumtags to HTML using the specified XSL template and returns that HTML string. The
		/// XSL template is cached inside the Application object, so the name specified is the name of the Application object's property holding the
		/// XSL template.
		/// </summary>
		/// <param name="ubbString">Text to transform</param>
		/// <param name="isMessageTransform">Pass true to use the message style and false to use the signature style </param>
		/// <param name="performHtmlConversion">set to false when the parser is just used to create a wordlist.</param>
		/// <param name="parserData">The parser data.</param>
		/// <param name="parserLog">Output parameter, contains the parserlog of the parse process</param>
		/// <param name="errorsOccured">Output parameter, contains true if the parser found one or more errors in sUBBString, false otherwise</param>
		/// <param name="messageTextXML">THe parser result as XML string</param>
		/// <returns>ubbString in HTML format</returns>
		private static string TransformUBBStringToHTML(string ubbString, bool isMessageTransform, bool performHtmlConversion, ParserData parserData, out string parserLog, 
			out bool errorsOccured, out string messageTextXML)
		{
			parserLog=string.Empty;
			errorsOccured=false;

			messageTextXML = string.Empty;

			if(ubbString==null)
			{
				return "";
			}

			// parse it
			try
			{
				XmlDocument emitterResult = Converter.ConvertToXml(ubbString);
				messageTextXML = emitterResult.OuterXml;
				errorsOccured = false;

				if(performHtmlConversion)
				{
					// Transform Emitter result into HTML using the xsl specified.
					XslCompiledTransform xslTransformer = parserData.MessageStyle;
					if (!isMessageTransform)
					{
						xslTransformer = parserData.SignatureStyle;
					}

					// in .NET 2.0, the XmlCompiledTransform doesn't have a way to transform to a reader or string. So we'll transform to a stream
					// which we'll use to read back into a stringbuilder which is faster with replacing tab characters to 4 spaces. 
					MemoryStream outputStream = new MemoryStream();
					xslTransformer.Transform(emitterResult, null, outputStream);
					outputStream.Seek(0, SeekOrigin.Begin);

					StreamReader reader = new StreamReader(outputStream);
					StringBuilder htmlOutput = new StringBuilder(reader.ReadToEnd());
					reader.Close();		// closes underlying stream as well. 

					// replace any tab chars with 4 HTML spaces
					return htmlOutput.ToString();
				}
				else
				{
					return string.Empty;
				}
			}
			catch
			{
				// exception occured. Don't proceed with passed in text, simply return empty string.
				errorsOccured=true;
				return string.Empty;
			}
		}
		
		
		/// <summary>
		/// Transforms the passed in string into a string with quote tags, which is used to be included
		/// into a message as a 'quoted' part of a previous message.
		/// </summary>
		/// <param name="toQuote">String to quote</param>
		/// <param name="nickName">Nickname of poster who posted the string to Quote</param>
		/// <returns>string modified so it is quoted for the editor</returns>
		public static string MakeStringQuoted(string toQuote, string nickName)
		{
			return string.Format("[quote nick=\"{0}\"]{1}[/quote]\n", nickName, toQuote);
		}
	}
}
