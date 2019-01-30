namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexHourInDisponibility : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Disponibility", "Hour");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Disponibility", new[] { "Hour" });
        }
    }
}
