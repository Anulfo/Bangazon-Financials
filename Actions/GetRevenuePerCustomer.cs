using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials.Actions
{
    public class GetRevenuePerCustomer
    {
        public static void ReadInput()
        {
            Console.WriteLine(@"
                    
*********************************************
**                                         **
**    BANGAZON FINANCIAL REPORT            **
**                                         ** 
*********************************************

Revenue Per Customer
---------------------

Customer                     Revenue
......................................
");
            var connectionString = $"Filename={System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH")}";

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            SqliteCommand cs = new SqliteCommand();
            cs.Connection = new SqliteConnection(connectionString);
            cs.CommandType = CommandType.Text;
            SqliteDataReader reader;

            cs.CommandText = @"SELECT CustomerFirstName || ' ' || CustomerLastName AS CustomerName, " +  
                "SUM(ProductRevenue) AS ProductRevenue FROM Revenue GROUP BY " +
                "CustomerName ORDER BY ProductRevenue desc";
            cs.Connection.Open();
            reader = cs.ExecuteReader();
            while (reader.Read())
            {
                var customerName = reader[0];
                var customerNameString = customerName.ToString();
                var revenue = reader[1];
                var revenueString = revenue.ToString();
                var productRevenueInteger = int.Parse(revenueString);
                var straightupbull = new KeyValuePair<string, int>(customerNameString, productRevenueInteger);

                reportValues.Add(straightupbull);
            }

            foreach (var y in reportValues)
            {
                Console.WriteLine(String.Format("{0,-30}" + "{1:c0}", y.Key, y.Value));
            }
            Console.WriteLine("");
            Console.WriteLine("Press a key to go back to MainMenu");
            Console.ReadLine();
        }
    }
}

