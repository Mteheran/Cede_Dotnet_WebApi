using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.EF
{
    public static class DepartamentoEF
    {
        public static List<Departamento> GetDepartamentos()
        {
            var context = new DBCursosEntities();

            List<Departamento> lstDepartamentos = new List<Departamento>();

            foreach (var item in context.Departamentoes)
            {
                lstDepartamentos.Add(new Departamento() { Id = item.Id, NombreDepartamento = item.NombreDepartamento} );
            }

            return lstDepartamentos;
        }
    }
}
