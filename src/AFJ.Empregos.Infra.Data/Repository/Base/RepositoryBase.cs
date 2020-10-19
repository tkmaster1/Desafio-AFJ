using AFJ.Empregos.Data.Context;
using AFJ.Empregos.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AFJ.Empregos.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        #region Properties

        // protected LabetCadastrosContext Db; AFJ.Empregos.Application.Repository.Base
        protected DbContext DbContext { get; set; }
        protected DbSet<TEntity> DbSet;
        private bool disposedValue = false;

        #endregion

        #region Constructor

        public RepositoryBase(AFJEmpregosDDDContext contexto)
        {
            DbContext = contexto;
            DbSet = DbContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        public void Update(TEntity obj)
        {
            var entry = DbContext.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue && disposing)
            {
                DbContext.Dispose();
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            this.DbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
