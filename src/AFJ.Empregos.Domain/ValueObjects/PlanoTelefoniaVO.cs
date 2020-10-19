using System;

namespace AFJ.Empregos.Domain.ValueObjects
{
    public class PlanoTelefoniaVO
    {
        #region Plano

        public int PlanoId { get; set; }

        public int Minutos { get; set; }

        public int? IdTipoPlano { get; set; }

        public int? IdOperadora { get; set; }

        public string Franquia { get; set; }

        public decimal? Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Status { get; set; }

        #endregion

        #region TipoPlano

        public string DescricaoTipoPlano { get; set; }

        #endregion

        #region Operadora

        public string NomeOperadora { get; set; }

        #endregion

        #region DDD

        public int? IdDDD { get; set; }

        public string CodDDD { get; set; }

        public string UF { get; set; }

        public string CidadePrincipal { get; set; }

        #endregion

    }
}
