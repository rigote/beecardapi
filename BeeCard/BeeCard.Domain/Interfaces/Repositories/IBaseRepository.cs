using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeeCard.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> Find(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions);
        List<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        void Dispose();
    }
}
