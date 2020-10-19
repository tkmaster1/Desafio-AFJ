using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository.Base;
using AFJ.Empregos.Domain.ValueObjects;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Repository
{
    public interface IPlanoRepository : IRepositoryBase<Plano>
    {
        Plano ObterPorId(int id);

        IEnumerable<Plano> BuscarTodosAtivos();

        IEnumerable<Plano> Filtros(Plano obj);

        ICollection<PlanoTelefoniaVO> FiltrosEspecificos(PlanoTelefoniaVO objModel);
    }
}
