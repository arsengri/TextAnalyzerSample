using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Data;
using TextAnalyzer.Data.Repos;

namespace TextAnalyzer.Data
{
    class DataManager
    {
        DBTextAnalyzerEntities db = new DBTextAnalyzerEntities();

        private UnitOfWork unitOfWork = new UnitOfWork();
        public void SaveModelToDB(SourceModel m)
        {
             
            
            TextLog log = new TextLog();
            log.SourceText = m.SouceTxt;
            unitOfWork.TextLogRepository.Insert(log);


            foreach( Sentence s in m.Sentences)
            {
                Phras p = new Phras
                {
                    Phrase = s.SentenceTxt,
                    SeqNo = s.SentenceNumber,
                    TextLog = log
                };

                unitOfWork.PhraseRepository.Insert(p); 

                foreach( var w in s.Words)
                {
                    Data.Word dw = unitOfWork.WordRepository.Get(filter: f => f.Word1.Equals(w.wordTxt)).FirstOrDefault();
                       
                    

                    if(dw == null)
                    {
                         dw = new Word
                        {
                            Word1 = w.wordTxt
                        };
                    }

                    PhraseWord pw = new PhraseWord
                    {
                        Phras = p,
                        Word = dw,
                        SeqNo = w.WordNumber
                    };

                    unitOfWork.PhraseWordRepository.Insert(pw);


                }

            }





            unitOfWork.Save();

        }
    }
}
