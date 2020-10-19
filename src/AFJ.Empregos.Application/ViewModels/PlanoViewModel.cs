using System;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Application.ViewModels
{
    public class PlanoViewModel
    {
        [Key]
        public int PlanoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Minutos")]
        public int Minutos { get; set; }

        [Required(ErrorMessage = "Preencha o campo Franquia")]
        public string Franquia { get; set; }

        public decimal? Valor { get; set; }

        public int? TipoPlanoId { get; set; }

        public int? OperadoraId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public bool Status { get; set; }

        public virtual TipoPlanoViewModel TipoPlano { get; set; }

        public virtual OperadoraViewModel Operadora { get; set; }
    }
}
