﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeeCard.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {        
        Tuple<long, List<T>> Find(int? page, int? size, Expression<Func<T, Guid>> keySelector, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions);
        Tuple<long, List<T>> GetAll(int? page, int? size, Expression<Func<T, Guid>> keySelector, params Expression<Func<T, object>>[] includeExpressions);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
