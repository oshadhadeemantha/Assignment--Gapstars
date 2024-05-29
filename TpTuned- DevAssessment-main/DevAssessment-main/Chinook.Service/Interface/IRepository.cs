using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Service.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query = null,
            string includeProperties = "");
        IQueryable<TEntity> AsQueryable();
        Task<TEntity> GetByIDAsync(object id);
        void Insert(TEntity entity);

        void BulkInsert(List<TEntity> entities);
        void Update(TEntity entityToUpdate);
        void BulkUpdate(List<TEntity> entities);
        IEnumerable<object> GetAll();
    }
}
