using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials.Actions
{
    public class GetMonthlyReport
    {
        public static void ReadInput()
        {
            Console.WriteLine(@"
                    
*********************************************
**                                         **
**    BANGAZON FINANCIAL REPORT            **
**                                         ** 
*********************************************

Monthly Report
-------------

Product                     Amount
......................................
");
            var connectionString = $"Filename={System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH")}";

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            SqliteCommand cs = new SqliteCommand();
            cs.Connection = new SqliteConnection(connectionString);
            cs.CommandType = CommandType.Text;
            SqliteDataReader reader;

            cs.CommandText = "SELECT * FROM Revenue WHERE PurchaseDate > DateTime ('now', '-30 days') ORDER BY ProductName";
            cs.Connection.Open();
            reader = cs.ExecuteReader();
            while (reader.Read())
            {
                var productName = reader[1];
                var productNameString = productName.ToString();
                var rawProductCost = reader[2];
                var productCostString = rawProductCost.ToString();
                var productRevenueInteger = int.Parse(productCostString);
                var rawPurchaseDate = reader[9];
                var purchaseDateToString = rawPurchaseDate.ToString();
                var purchaseDateToDateTime = DateTime.Parse(purchaseDateToString);
                var straightupbull = new KeyValuePair<string, int>(productNameString, productRevenueInteger);

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

