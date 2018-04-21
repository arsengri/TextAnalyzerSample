using System;
namespace TextAnalyzer
{
	public interface IBuilder
	{
		void Build();
		SourceModel getModel();
	}
}
