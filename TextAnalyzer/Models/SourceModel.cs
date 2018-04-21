using System.Collections.Generic;
using Newtonsoft.Json;

namespace TextAnalyzer
{
    
    public class SourceModel
	{

        [JsonProperty(PropertyName = "wordsBreakDown")] 
		public List<Sentence> Sentences { get; set; }

		[JsonIgnore]
        public string SouceTxt { get; set; }

        [JsonProperty(PropertyName = "sentenceCount")]
        public int SentenceCount
		{
			get
			{ 
                return Sentences.Count;
			}
		}
	}

   
	public class Sentence
	{
        [JsonIgnore]
        public string SentenceTxt { get; set; }

        [JsonProperty(PropertyName = "sentenceNumber")]
        public int SentenceNumber { get; set; }

        [JsonProperty(PropertyName = "wordsCount")]
        public int WordsCount
		{
			get
			{
				return Words.Count;
			}
		}

        [JsonProperty(PropertyName = "lettersBreakDown")]
		public List<Word> Words { get; set; }
	}

	public class Word
	{
        [JsonProperty(PropertyName = "wordNumber")]
        public int WordNumber { get; set; }

        [JsonProperty(PropertyName = "lettersCount")]
        public int LettersCount { get; set; }

        [JsonIgnore]
        public string wordTxt { get; set; }
	}
}