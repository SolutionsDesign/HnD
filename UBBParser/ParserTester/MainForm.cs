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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SD.HnD.UBBParser;
using System.Xml;
using System.IO;

namespace ParserTester
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			_destinationFileTextBox.Text = "output.xml";
			_inputFilenameTextBox.Text = "input.txt";
		}

		private void _startParseButton_Click(object sender, EventArgs e)
		{
			if(_textToParseTextBox.Text.Length <= 0)
			{
				return;
			}

			_logTextBox.Text = string.Empty;
			LogLine("Parsing started.");
			
			Parser textParser = new Parser(_textToParseTextBox.Text);
			List<NonTerminal> parseTree = textParser.StartParseProcess();
			Interpreter tokenInterpreter = new Interpreter(parseTree);
			XmlDocument result = tokenInterpreter.Interpret();

			LogLine("Parsing ended.");

			string outputfilename = Path.Combine(Environment.CurrentDirectory, _destinationFileTextBox.Text);
			StreamWriter writer = new StreamWriter(outputfilename, false);
			writer.Write(result.OuterXml);
			writer.Close();

			LogLine("Output written as XML to " + outputfilename);

			ViewParseTree(parseTree);
		}


		/// <summary>
		/// Views the parse tree in the treeview.
		/// </summary>
		/// <param name="parseTree">The parse tree.</param>
		private void ViewParseTree(List<NonTerminal> parseTree)
		{
			_parseTreeTreeView.BeginUpdate();
			_parseTreeTreeView.Nodes.Clear();

			TreeNode rootNode = _parseTreeTreeView.Nodes.Add("Parse tree");
			rootNode.ForeColor = Color.Blue;
			foreach(NonTerminal currentNT in parseTree)
			{
				TreeNode ntNode = rootNode.Nodes.Add(currentNT.Type.ToString());
				ntNode.ForeColor = Color.Brown;
				TreeNode tokensNode = ntNode.Nodes.Add("Tokens");
				tokensNode.ForeColor = Color.Blue;
				foreach(IToken token in currentNT.Tokens)
				{
					TreeNode tokenNode = tokensNode.Nodes.Add(((Token)token.TokenID).ToString());
					tokenNode.ForeColor = Color.DarkMagenta;
					tokenNode.Nodes.Add(String.Format(">{0}<", BeautifyText(token.LiteralMatchedTokenText)));
				}
			}
			rootNode.ExpandAll();
			_parseTreeTreeView.EndUpdate();
		}

		/// <summary>
		/// Beautifies the text passed in. Converts raw \r\t\n chars to visible text
		/// </summary>
		/// <param name="toBeautify">To beautify.</param>
		/// <returns></returns>
		private string BeautifyText(string toBeautify)
		{
			return toBeautify.Replace("\r", @"\r").Replace("\n", @"\n").Replace("\t", @"\t");
		}


		private void LogLine(string toLog)
		{
			_logTextBox.Text += toLog + Environment.NewLine;
		}


		private void _loadInputButton_Click(object sender, EventArgs e)
		{
			string filename = Path.Combine(Environment.CurrentDirectory, _inputFilenameTextBox.Text);
			if(!File.Exists(filename))
			{
				LogLine("File {0} doesn't exist", filename);
				return;
			}
			StreamReader reader = new StreamReader(filename);
			_textToParseTextBox.Text = reader.ReadToEnd();
			reader.Close();
		}


		/// <summary>
		/// Logs the line.
		/// </summary>
		/// <param name="formattedString">The formatted string.</param>
		/// <param name="operands">The operands.</param>
		private void LogLine(string formattedString, params object[] operands)
		{
			LogLine(String.Format(formattedString, operands));
		}
	}
}