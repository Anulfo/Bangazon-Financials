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
            MultiFactory multiFactory = new MultiFactory();
            reportValues = multiFactory.MonthlyReport();

            foreach (var y in reportValues)
            {
                Console.WriteLine(String.Format("{0,-30}" + "{1:c0}", y.Key, y.Value));
            }
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to go back to MainMenu");
            Console.ReadLine();
        }
    }
}

