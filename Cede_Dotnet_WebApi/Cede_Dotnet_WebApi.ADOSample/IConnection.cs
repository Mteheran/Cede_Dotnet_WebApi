using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.ADOSample
{
    public interface IConnection
    {
        DataTable GetInfo(string query);
    }
}
