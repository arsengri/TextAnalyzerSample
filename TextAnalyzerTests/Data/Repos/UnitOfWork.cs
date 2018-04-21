using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Data;

namespace TextAnalyzer.Data.Repos
{
    public class UnitOfWork : IDisposable
    {
        private DBTextAnalyzerEntities context = new DBTextAnalyzerEntities();
        private GenericRepository<TextLog> textLogRepo;
        private GenericRepository<Phras> phraseRepo;
        private GenericRepository<Data.Word> wordRepo;
        private GenericRepository<PhraseWord> phraseWordRepo;



        public GenericRepository<TextLog> TextLogRepository
        {
            get
            {
                if (this.textLogRepo == null)
                {
                    this.textLogRepo = new GenericRepository<TextLog>(context);
                }
                return textLogRepo;
            }
        }

        public GenericRepository<Phras> PhraseRepository
        {
            get
            {
                if (this.phraseRepo == null)
                {
                    this.phraseRepo = new GenericRepository<Phras>(context);
                }
                return phraseRepo;
            }
        }

        public GenericRepository<Data.Word> WordRepository
        {
            get
            {
                if (this.wordRepo == null)
                {
                    this.wordRepo = new GenericRepository<Data.Word>(context);
                }
                return wordRepo;
            }
        }

        public GenericRepository<PhraseWord> PhraseWordRepository
        {
            get
            {
                if (this.phraseWordRepo == null)
                {
                    this.phraseWordRepo = new GenericRepository<PhraseWord>(context);
                }
                return phraseWordRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
