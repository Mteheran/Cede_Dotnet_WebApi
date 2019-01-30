using Cede_Dotnet_MedicalAppointment_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_MedicalAppointment_EF.Context
{
    public class MedicalAppointmentContext : DbContext
    {
        public MedicalAppointmentContext() : base("MAcnx")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Disponibility> Disponibilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Disponibility>().HasIndex(d => d.Hour);

            modelBuilder.Entity<Specialist>().HasMany<Disponibility>(s => s.Disponibilities);

            modelBuilder.Entity<Disponibility>().HasRequired(s => s.Specialist);

            base.OnModelCreating(modelBuilder);
        }

    }
}
