using AFJ.Empregos.Data.Context;
using AFJ.Empregos.Data.Repository.Base;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AFJ.Empregos.Data.Repository
{
    public class TipoPlanoRepository : RepositoryBase<TipoPlano>, ITipoPlanoRepository
    {
        public TipoPlanoRepository(AFJEmpregosDDDContext contexto)
            : base(contexto)
        {
        }

        public TipoPlano ObterPorId(int id)
        {
            return DbSet.Where(p => p.TipoPlanoId == id).SingleOrDefault();
        }

        public IEnumerable<TipoPlano> BuscarTodosAtivos()
        {
            return DbSet.Where(c => c.Status).ToList();
        }

        public IEnumerable<TipoPlano> Filtros(TipoPlano obj)
        {
            return FindByPredicate(p => p.TipoPlanoId == obj.TipoPlanoId || (p.Descricao.Contains(obj.Descricao) && p.Status)).ToList();
        }
    }
}
