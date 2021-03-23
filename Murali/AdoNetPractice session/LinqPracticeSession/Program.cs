using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LinqPracticeSession
{
  public  class Program
    {
        static string connection = string.Empty;
       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            connection = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            var data = GetCustomerDetails();
            foreach(var item in data)
            {
                Console.WriteLine(item.Sno+" "+item.CustomerName+" "+item.PhoneNumber+" "+item.productId);
            }
        }
        public static IList<CustomerDetails> GetCustomerDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection connect = new SqlConnection(connection))
            {
                var query = "select * from CustomerDetails";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    using(SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                        ad.Fill(table);
                    }

                }
            }
            IList<CustomerDetails> customer = new List<CustomerDetails>();
            foreach(DataRow row  in table.Rows)
            {
                var cust = new CustomerDetails()
                {
                    Sno=int.Parse(row["Sno"].ToString()),
                    CustomerName=row["CustomerName"].ToString(),
                    PhoneNumber=row["PhoneNumber"].ToString(),
                    productId=int.Parse(row["ProductId"].ToString())
                };
                customer.Add(cust);
                
            }
            return customer;
        }
    }
}
