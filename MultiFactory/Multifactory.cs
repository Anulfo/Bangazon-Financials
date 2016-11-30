using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Financials.Data;

namespace Bangazon_Financials
{
    public class MultiFactory
    {
        public List<KeyValuePair<string, int>> WeeklyReport()
        {
            BangazonConnection conn = new BangazonConnection();

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            conn.execute(@"SELECT * FROM Revenue WHERE PurchaseDate > DateTime ('now', '-7 days') ORDER BY ProductName",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        var productName = reader[1];
                        var productNameString = productName.ToString();
                        var rawProductCost = reader[2];
                        var productRevenueString = rawProductCost.ToString();
                        var productCostInteger = int.Parse(productRevenueString);
                        var straightupbull = new KeyValuePair<string, int>(productNameString, productCostInteger);

                        reportValues.Add(straightupbull);
                    }

                }); 

            return reportValues;
            }

        public List<KeyValuePair<string, int>> MonthlyReport()
        {
            BangazonConnection conn = new BangazonConnection();

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            conn.execute(@"SELECT * FROM Revenue WHERE PurchaseDate > DateTime ('now', '-30 days') ORDER BY ProductName",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        var productName = reader[1];
                        var productNameString = productName.ToString();
                        var rawProductCost = reader[2];
                        var productRevenueString = rawProductCost.ToString();
                        var productCostInteger = int.Parse(productRevenueString);
                        var straightupbull = new KeyValuePair<string, int>(productNameString, productCostInteger);

                        reportValues.Add(straightupbull);
                    }

                });

            return reportValues;
        }

        public List<KeyValuePair<string, int>> QuarterlyReport()
        {
            BangazonConnection conn = new BangazonConnection();

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            conn.execute(@"SELECT * FROM Revenue WHERE PurchaseDate > DateTime ('now', '-90 days') ORDER BY ProductName",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    { 
                        var productName = reader[1];
                        var productNameString = productName.ToString();
                        var rawProductCost = reader[2];
                        var productRevenueString = rawProductCost.ToString();
                        var productCostInteger = int.Parse(productRevenueString);
                        var straightupbull = new KeyValuePair<string, int>(productNameString, productCostInteger);

                        reportValues.Add(straightupbull);
                    }

                });

            return reportValues;


        }

        public List<KeyValuePair<string, int>> RevenuePerCustomer()
        {
            BangazonConnection conn = new BangazonConnection();

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            conn.execute(@"SELECT CustomerFirstName || ' ' || CustomerLastName AS CustomerName, " +
                "SUM(ProductRevenue) AS ProductRevenue FROM Revenue GROUP BY " +
                "CustomerName ORDER BY ProductRevenue desc",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        var rawCustomerName = reader[0];
                        var customerNameString = rawCustomerName.ToString();
                        var rawRevenuePerCustomer = reader[1];
                        var RevenuePerCustomerString = rawRevenuePerCustomer.ToString();
                        var revenuePerCustomerInteger = int.Parse(RevenuePerCustomerString);
                        var straightupbull = new KeyValuePair<string, int>(customerNameString, revenuePerCustomerInteger);

                        reportValues.Add(straightupbull);
                    }

                });

            return reportValues;
        }

        public List<KeyValuePair<string, int>> RevenuePerProduct()
        {
            BangazonConnection conn = new BangazonConnection();

            List<KeyValuePair<string, int>> reportValues = new List<KeyValuePair<string, int>>();

            conn.execute(@"SELECT ProductName, SUM(productrevenue) as ProductTotalRevenue from revenue
                            group by productname
                            order by ProductTotalRevenue desc",
                (SqliteDataReader reader) =>
                {

                    while (reader.Read())
                    {
                        var rawProductName = reader[0];
                        var productNameString = rawProductName.ToString();
                        var rawRevenuePerProduct = reader[1];
                        var RevenuePerProductString = rawRevenuePerProduct.ToString();
                        var revenuePerProductInteger = int.Parse(RevenuePerProductString);
                        var straightupbull = new KeyValuePair<string, int>(RevenuePerProductString, revenuePerProductInteger);

                        reportValues.Add(straightupbull);
                    }

                });

            return reportValues;
        }
    }
}

