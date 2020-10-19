using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Repository
{
    public interface IDDDRepository : IRepositoryBase<DDD>
    {
        DDD ObterPorId(int id);

        IEnumerable<DDD> BuscarTodosAtivos();

        IEnumerable<DDD> Filtros(DDD obj);
    }
}
