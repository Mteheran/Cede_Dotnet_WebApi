using System.Web;
using System.Web.Mvc;

namespace Cede_Dotnet_MedicalAppointment_Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
