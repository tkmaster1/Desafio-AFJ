using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Application.ViewModels
{
    public class OperadoraViewModel
    {
        public OperadoraViewModel()
        {
            Planos = new List<PlanoViewModel>();
        }

        [Key]
        public int OperadoraId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Nome { get; set; }

        public int? DDDId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public bool Status { get; set; }

        public virtual ICollection<PlanoViewModel> Planos { get; set; }

        public virtual DDDViewModel DDD { get; set; }
    }
}
