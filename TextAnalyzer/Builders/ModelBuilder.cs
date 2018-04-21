using System;
using System.Collections.Generic;

namespace TextAnalyzer
{
    /// <summary>
    /// Provides methods to build model. 
    /// </summary>
	public class ModelBuidler : IBuilder
	{

        private ITextParser textParser;

		private string inputText;
        private SourceModel model;

		 

		public ModelBuidler(ITextParser textParser, string input)
		{
            this.inputText = input;
			this.textParser = textParser;
		}

		public SourceModel getModel()
		{
			return model;
		}

		public void Build()
		{

			var parsedSentences = textParser.GetSentencesList(inputText);

            model = new SourceModel
            {
                Sentences = new List<Sentence>(),
                SouceTxt = inputText
            };

            int n = 1;
			foreach (string senctence in parsedSentences)
			{
                
				var parsedWords = textParser.GetWordsList(senctence);

                Sentence sentenceObj = new Sentence
                {
                    SentenceTxt = senctence,
                    SentenceNumber = n,
                    Words = new List<Word>()
                };


                int i = 1;
				foreach (string word in parsedWords)
				{
                    Word wordObj = new Word
                    {
                        WordNumber = i,
                        LettersCount = word.Length,
                        wordTxt = word
                    };

                    sentenceObj.Words.Add(wordObj);

					i++;
				}

                model.Sentences.Add(sentenceObj);

			}

            
			n++;
		}


      
	}
}
