using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Api.Controllers
{
    public class AppointmentController : ODataController
    {
        [EnableQuery]
        public IEnumerable<Appointment> GetByUser(string Id)
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            var userId = Guid.Parse(Id);

            return medicalAppointment.Appointments.Where(p=> p.UserId == userId).ToList();
        }

        public Appointment Get(string Id)
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            var Appointmentid = Guid.Parse(Id);

            return medicalAppointment.Appointments.FirstOrDefault(u => u.AppointmentId == Appointmentid);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Appointment Appointment)
        {
            using (var medicalAppointment = new MedicalAppointmentContext())
            {
                var newAppointment = medicalAppointment.Appointments.Add(Appointment);

                medicalAppointment.SaveChanges();

                return Ok(newAppointment);
            }
        }

        [HttpPatch]
        public IHttpActionResult UpdateStatus([FromBody] Appointment Appointment, string Id)
        {
            using (var medicalAppointment = new MedicalAppointmentContext())
            {
                var Appointmentid = Guid.Parse(Id);

                var oldAppointment = medicalAppointment.Appointments.FirstOrDefault(u => u.AppointmentId == Appointmentid);

                oldAppointment.AppointmentStatus = Appointment.AppointmentStatus;

                medicalAppointment.SaveChanges();

                return Ok(Appointment);
            }
        }
    }
}
