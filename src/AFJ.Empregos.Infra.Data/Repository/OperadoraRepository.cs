using AFJ.Empregos.Data.Context;
using AFJ.Empregos.Data.Repository.Base;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AFJ.Empregos.Data.Repository
{
    public class OperadoraRepository : RepositoryBase<Operadora>, IOperadoraRepository
    {
        #region Constructor

        public OperadoraRepository(AFJEmpregosDDDContext contexto)
            : base(contexto)
        {
        }

        #endregion

        #region Methods

        public Operadora ObterPorId(int id)
        {
            return DbSet.Where(p => p.OperadoraId == id).SingleOrDefault();
        }

        public IEnumerable<Operadora> BuscarTodosAtivos()
        {
            return DbSet.Where(c => c.Status).ToList();
        }

        public IEnumerable<Operadora> Filtros(Operadora obj)
        {
            return FindByPredicate(p => p.OperadoraId == obj.OperadoraId || (p.Nome.Contains(obj.Nome) && p.Status)).ToList();
        }

        #endregion
    }
}
