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
using System.Text;
using System.Xml;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// Entry point for the complete UBB Parser. Use this class to convert a string in UBB syntaxis to XML. 
	/// </summary>
	public static class Converter
	{
		/// <summary>
		/// Converts the passed in string with UBB tokens to XML.
		/// </summary>
		/// <param name="toConvert">The string to convert.</param>
		/// <returns>An XmlDocument object with the string with UBB tokens in Xml format. This XmlDocument is now usable to convert the string to
		/// for example HTML by using a Xslt stylesheet.</returns>
		public static XmlDocument ConvertToXml(string toConvert)
		{
			Parser textParser = new Parser(toConvert);
			List<NonTerminal> parseTree = textParser.StartParseProcess();
			Interpreter tokenInterpreter = new Interpreter(parseTree);
			return tokenInterpreter.Interpret();
		}
	}
}
