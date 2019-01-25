using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Cede_Dotnet_MedicalAppointment_EF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_MedicalAppointment_EF.Context
{
    public class MedicalAppointmentInitializer : DropCreateDatabaseIfModelChanges<MedicalAppointmentContext>
    {
        protected override void Seed(MedicalAppointmentContext context)
        {
            context.Users.Add(new User() { UserId = Guid.NewGuid(), Name = "William", LastName = "Ramirez", Nit = "0001", Genre = Genre.Male });
            context.Users.Add(new User() { UserId = Guid.NewGuid(), Name = "Sofia", LastName = "Cano", Nit = "0002", Genre = Genre.Female });

            base.Seed(context);
        }
    }
}
