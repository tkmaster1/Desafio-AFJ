using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Domain.Entities
{
    public class DDD
    {
        [Key]
        public int DDDId { get; set; }

        public string CodDDD { get; set; }

        public string UF { get; set; }

        public string CidadePrincipal { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Operadora> Operadoras { get; set; }
    }
}
