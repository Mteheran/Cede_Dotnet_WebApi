namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnPhone2Specialist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specialists", "Phone2", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialists", "Phone2");
        }
    }
}
