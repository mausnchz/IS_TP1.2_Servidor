namespace IS_TP1._2_Servidor.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionPrueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Nombre);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleadoes");
        }
    }
}
