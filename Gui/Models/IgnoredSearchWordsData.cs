using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SD.HnD.Gui.Models
{
	public class IgnoredSearchWordsData
	{
		#region Members
		private StringBuilder[] _wordLists;
		#endregion

		public IgnoredSearchWordsData(HashSet<string> noiseWords, int numberOfColumns=5)
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
			var sortedWords = noiseWords.OrderBy(s=>s).ToList();
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