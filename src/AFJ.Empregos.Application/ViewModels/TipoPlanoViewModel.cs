using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Application.ViewModels
{
    public class TipoPlanoViewModel
    {
        public TipoPlanoViewModel()
        {
            Planos = new List<PlanoViewModel>();
        }

        [Key]
        public int TipoPlanoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public bool Status { get; set; }

        public virtual ICollection<PlanoViewModel> Planos { get; set; }
    }
}
