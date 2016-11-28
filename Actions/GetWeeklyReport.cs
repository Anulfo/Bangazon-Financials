using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials.Actions
{
    public class GetWeeklyReport
    {
        public static void ReadInput()
        {
            Console.WriteLine(@"
                    
*********************************************
**                                         **
**    BANGAZON FINANCIAL REPORT            **
**                                         ** 
*********************************************

Weekly Report
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

        cs.CommandText = "SELECT * FROM Revenue WHERE PurchaseDate > DateTime ('now', '-7 days')";
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
            var sevenDaysAgoDate = DateTime.Today.AddDays(-7);
            var straightupbull = new KeyValuePair<string, int>(productNameString, productRevenueInteger);

            reportValues.Add(straightupbull);
        }

        foreach (var y in reportValues)
        {
            Console.WriteLine(string.Format("{0,10}  {1,10}", "{0} {1}", y.Key, y.Value));

        }
        Console.ReadLine();
        }
    }
}
