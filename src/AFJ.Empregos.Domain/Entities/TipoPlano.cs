using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Domain.Entities
{
    public class TipoPlano
    {
        public TipoPlano()
        {
            Planos = new List<Plano>();
        }

        [Key]
        public int TipoPlanoId { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Plano> Planos { get; set; }
    }
}
