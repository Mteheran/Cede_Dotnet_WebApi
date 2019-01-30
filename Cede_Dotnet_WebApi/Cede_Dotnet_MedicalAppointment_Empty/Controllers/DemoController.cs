using Cede_Dotnet_MedicalAppointment_Empty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Empty.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [NonAction]
        public string Helloworld()
        {
            return $"HelloWorld ";
        }

        [HttpGet]
        [ActionName("Demo")]
        public string Demo()
        {
            return $"HelloWorld ";
        }

        [HttpGet]
        [ActionName("Demo")]
        public string Demo(int? Id)
        {
            return $"HelloWorld {Id}";
        }

        [HttpGet]
        [Route("api/HelloWorld2/hello")]
        public string HelloWorld2()
        {
            return $"HelloWorld 2";
        }

        [HttpGet]
        [ActionName("DateTime")]
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet]
        [Route("Users")]
        public List<User> Users()
        {
            return Getusers();
        }

        [HttpGet]
        [Route("UsersMessage")]
        public HttpResponseMessage UsersMessage()
        {
            List<User> users = Getusers();

            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK, "users", new MediaTypeHeaderValue("text/html"));
            responseMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(users));
            responseMessage.Headers.CacheControl = new CacheControlHeaderValue()
            {
                NoCache = false
            };

            return responseMessage;
        }

        [Route("api/User")]
        [AcceptVerbs("POST","PATCH")]
        public IHttpActionResult SaveUser([FromBody] User user)
        {
            user.UserId = Guid.NewGuid().ToString();

            return Ok(user);
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
