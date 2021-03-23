using System;
using System.Data;
using BusinessLayer;


namespace NtireArchitecturePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet set = new DataSet();
            try
            {
                Customerorder order = new Customerorder();
                set = order.getDetails();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error occured"+ex.ToString());
            }
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Console.WriteLine(row["customer_id"]+"\t"+row["Customer_name"]+"\t"+row["city"]+"\t"+row["grade"]);
            }
            foreach (DataRow row in set.Tables[1].Rows)
            {
                Console.WriteLine(row["order_no"]+"\t"+row["purchase_amount"]+"\t"+row["order_date"]);
            }

        }
    }
}
