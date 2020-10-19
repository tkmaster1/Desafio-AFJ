using AFJ.Empregos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AFJ.Empregos.Data.EntityConfig
{
    public class OperadoraConfiguration : EntityTypeConfiguration<Operadora>
    {
        public OperadoraConfiguration()
        {
            HasKey(c => c.OperadoraId);

            Property(c => c.Nome)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.DataAlteracao);

            Property(c => c.Status)
                .IsRequired();

            HasOptional(x => x.DDD)
                .WithMany(x => x.Operadoras)
                .HasForeignKey(x => x.DDDId);

            ToTable("Operadora");
        }
    }
}
