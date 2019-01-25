namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteseed : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Users");
        }
        
        public override void Down()
        {
        }
    }
}
