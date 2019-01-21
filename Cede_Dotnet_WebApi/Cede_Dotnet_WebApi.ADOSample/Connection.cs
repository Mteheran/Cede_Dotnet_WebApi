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

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable result = new DataTable();

            con.Open();

            dataAdapter.Fill(result);

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

    }
}
