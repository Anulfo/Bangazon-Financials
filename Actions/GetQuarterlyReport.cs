using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials.Actions
{
    public class GetQuarterlyReport
    {
        public static void ReadInput()
        {
            Console.WriteLine(@"
                    
*********************************************
**                                         **
**    BANGAZON FINANCIAL REPORT            **
**                                         ** 
*********************************************

Quarterly Report
-------------

Product                     Amount
......................................
");
            
            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            MultiFactory multiFactory = new MultiFactory();
            reportValues = multiFactory.QuarterlyReport();

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

