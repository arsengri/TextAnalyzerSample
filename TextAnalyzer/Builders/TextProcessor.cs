using System;
using System.Collections.Generic;

namespace TextAnalyzer
{
    /// <summary>
    /// Provides methods to build model. 
    /// </summary>
	public class TextProcessor : ITextProcessor
	{

        private ITextParser textParser;

		private string inputText;
        private ITextModel model;
        private IJSONModel modelJSON;

		 

		public TextProcessor(ITextParser textParser, string input)
		{
            this.inputText = input;
			this.textParser = textParser;
		}

		public ITextModel GetTextModel()
		{
			return model;
		}

        public IJSONModel GetJSONModel()
        {
            modelJSON = (IJSONModel)model; //for now it is same object
            return modelJSON; 
           
        }

        public void ProcessText()
		{
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return;
            }

			var parsedSentences = textParser.GetSentencesList(inputText);

            model = new SourceModel 
            {
                Sentences = new List<ISentence>(),
                SourceText = inputText
            };

            int n = 1;
			foreach (string senctence in parsedSentences)
			{
                
				var parsedWords = textParser.GetWordsList(senctence);

                Sentence sentenceObj = new Sentence
                {
                    SentenceText = senctence,
                    SentenceNumber = n,
                    Words = new List<IWord>()
                };


                int i = 1;
				foreach (string word in parsedWords)
				{
                    Word wordObj = new Word
                    {
                        WordNumber = i,
                        LettersCount = word.Length,
                        WordText = word
                    };

                    sentenceObj.Words.Add(wordObj);

					i++;
				}

                model.Sentences.Add(sentenceObj);

                n++;
            }
            
		}


      
	}
}
