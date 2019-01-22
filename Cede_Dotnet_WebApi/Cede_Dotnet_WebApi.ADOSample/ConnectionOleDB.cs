using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_WebApi.ADOSample
{
    public class ConnectionOleDB : IConnection
    {
        private OleDbConnection con { get; set; } = new OleDbConnection();

        public ConnectionOleDB()
        {
            con.ConnectionString = ConfigurationManager.AppSettings["cnxOleDb"].ToString();
        }

        public DataTable GetInfo(string query)
        {
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

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
                OleDbCommand command = new OleDbCommand(query, con);

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
                OleDbCommand command = new OleDbCommand(nameSP, con);

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
