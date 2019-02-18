using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Microsoft.AspNet.OData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Api.Controllers
{
    [Route("api/Appointment")]
    public class AppointmentController : ApiController
    {
        [EnableQuery]
        public IEnumerable<Appointment> GetByUser(string Id)
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            var userId = Guid.Parse(Id);

            return medicalAppointment.Appointments.Where(p=> p.UserId == userId).ToList();
        }

        [EnableQuery]
        public Appointment Get(string Id)
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            var Appointmentid = Guid.Parse(Id);

            return medicalAppointment.Appointments.FirstOrDefault(u => u.AppointmentId == Appointmentid);
        }

        [EnableQuery]
        public List<Appointment> Get()
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            return medicalAppointment.Appointments.ToList();
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(HttpRequestMessage request)
        {
            string body = await request.Content.ReadAsStringAsync();

            if (!String.IsNullOrEmpty(body))
            {
                JObject json = JObject.Parse(body);

                using (var medicalAppointment = new MedicalAppointmentContext())
                {
                    var appointmentobject = JsonConvert.DeserializeObject<Appointment>(json.ToString());                  
                    Appointment appointment = new Appointment();
                    appointment.AppointmentId = Guid.NewGuid();
                    appointment.AppointmentDate = appointmentobject.AppointmentDate;
                    appointment.SpecialistId = appointmentobject.SpecialistId;
                    appointment.AppointmentStatus = appointmentobject.AppointmentStatus;
                    appointment.UserId = appointmentobject.UserId;
                    var newAppointment = medicalAppointment.Appointments.Add(appointment);

                    medicalAppointment.SaveChanges();

                    return Ok(newAppointment);
                }
            }

            return BadRequest();
           
        }

        [Route("")]
        [HttpPatch]
        public IHttpActionResult UpdateStatus(Appointment Appointment, string Id)
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
