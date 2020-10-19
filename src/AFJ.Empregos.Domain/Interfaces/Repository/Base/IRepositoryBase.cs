using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AFJ.Empregos.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindByPredicate(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity obj);

        void Remove(int id);

        void Dispose();

        int SaveChanges();
    }
}
