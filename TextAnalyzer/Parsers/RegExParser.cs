using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    /// <summary>
    /// This class provides methods to parse text with using of Regular Expressions
    /// </summary>
	public class RegExParser : ITextParser
	{
        
		private string sentanceBreakerRegEx = @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])";
		private string wordBreakerRegEx = @"[^\p{L}]*\p{Z}[^\p{L}]*";


        /// <summary>
        /// Splits text on senctences
        /// </summary>
        /// <param name="strText">Text to parse</param>
        /// <returns></returns>
		public List<string> GetSentencesList(string strText)
		{
			// take it simple, but can be hard 
			string[] substrings = Regex.Split(strText, sentanceBreakerRegEx);

			return new List<string>(substrings);

		}

        /// <summary>
        /// Splits sentence on word
        /// </summary>
        /// <param name="strSentence">Sentence to Parse</param>
        /// <returns></returns>
		public List<string> GetWordsList(string strSentence)
		{
			// take it simple, but can be hard 
			string[] substrings = Regex.Split(strSentence, wordBreakerRegEx);

			return new List<string>(substrings);
		}
	}
}
