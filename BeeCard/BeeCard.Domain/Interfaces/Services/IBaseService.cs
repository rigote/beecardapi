using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeeCard.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {        
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
