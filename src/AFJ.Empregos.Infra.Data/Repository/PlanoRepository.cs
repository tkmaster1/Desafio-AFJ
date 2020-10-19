using AFJ.Empregos.Data.Context;
using AFJ.Empregos.Data.Repository.Base;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using AFJ.Empregos.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace AFJ.Empregos.Data.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
        #region Properties

        readonly AFJEmpregosDDDContext Db = new AFJEmpregosDDDContext();

        #endregion

        #region Constructor

        public PlanoRepository(AFJEmpregosDDDContext contexto)
            : base(contexto)
        {
        }

        #endregion

        #region Methods

        public Plano ObterPorId(int id)
        {
            return DbSet.Where(p => p.PlanoId == id).SingleOrDefault();
            //FindByPredicate(p => p.PlanoId == id).SingleOrDefault();
        }

        public IEnumerable<Plano> BuscarTodosAtivos()
        {
            return DbSet.Where(c => c.Status).ToList();
        }

        public IEnumerable<Plano> Filtros(Plano obj)
        {
            return FindByPredicate(p => p.PlanoId == obj.PlanoId || (p.Franquia.Contains(obj.Franquia) && p.Status)).ToList();
        }

        public ICollection<PlanoTelefoniaVO> FiltrosEspecificos(PlanoTelefoniaVO obj)
        {
            var query = (from p in Db.Planos
                         from t in Db.TipoPlanos.DefaultIfEmpty()
                                .Where(x => x.TipoPlanoId == p.TipoPlanoId && x.Status)
                         from o in Db.Operadoras.DefaultIfEmpty()
                                .Where(x => x.OperadoraId == p.OperadoraId && x.Status)
                         from d in Db.DDDs.DefaultIfEmpty()
                                .Where(x => x.DDDId == o.DDDId && x.Status)
                         orderby p.Franquia
                         where (p.Status
                               && d.CodDDD == obj.CodDDD)
                               || (p.TipoPlano.Descricao == obj.DescricaoTipoPlano
                               || o.Nome == obj.NomeOperadora)
                         select new PlanoTelefoniaVO()
                         {
                             Minutos = p.Minutos,
                             Franquia = p.Franquia,
                             Valor = p.Valor,
                             IdTipoPlano = p.TipoPlanoId,
                             IdOperadora = p.OperadoraId,
                             DataCadastro = p.DataCadastro,
                             DataAlteracao = p.DataAlteracao,
                             Status = p.Status,
                             DescricaoTipoPlano = t.Descricao,
                             NomeOperadora = o.Nome,
                             IdDDD = o.DDDId,
                             CodDDD = d.CodDDD,
                             UF = d.UF,
                             CidadePrincipal = d.CidadePrincipal
                         });

            return query.ToList();
        }

        #endregion
    }
}
