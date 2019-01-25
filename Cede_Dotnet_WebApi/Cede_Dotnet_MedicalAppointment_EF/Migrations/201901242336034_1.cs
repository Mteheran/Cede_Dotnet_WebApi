namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        SpecialistId = c.Guid(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 50),
                        AppointmentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Specialists", t => t.SpecialistId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SpecialistId);
            
            CreateTable(
                "dbo.Specialists",
                c => new
                    {
                        SpecialistId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Specialty = c.Int(nullable: false),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        SpecialistStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialistId);
            
            CreateTable(
                "dbo.Disponibilities",
                c => new
                    {
                        DisponibilityId = c.Guid(nullable: false),
                        Hour = c.Short(nullable: false),
                        SpecialistId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DisponibilityId)
                .ForeignKey("dbo.Specialists", t => t.SpecialistId, cascadeDelete: true)
                .Index(t => t.SpecialistId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Nit = c.String(nullable: false, maxLength: 30),
                        NitType = c.Int(nullable: false),
                        NitDate = c.DateTime(nullable: false),
                        Contract = c.String(maxLength: 100),
                        BirthDay = c.DateTime(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Disponibilities", "SpecialistId", "dbo.Specialists");
            DropForeignKey("dbo.Appointments", "SpecialistId", "dbo.Specialists");
            DropIndex("dbo.Disponibilities", new[] { "SpecialistId" });
            DropIndex("dbo.Appointments", new[] { "SpecialistId" });
            DropIndex("dbo.Appointments", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Disponibilities");
            DropTable("dbo.Specialists");
            DropTable("dbo.Appointments");
        }
    }
}
