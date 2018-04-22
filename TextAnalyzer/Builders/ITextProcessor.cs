using System;
namespace TextAnalyzer
{
	public interface ITextProcessor
	{
		void ProcessText();
		ITextModel GetTextModel();
        IJSONModel GetJSONModel();


	}
}
