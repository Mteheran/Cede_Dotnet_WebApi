using Cede_Dotnet_WebApi.ADOSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.ADOSample
{
    public static class DepartamentoData
    {
        public static List<Departamento> GetDepartamentos()
        {
            IConnection connection = new Connection();

            var data = connection.GetInfo("SELECT Id,NombreDepartamento FROM Departamento");

            List<Departamento> departamentos = new List<Departamento>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                departamentos.Add(new Departamento() { Nombre = data.Rows[i]["NombreDepartamento"].ToString(), Id = int.Parse(data.Rows[i]["Id"].ToString()) });
            }

            return departamentos;
        }        
    }
}
