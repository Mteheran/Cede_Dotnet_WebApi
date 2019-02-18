using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Microsoft.AspNet.OData;
using System.Collections.Generic;
using System.Linq;

namespace Cede_Dotnet_MedicalAppointment_Api.Controllers
{
    public class DisponibilityController : ODataController
    {
        [EnableQuery]
        public List<Disponibility> Get()
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            return medicalAppointment.Disponibilities.ToList();
        }
    }
}
