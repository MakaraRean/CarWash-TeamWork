using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash1
{
    class DatabaseConnection
    {
        public static SqlConnection DataCon { get; set; }
        public static void ConnectDatabase(string serverName,string databaseName,string userName,string pass)
        {
            string connectionString = "Server=" + serverName + "; Database=" + databaseName + "; User ID=" + userName + " ; Password=" + pass;
            DataCon = new SqlConnection(connectionString);
            DataCon.Open();
        }
        public static void ConnectDatabase(string serverName,string databaseName)
        {
            string ConnectionString = "Server=" + serverName + "; Database=" + databaseName + ";Trusted_Connection=True;";
            DataCon = new SqlConnection(ConnectionString);
            DataCon.Open();
        }
    }
}
