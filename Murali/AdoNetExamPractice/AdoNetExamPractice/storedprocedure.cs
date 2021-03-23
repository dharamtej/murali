using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetExamPractice
{
    class storedprocedure
    {
        static string connectingstring = string.Empty;
        public static void storedpraocedureExample()
        {
            connectingstring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectingstring))
            {
                using (SqlCommand command = new SqlCommand("customerorders",connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(reader.GetOrdinal("customer_id"))+"\t"+reader.GetString("Customer_name")+"\t"+ reader.GetString("city")+"\t"+reader.GetString("grade")+reader.GetString(reader.GetOrdinal("salesman_id")));
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(reader.GetOrdinal("order_no")) + "\t" + reader.GetString("purchase_amount") + "\t" + reader.GetString("order_date") + "\t" + reader.GetString(reader.GetOrdinal("customer_id")) + reader.GetString(reader.GetOrdinal("salesman_id")));
                        }
                    }
                }
            }
        }
    }
}
