using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeeCard.Domain.Services
{
    public class BaseService<T> : IBaseService<T>, IDisposable where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
            }            
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.Find(predicate, includeExpressions);
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.GetAll(includeExpressions);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
