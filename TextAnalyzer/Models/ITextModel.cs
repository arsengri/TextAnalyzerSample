using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    public interface ITextModel
    {
        string SourceText { get; set; }
        List<ISentence> Sentences { get; set; }

    }

    public interface ISentence
    {
        string SentenceText { get; set; }
        List<IWord> Words { get; set; }
    }

    public interface IWord
    {
        int WordNumber { get; set; }
        string WordText { get; set; }
    }

    public interface IJSONModel
    {
        // No specific methods for now, keepig it flexible
    }
}
