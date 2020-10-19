using System;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Domain.Entities
{
    public class Plano
    {
        [Key]
        public int PlanoId { get; set; }

        public int Minutos { get; set; }

        public string Franquia { get; set; }

        public decimal? Valor { get; set; }

        public int? TipoPlanoId { get; set; }

        public int? OperadoraId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Status { get; set; }

        public virtual TipoPlano TipoPlano { get; set; }

        public virtual Operadora Operadora { get; set; }
    }
}
