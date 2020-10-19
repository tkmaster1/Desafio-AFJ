using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Domain.Entities
{
    public class Operadora
    {
        [Key]
        public int OperadoraId { get; set; }

        public string Nome { get; set; }

        public int? DDDId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Plano> Planos { get; set; }

        public virtual DDD DDD { get; set; }
    }
}
