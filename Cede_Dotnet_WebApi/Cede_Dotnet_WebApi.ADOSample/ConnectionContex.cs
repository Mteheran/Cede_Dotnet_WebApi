using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.ADOSample
{
    public static class ConnectionContex
    {
        public static IConnection  GetContext(AppDBTypes appDBTypes)
        {
            switch (appDBTypes)
            {
                case AppDBTypes.Main:
                    return FactoryConnection.GetConnection(ConnectionType.OleDB);
                case AppDBTypes.Log:
                    break;
                case AppDBTypes.External:
                    break;
                default:
                    return null;
            }

            return null;
        }
    }
}
