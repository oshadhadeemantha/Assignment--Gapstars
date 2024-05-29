using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Chinook.Models;
using Chinook.Service.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Chinook.Service.Service
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ChinookContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(IDbContextFactory<ChinookContext> DbFactory)
        {
            context = DbFactory.CreateDbContext(); ;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAsync(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IQueryable<TEntity>> orderBy = null,
             string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return dbSet.AsQueryable();
        }
        public virtual async Task<TEntity> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id)
;
        }

        public virtual void Insert(TEntity entity)
        {
            
            
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public void BulkInsert(List<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void BulkUpdate(List<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }

        public IEnumerable<object> GetAll()
        {
            if (typeof(TEntity) == typeof(Artist))
            {
                return context.Artists.Include(a => a.Albums).ToList();
            }
            return context.Set<TEntity>().ToList();
        }
    }
}
