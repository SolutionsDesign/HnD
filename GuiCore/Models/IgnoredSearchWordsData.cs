/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	https://www.sd.nl

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
using System.Linq;
using System.Text;

namespace SD.HnD.Gui.Models
{
	public class IgnoredSearchWordsData
	{
		private StringBuilder[] _wordLists;


		public IgnoredSearchWordsData(HashSet<string> noiseWords, int numberOfColumns = 5)
		{
			_wordLists = new StringBuilder[numberOfColumns < 1 ? 5 : numberOfColumns];
			BuildWordLists(noiseWords);
		}


		public string GetWordListForColumn(int columnIndex)
		{
			if(columnIndex < 0 || columnIndex > _wordLists.Length)
			{
				return string.Empty;
			}

			return _wordLists[columnIndex].ToString();
		}


		private void BuildWordLists(HashSet<string> noiseWords)
		{
			for(int i = 0; i < _wordLists.Length; i++)
			{
				_wordLists[i] = new StringBuilder();
			}

			var sortedWords = noiseWords.OrderBy(s => s).ToList();
			int numWords = sortedWords.Count;
			int colSize = numWords / 5;
			for(int i = 0; i < colSize; i++)
			{
				for(int j = 0; j < _wordLists.Length; j++)
				{
					_wordLists[j].AppendFormat("{0}<br>", sortedWords[i + (colSize * j)]);
				}
			}

			int rest = numWords - (_wordLists.Length * colSize); // at least 0, at most 4

			for(int i = 1; i <= rest; i++)
			{
				_wordLists[i - 1].AppendFormat("{0}<br>", sortedWords[(i - 1) + (colSize * _wordLists.Length)]);
			}
		}
	}
}