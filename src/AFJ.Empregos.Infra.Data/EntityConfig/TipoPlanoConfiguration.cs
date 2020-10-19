using AFJ.Empregos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AFJ.Empregos.Data.EntityConfig
{
    public class TipoPlanoConfiguration : EntityTypeConfiguration<TipoPlano>
    {
        public TipoPlanoConfiguration()
        {
            HasKey(c => c.TipoPlanoId);

            Property(c => c.Descricao)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.DataAlteracao);

            Property(c => c.Status)
                .IsRequired();

            ToTable("TipoPlano");
        }
    }
}
