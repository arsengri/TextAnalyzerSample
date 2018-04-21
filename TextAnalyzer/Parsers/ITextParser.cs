using System;
using System.Collections.Generic;

namespace TextAnalyzer
{
    /// <summary>
    /// Exposes  methods to parse a Text
    /// </summary>
	public interface ITextParser
	{

		List<string> GetSentencesList(string s);

		List<string> GetWordsList(string s);

	}
}
