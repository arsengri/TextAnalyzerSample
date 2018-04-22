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

        private bool ValidateModel(SourceModel model)
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

        public void SaveModelToDB(SourceModel m)
        {

            if (!ValidateModel(m))
            {
                throw new ModelNotPopulatedException();
            }

            using (var context = new DBTextAnalyzerEntities())
            {

                UnitOfWork unitOfWork = new UnitOfWork(context);

                
                TextLog log = new TextLog();
                log.SourceText = m.SouceTxt;
                unitOfWork.TextLogRepository.Insert(log);


                foreach (Sentence senctence in m.Sentences)
                {
                    Phras p = new Phras
                    {
                        Phrase = senctence.SentenceTxt,
                        SeqNo = senctence.SentenceNumber,
                        TextLog = log
                    };

                    unitOfWork.PhraseRepository.Insert(p);

                    foreach (var word in senctence.Words)
                    {
                        Data.Word dbWord = unitOfWork.WordRepository.Get(filter: f => f.Word1.Equals(word.wordTxt)).FirstOrDefault();


                        if (dbWord == null)
                        {
                            dbWord = new Word
                            {
                                Word1 = word.wordTxt
                            };
                        }

                        PhraseWord pw = new PhraseWord
                        {
                            Phras = p,
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
