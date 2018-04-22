using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Data;
using TextAnalyzer.Data.Repos;

namespace TextAnalyzer.Data
{
    /// <summary>
    /// Provides service methods to validate and save model to DB 
    /// </summary>
    public class DataManager
    {

        private bool ValidateModel(ITextModel model)
        {
           bool isValid = true;


            if (model == null || model.Sentences == null)
            {
                isValid = false;
            }
            else
            {
                var wordsList = model.Sentences.Where(w => w.Words != null).FirstOrDefault();
                if (wordsList == null)
                {
                    isValid = false;
                }
            }
           
            return isValid;
        }

        public void SaveModelToDB(ITextModel model)
        {

            if (!ValidateModel(model))
            {
                throw new ModelNotPopulatedException();
            }

            using (var context = new DBTextAnalyzerEntities())
            {

                UnitOfWork unitOfWork = new UnitOfWork(context);

                
                TextLog log = new TextLog();
                log.SourceText = model.SourceText;
                unitOfWork.TextLogRepository.Insert(log);


                foreach (Sentence senctence in model.Sentences)
                {
                    Phras phrase = new Phras
                    {
                        Phrase = senctence.SentenceText,
                        SeqNo = senctence.SentenceNumber,
                        TextLog = log
                    };

                    unitOfWork.PhraseRepository.Insert(phrase);

                    foreach (var word in senctence.Words)
                    {
                        Data.Word dbWord = unitOfWork.WordRepository.Get(filter: f => f.Word1.Equals(word.WordText)).FirstOrDefault();


                        if (dbWord == null)
                        {
                            
                            dbWord = new Data.Word
                            {
                                Word1 = word.WordText
                            };
                            unitOfWork.WordRepository.Insert(dbWord);
                            
                        }

                        PhraseWord pw = new PhraseWord
                        {
                            Phras = phrase,
                            Word = dbWord,
                            SeqNo = word.WordNumber
                        };

                        unitOfWork.PhraseWordRepository.Insert(pw);

                    }

                }
                
                unitOfWork.Save();
            }

        }
    }
}
