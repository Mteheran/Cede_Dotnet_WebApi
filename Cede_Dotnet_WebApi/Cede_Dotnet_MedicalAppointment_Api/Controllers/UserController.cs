using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Api.Controllers
{
    public class UserController : ApiController
    {        
        public IEnumerable<User> Get()
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            return medicalAppointment.Users.ToList();
        }

        public User Get(string Id)
        {
            MedicalAppointmentContext medicalAppointment = new MedicalAppointmentContext();

            var userid = Guid.Parse(Id);

            return medicalAppointment.Users.FirstOrDefault(u => u.UserId == userid);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            using (var medicalAppointment = new MedicalAppointmentContext())
            {
                 var newuser = medicalAppointment.Users.Add(user);

                medicalAppointment.SaveChanges();

                return Ok(newuser);
            }
        }

        [HttpPatch]
        public IHttpActionResult Patch([FromBody] User user, string Id)
        {
            using (var medicalAppointment = new MedicalAppointmentContext())
            {
                var userid = Guid.Parse(Id);

                var oldUser = medicalAppointment.Users.FirstOrDefault(u=> u.UserId == userid);

                oldUser.Name = user.Name;
                oldUser.LastName = user.LastName;
                oldUser.Nit = user.Nit;
                oldUser.Email = user.Email;

                medicalAppointment.SaveChanges();

                return Ok(user);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(string Id)
        {
            using (var medicalAppointment = new MedicalAppointmentContext())
            {
                var userid = Guid.Parse(Id);

                var user = medicalAppointment.Users.FirstOrDefault(u => u.UserId == userid);

                medicalAppointment.Users.Remove(user);

                medicalAppointment.SaveChanges();

                return Ok();
            }
        }


    }
}
