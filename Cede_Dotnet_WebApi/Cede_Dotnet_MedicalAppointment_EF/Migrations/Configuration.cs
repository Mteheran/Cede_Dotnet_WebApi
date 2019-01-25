namespace Cede_Dotnet_MedicalAppointment_EF.Migrations
{
    using Cede_Dotnet_MedicalAppointment_EF.Entities;
    using Cede_Dotnet_MedicalAppointment_EF.Entities.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cede_Dotnet_MedicalAppointment_EF.Context.MedicalAppointmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cede_Dotnet_MedicalAppointment_EF.Context.MedicalAppointmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(new User() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "William", LastName = "Ramirez", Nit = "0001", Genre = Genre.Male, BirthDay = new DateTime(1990,1,1), NitDate = new DateTime(2008,5,6) });
            context.Users.AddOrUpdate(new User() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Sofia", LastName = "Cano", Nit = "0002", Genre = Genre.Female, BirthDay = new DateTime(1995,1,1), NitDate = new DateTime(2013,01,01) });

        }
    }
}
