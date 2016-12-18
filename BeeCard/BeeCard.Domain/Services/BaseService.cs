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

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }        

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.Find(predicate, includeExpressions);
        }

        public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.GetAll(includeExpressions);
        }

        public virtual void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
            }
        }
    }
}
