using Cede_Dotnet_MedicalAppointment_Odata.Models;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Odata.Controllers
{
    public class UserController : ODataController
    {
        [EnableQuery]
        public List<User> Get()
        {
            return Getusers();
        }

        private List<User> Getusers()
        {
            List<User> lst = new List<User>();

            lst.Add(new Models.User() { Name = "Miguel", Lastname = "Teheran", UserId = Guid.NewGuid().ToString(), Phone = "3054522232" });
            lst.Add(new Models.User() { Name = "Juan Diego", Lastname = "Valencia", UserId = Guid.NewGuid().ToString(), Phone = "45454646" });
            lst.Add(new Models.User() { Name = "Hernan", Lastname = "Arguelles", UserId = Guid.NewGuid().ToString(), Phone = "4545446467" });
            lst.Add(new Models.User() { Name = "Raul", Lastname = "Romero", UserId = Guid.NewGuid().ToString(), Phone = "8585889689" });

            return lst;
        }
    }


}
