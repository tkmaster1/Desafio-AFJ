using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Service.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(int id);

        void Dispose();
    }
}
