using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownDeep
{
	/// <summary>
	/// Simple class which find the token pairs of '@' tokens. E.g. @alert and @end belong together as a pair and are found as such. It
	/// deals with nesting so the actual parser can simply pull the related @end token from the found set of pairs to properly mark a block. 
	/// It skips @fa-* and @tabs/@endtabs as these are not causing problems. 
	/// </summary>
	/// <seealso cref="MarkdownDeep.StringScanner" />
	public class SDTokenPairFinder : StringScanner
	{
		private enum SDToken
		{
			Unknown,
			FaToken,
			Alert,
			Tabs,
			Tab,
			Quote,
			OffTopic,
			End,
			EndTabs,
		}


		#region Members
		private List<Tuple<string, SDToken>> _knownSDTokens;  // first Item: token string in lower case, second item: SDtoken enum value
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="SDTokenPairFinder"/> class.
		/// </summary>
		/// <param name="toScan">To scan.</param>
		public SDTokenPairFinder(string toScan) : base(toScan)
		{
			// store them in the order they need to be scanned, so '@tabs' before '@tab'
			_knownSDTokens = new List<Tuple<string, SDToken>>()
							 {
								 new Tuple<string, SDToken>("@fa-", SDToken.FaToken), 
								 new Tuple<string, SDToken>("@alert", SDToken.Alert),
								 new Tuple<string, SDToken>("@tabs", SDToken.Tabs),
								 new Tuple<string, SDToken>("@tab", SDToken.Tab),
								 new Tuple<string, SDToken>("@quote", SDToken.Quote),
								 new Tuple<string, SDToken>("@offtopic", SDToken.OffTopic),
								 new Tuple<string, SDToken>("@endtabs", SDToken.EndTabs),
								 new Tuple<string, SDToken>("@end", SDToken.End),
							 };
		}


		/// <summary>
		/// Finds the start-end token pairs for the tokens which mark starts of blocks which are eded with '@end', like @alert, @quote, @offtopic, @tab tokens. 
		/// </summary>
		/// <returns>Dictionary with as key the start token index, and as value the end token index in string 'toScan'</returns>
		public Dictionary<int, int> FindPairs()
		{
			var toReturn = new Dictionary<int, int>();
			// it keeps track of starttoken indices with a stack. Every time an end token is seen, it pops a start token index from this stack. 
			// if there are no start tokens present, the end token is a mismatch, and is therefore ignored. 
			var startTokenIndices = new Stack<int>();
			while(!this.Eof)
			{
				// every iteration is a line. 
				if(!this.Eol)
				{
					SkipLinespace();
					var tokenStartPos = this.Position;
					var startChar = this.Current;
					if(startChar == '@')
					{
						var token = HandleToken();
						switch(token)
						{
							case SDToken.Alert:
							case SDToken.OffTopic:
							case SDToken.Quote:
							case SDToken.Tab:
								startTokenIndices.Push(tokenStartPos);
								break;
							case SDToken.End:

								// pop the top index from the starttoken stack. If no index present, skip this end by simply doing nothing. 
								if(startTokenIndices.Count > 0)
								{
									toReturn.Add(startTokenIndices.Pop(), tokenStartPos);
								}
								break;
							default:

								// ignore
								break;
						}
					}
				}
				SkipToEol();
				SkipEol();
			}
			return toReturn;
		}


		/// <summary>
		/// Handles the token at current position. It doesn't do any validation other than that the token has to whitespace following it, or EOF. 
		/// </summary>
		/// <returns></returns>
		private SDToken HandleToken()
		{
			if(DoesMatchI("@fa-"))
			{
				// no further action required, this token isn't important for this class. We scan this here because it is the only token which is followed by non-white space.
				return SDToken.FaToken;
			}
			foreach(var token in _knownSDTokens)
			{
				// Item1 is token string, Item2 is SDToken enum value of that token
				if(DoesMatchI(token.Item1))
				{
					// check if the token is followed by whitespace or EOL. If not, ignore the token, otherwise return Item2.
					SkipStringI(token.Item1);
					if(this.Eol || IsLineSpace(this.Current))
					{
						// properly formatted token, accept
						return token.Item2;
					}
					// apparently not a match, ignore
					return SDToken.Unknown;
				}
			}
			return SDToken.Unknown;
		}
	}
}
