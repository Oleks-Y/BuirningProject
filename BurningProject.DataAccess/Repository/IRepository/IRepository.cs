using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BurningProject.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where  T : class
    {
        T Get(string id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
        );
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
        );

        void Add(T entity);

        void Remove(string id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}