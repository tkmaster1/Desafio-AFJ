using AFJ.Empregos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AFJ.Empregos.Data.EntityConfig
{
    public class DDDConfiguration : EntityTypeConfiguration<DDD>
    {
        public DDDConfiguration()
        {
            HasKey(c => c.DDDId);

            Property(c => c.CodDDD)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.UF)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.CidadePrincipal)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.DataAlteracao);

            Property(c => c.Status)
                .IsRequired();

            ToTable("DDD");
        }
    }
}
