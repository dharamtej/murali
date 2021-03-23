using BusinessAccessLayer;
using System;
using System.Data;

namespace Ntireoriginal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //DataSet set = new DataSet();
            //try
            //{
            //    Customerorders order = new Customerorders();
            //    set = order.getDetails();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine("Error occured" + ex.ToString());
            //}
            //foreach (DataRow row in set.Tables[0].Rows)
            //{
            //    Console.WriteLine(row["customer_id"] + "\t" + row["Customer_name"] + "\t" + row["city"] + "\t" + row["grade"]);
            //}
            //foreach (DataRow row in set.Tables[1].Rows)
            //{
            //    Console.WriteLine(row["order_no"] + "\t" + row["purchase_amount"] + "\t" + row["order_date"]);
            //}
            ordersinsert ordersinsert = new ordersinsert();
            ordersinsert.insertion();
        }
    }
}
