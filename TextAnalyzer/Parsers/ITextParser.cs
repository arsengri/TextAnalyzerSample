using System;
using System.Collections.Generic;

namespace TextAnalyzer
{
	public interface ITextParser
	{

		List<string> GetSentencesList(string s);

		List<string> GetWordsList(string s);

	}
}
