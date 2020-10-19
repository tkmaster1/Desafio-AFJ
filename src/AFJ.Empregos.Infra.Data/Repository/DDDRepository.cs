using AFJ.Empregos.Data.Context;
using AFJ.Empregos.Data.Repository.Base;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AFJ.Empregos.Data.Repository
{
    public class DDDRepository : RepositoryBase<DDD>, IDDDRepository
    {
        public DDDRepository(AFJEmpregosDDDContext contexto)
            : base(contexto)
        {
        }

        public DDD ObterPorId(int id)
        {
            return DbSet.Where(p => p.DDDId == id).SingleOrDefault();
        }

        public IEnumerable<DDD> BuscarTodosAtivos()
        {
            return DbSet.Where(c => c.Status).ToList();
        }

        public IEnumerable<DDD> Filtros(DDD obj)
        {
            return FindByPredicate(p => p.DDDId == obj.DDDId || (p.CodDDD.Contains(obj.CodDDD) && p.Status)).ToList();
        }
    }
}
