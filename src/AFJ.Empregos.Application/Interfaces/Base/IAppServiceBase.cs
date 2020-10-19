using System.Collections.Generic;

namespace AFJ.Empregos.Application.Interfaces.Base
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remover(int id);

        void Dispose();
    }
}
