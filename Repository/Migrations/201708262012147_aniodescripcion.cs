namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniodescripcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnioAcademico", "Descripcion", c => c.String());
            AddColumn("dbo.AnioAcademico", "Anio", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnioAcademico", "Anio");
            DropColumn("dbo.AnioAcademico", "Descripcion");
        }
    }
}
