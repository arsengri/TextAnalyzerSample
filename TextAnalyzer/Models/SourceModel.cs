﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace TextAnalyzer
{
    /// <summary>
    /// This class is used to create object model to be serialized as JSON and used in Data layer to update Database
    /// </summary>
    public class SourceModel : ITextModel, IJSONModel
	{

        [JsonProperty(PropertyName = "wordsBreakDown")] 
		public List<ISentence> Sentences { get; set; }

		[JsonIgnore]
        public string SourceText { get; set; }

        /// <summary>
        /// List of senctences in the text
        /// </summary>
        [JsonProperty(PropertyName = "sentenceCount")]
        public int SentenceCount
		{
			get
			{  
                return Sentences != null ? Sentences.Count : 0 ;
			}
		}

       
	}

   /// <summary>
   /// Senctne node in main model
   /// </summary>
	public class Sentence : ISentence
	{
        [JsonIgnore]
        public string SentenceText { get; set; }

        [JsonProperty(PropertyName = "sentenceNumber")]
        public int SentenceNumber { get; set; }

        [JsonProperty(PropertyName = "wordsCount")]
        public int WordsCount
		{
			get
			{
				return Words != null ? Words.Count : 0;
			}
		}

        /// <summary>
        /// List of words in the Sentence
        /// </summary>
        [JsonProperty(PropertyName = "lettersBreakDown")]
		public List<IWord> Words { get; set; }
	}
    
    /// <summary>
    /// Word node in main model
    /// </summary>
	public class Word : IWord
	{
        [JsonProperty(PropertyName = "wordNumber")]
        public int WordNumber { get; set; }

        [JsonProperty(PropertyName = "lettersCount")]
        public int LettersCount { get; set; }

        [JsonIgnore]
        public string WordText { get; set; }
	}
}