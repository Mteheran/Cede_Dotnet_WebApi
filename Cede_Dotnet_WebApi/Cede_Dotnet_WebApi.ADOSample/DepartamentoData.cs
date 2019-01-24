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
            IConnection connection = ConnectionContex.GetContext(AppDBTypes.Main);

            var data = connection.GetInfoConected("SELECT Id,NombreDepartamento FROM Departamento");

            List<Departamento> departamentos = new List<Departamento>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                departamentos.Add(new Departamento() { Nombre = data.Rows[i]["NombreDepartamento"].ToString(), Id = int.Parse(data.Rows[i]["Id"].ToString()) });
            }

            return departamentos;
        }

        public static bool InsertDepartamento(Departamento departamento)
        {
            ////INSERT con query
            //IConnection connection = new Connection();

            //string queryInsert = $@" INSERT INTO Departamento
            //                         Values ('{departamento.Nombre}') ";

            //return connection.ExecuteQuery(queryInsert);            

            //INSERT con SP
            IConnection connection = ConnectionContex.GetContext(AppDBTypes.Main);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Nombre", departamento.Nombre);

            return connection.ExecuteSP("INSERTDepartamento", parameters);
        }
    }
}
