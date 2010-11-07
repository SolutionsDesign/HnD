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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind for the ignored searchwords page. 
	/// </summary>
	public partial class IgnoredSearchWords : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Hashtable noiseWords = ApplicationAdapter.GetNoiseWords();
				ArrayList sortedWords = new ArrayList(noiseWords.Keys);
				sortedWords.Sort();
				StringBuilder[] wordLists = new StringBuilder[5];
				for (int i = 0; i < 5; i++)
				{
					wordLists[i] = new StringBuilder();
				}
				
				int numWords = sortedWords.Count;
				int colSize = numWords/5;

				for (int i = 0; i < colSize; i++)
				{
					wordLists[0].AppendFormat("{0}<br>", sortedWords[i]);
					wordLists[1].AppendFormat("{0}<br>", sortedWords[i+colSize]);
					wordLists[2].AppendFormat("{0}<br>", sortedWords[i+(colSize*2)]);
					wordLists[3].AppendFormat("{0}<br>", sortedWords[i+(colSize*3)]);
					wordLists[4].AppendFormat("{0}<br>", sortedWords[i+(colSize*4)]);
				}

				int rest = numWords - (5*colSize); // at least 0, at most 4

				for (int i = 1; i <= rest; i++)
				{
					wordLists[i-1].AppendFormat("{0}<br>", sortedWords[(i-1) + (colSize*5)]);
				}

				lblWordList1.Text = wordLists[0].ToString();
				lblWordList2.Text = wordLists[1].ToString();
				lblWordList3.Text = wordLists[2].ToString();
				lblWordList4.Text = wordLists[3].ToString();
				lblWordList5.Text = wordLists[4].ToString();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
