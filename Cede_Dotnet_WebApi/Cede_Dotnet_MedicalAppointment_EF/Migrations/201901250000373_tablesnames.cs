namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesnames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Appointments", newName: "Appointment");
            RenameTable(name: "dbo.Specialists", newName: "Specialist");
            RenameTable(name: "dbo.Disponibilities", newName: "Disponibility");
            RenameTable(name: "dbo.Users", newName: "User");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Disponibility", newName: "Disponibilities");
            RenameTable(name: "dbo.Specialist", newName: "Specialists");
            RenameTable(name: "dbo.Appointment", newName: "Appointments");
        }
    }
}
