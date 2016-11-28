using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials.Actions
{
    public class MainMenu
    {
        public static void ReadInput()
        {
            string choice = null;
            while (choice == null || choice.ToLower() != "x")
            {
                Console.WriteLine(@"
                    
*********************************************
**                                         **
**    BANGAZON FINANCIAL REPORT            **
**                                         ** 
*********************************************


1.Weekly Report.

2.Monthly Report.

3.Quarterly Report.

4.Customer Revenue Report.

5.Product Revenue Report.

x.Exit Financial Report");

                var acceptableInputs = new List<int> { 1, 2, 3, 4, 5 };

                choice = Console.ReadLine();

                try
                {
                    int selection = Convert.ToInt32(choice);

                    if (acceptableInputs.Contains(selection))
                    {
                        if (selection == 1)
                        {
                            GetWeeklyReport.ReadInput();
                        }
                        
                        if (selection == 2)
                        {
                            //GetMonthlyReport.ReadInput();
                        }
                        if (selection == 3)
                        {
                            //GetQuarterlyReport.ReadInput();
                        }
                        if (selection == 4)
                        {
                            //GetRevenuePerCustomer.ReadInput();
                        }
                        if (selection == 5)
                        {
                            //GetRevenuePerProduct.ReadInput();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select a number from the options above");
                    }
                }
                catch
                {
                    Console.WriteLine("Please select a number from the options above");
                };
            }
        }
    }
}
