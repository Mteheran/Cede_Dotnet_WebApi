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
        }
    }
}
