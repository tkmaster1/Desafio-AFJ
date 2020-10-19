namespace AFJ.Empregos.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultConnectionv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DDD",
                c => new
                    {
                        DDDId = c.Int(nullable: false, identity: true),
                        CodDDD = c.String(nullable: false, maxLength: 2, unicode: false),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                        CidadePrincipal = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DDDId);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        OperadoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        IdDDD = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OperadoraId);
            
            CreateTable(
                "dbo.Plano",
                c => new
                    {
                        PlanoId = c.Int(nullable: false, identity: true),
                        Minutos = c.Int(nullable: false),
                        Franquia = c.String(nullable: false, maxLength: 150, unicode: false),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        IdTipoPlano = c.Int(),
                        IdOperadora = c.Int(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlanoId);
            
            CreateTable(
                "dbo.TipoPlano",
                c => new
                    {
                        TipoPlanoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPlanoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoPlano");
            DropTable("dbo.Plano");
            DropTable("dbo.Operadora");
            DropTable("dbo.DDD");
        }
    }
}
