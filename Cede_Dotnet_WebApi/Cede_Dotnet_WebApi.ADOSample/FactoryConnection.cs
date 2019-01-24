using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.ADOSample
{
    public static class FactoryConnection
    {
        public static IConnection GetConnection(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.SqlServer:
                    return new Connection();
                case ConnectionType.OleDB:
                    return new ConnectionOleDB();
                default:
                    return null;
            }
        }
    }
}
