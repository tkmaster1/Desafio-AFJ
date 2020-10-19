using AFJ.Empregos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AFJ.Empregos.Data.EntityConfig
{
    public class PlanoConfiguration : EntityTypeConfiguration<Plano>
    {
        public PlanoConfiguration()
        {
            HasKey(c => c.PlanoId);

            Property(c => c.Franquia)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Minutos)
                .IsRequired();

            Property(c => c.Valor)
                .HasColumnType("numeric")
                .HasPrecision(6, 0);

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.DataAlteracao);

            Property(c => c.Status)
                .IsRequired();

            HasOptional(x => x.TipoPlano)
                .WithMany(x => x.Planos)
                .HasForeignKey(x => x.TipoPlanoId);

            HasOptional(x => x.Operadora)
                .WithMany(x => x.Planos)
                .HasForeignKey(x => x.OperadoraId);

            ToTable("Plano");
        }
    }
}
