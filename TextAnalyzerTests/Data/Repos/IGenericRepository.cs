using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Data.Repos
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity item);
        TEntity GetByID(object id);
        IQueryable<TEntity> GetSet();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Delete(TEntity item);
        void Delete(object id);
        void Update(TEntity item);
    }
}
