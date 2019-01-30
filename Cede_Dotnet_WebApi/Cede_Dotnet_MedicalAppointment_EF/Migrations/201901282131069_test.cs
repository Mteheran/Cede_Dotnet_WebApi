namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Phone", c => c.Int(nullable: false));
        }
    }
}
