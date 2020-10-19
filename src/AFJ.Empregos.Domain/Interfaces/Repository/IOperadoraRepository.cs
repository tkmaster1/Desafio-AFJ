using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Repository
{
    public interface IOperadoraRepository : IRepositoryBase<Operadora>
    {
        Operadora ObterPorId(int id);

        IEnumerable<Operadora> BuscarTodosAtivos();

        IEnumerable<Operadora> Filtros(Operadora obj);
    }
}
