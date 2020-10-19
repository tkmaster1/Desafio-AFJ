using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Repository
{
    public interface ITipoPlanoRepository : IRepositoryBase<TipoPlano>
    {
        TipoPlano ObterPorId(int id);

        IEnumerable<TipoPlano> BuscarTodosAtivos();

        IEnumerable<TipoPlano> Filtros(TipoPlano obj);
    }
}
