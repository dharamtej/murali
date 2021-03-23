using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
 public class ordersDal
    {
        static string connecting = ConfigurationManager.ConnectionStrings["connections"].ConnectionString;
        public DataTable findorders()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connecting))
            {
                var query = "select * from orders";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                        ad.Fill(table);
                    }
                }
            }
            return table;
        }
    }
}
