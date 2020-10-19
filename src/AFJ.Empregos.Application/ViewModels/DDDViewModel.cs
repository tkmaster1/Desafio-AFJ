using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Application.ViewModels
{
    public class DDDViewModel
    {
        public DDDViewModel()
        {
            Operadoras = new List<OperadoraViewModel>();
        }

        [Key]
        public int DDDId { get; set; }

        [Required(ErrorMessage = "Preencha o campo DDD")]
        public string CodDDD { get; set; }

        [Required(ErrorMessage = "Preencha o campo UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade Principal")]
        public string CidadePrincipal { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public bool Status { get; set; }

        public virtual ICollection<OperadoraViewModel> Operadoras { get; set; }
    }
}