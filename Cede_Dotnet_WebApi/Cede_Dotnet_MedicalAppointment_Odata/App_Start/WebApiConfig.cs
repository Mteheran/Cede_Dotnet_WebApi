using Cede_Dotnet_MedicalAppointment_Odata.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Cede_Dotnet_MedicalAppointment_Odata
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>("User");
            config.MapODataServiceRoute("User", "api", builder.GetEdmModel());
            config.Filter().Count().OrderBy().Select().Expand().MaxTop(10000);
        }
    }
}
