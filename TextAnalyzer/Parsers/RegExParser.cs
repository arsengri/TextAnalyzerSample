using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{

	public class RegExParser : ITextParser
	{
        
		private string sentanceBreakerRegEx = @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])";
		private string wordBreakerRegEx = @"[^\p{L}]*\p{Z}[^\p{L}]*";



		public List<string> GetSentencesList(string strText)
		{
			// take it simple, but can be hard 
			string[] substrings = Regex.Split(strText, sentanceBreakerRegEx);

			return new List<string>(substrings);

		}


		public List<string> GetWordsList(string strSentence)
		{
			// take it simple, but can be hard 
			string[] substrings = Regex.Split(strSentence, wordBreakerRegEx);

			return new List<string>(substrings);
		}
	}
}
