using AFJ.Empregos.Data.EntityConfig;
using AFJ.Empregos.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace AFJ.Empregos.Data.Context
{
    public class AFJEmpregosDDDContext : DbContext
    {
        #region Constructor

        public AFJEmpregosDDDContext() : base("DefaultConnection")
        {
        }

        #endregion

        #region DbSets

        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<TipoPlano> TipoPlanos { get; set; }

        #endregion

        #region DbModel e SaveChanges

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties 
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new DDDConfiguration());
            modelBuilder.Configurations.Add(new OperadoraConfiguration());
            modelBuilder.Configurations.Add(new PlanoConfiguration());
            modelBuilder.Configurations.Add(new TipoPlanoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAlteracao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        #endregion
    }
}
