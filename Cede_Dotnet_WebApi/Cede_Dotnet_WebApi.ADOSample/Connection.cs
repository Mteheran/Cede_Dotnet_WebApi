using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.ADOSample
{
    public class Connection : IConnection
    {
        private SqlConnection con { get; set; } = new SqlConnection();

        public Connection()
        {
            con.ConnectionString = ConfigurationManager.AppSettings["cnx"].ToString();
        }

        public DataTable GetInfo(string query)
        {
            SqlCommand command = new SqlCommand(query, con);

            // No conectado
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable result = new DataTable();
            con.Open();
            dataAdapter.Fill(result);

            con.Close();

            return result;

        }

        public DataTable GetInfoConected(string query)
        {
            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            //Conectado
            SqlDataReader sqlDataReader = command.ExecuteReader();

            DataTable result = new DataTable();

            result.Columns.Add(new DataColumn("ID"));
            result.Columns.Add(new DataColumn("NombreDepartamento"));

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    result.Rows.Add(sqlDataReader.GetValue(0), sqlDataReader.GetValue(1));
                }
            }

            sqlDataReader.Close();

            con.Close();

            return result;

        }

        public bool ExecuteQuery(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, con);

                con.Open();

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public bool ExecuteSP(string nameSP, Dictionary<string, object> parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(nameSP, con);

                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                con.Open();

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
