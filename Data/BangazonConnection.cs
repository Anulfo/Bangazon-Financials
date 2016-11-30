using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financials.Data
{
    public class BangazonConnection
    {
        private string _connectionString = $"Filename={System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH")}";

        public void execute (string query, Action<SqliteDataReader> handler)
        {
            //Establish connection with the database
            SqliteConnection dbconnection = new SqliteConnection(_connectionString);
            dbconnection.Open();
            SqliteCommand dbcommand = dbconnection.CreateCommand();
            dbcommand.CommandText = query;

            using (var reader = dbcommand.ExecuteReader())
            {
                handler(reader);
            }

            dbcommand.Dispose();
            dbconnection.Close();   


        }

    }
}
