using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using BeeCard.Domain.Interfaces.Repositories;
using System.Data.Entity;
using System.Data;

namespace BeeCard.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        private readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }        

        public virtual List<T> Find(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            List<T> result = new List<T>();
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeExpression in includeExpressions)
                query = query.Include(includeExpression);

            if (predicate != null)
                query = query.Where(predicate);

            using (_context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                result = query.ToList();
            }

            return result;
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            List<T> result = new List<T>();
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeExpression in includeExpressions)
                query = query.Include(includeExpression);

            using (_context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                result = query.ToList();
            }

            return result;
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                (_context as IDisposable).Dispose();
            }
        }
    }
}
