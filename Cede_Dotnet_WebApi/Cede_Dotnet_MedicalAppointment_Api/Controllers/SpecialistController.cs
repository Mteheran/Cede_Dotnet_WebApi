using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Api.Controllers
{
    public class SpecialistController : ODataController
    {
        [EnableQuery]
        public IEnumerable<Specialist> Get()
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            return medicalAppointment.Specialists.ToList();
        }
    }
}
