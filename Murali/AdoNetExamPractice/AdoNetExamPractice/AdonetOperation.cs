using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetExamPractice
{
   public class AdonetOperation
    {
        string connectstring = string.Empty;
        public void Display()
        {
            connectstring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectstring);
            var query = "select * from CustomerDetails";
            SqlCommand command = new SqlCommand(query,connect);
            SqlDataAdapter ad = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                connect.Open();
                ad.Fill(table);
                connect.Close();
                foreach(DataRow row in table.Rows)
                {
                    Console.WriteLine(row["CustomerName"]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("something Went Wrong"+ex.ToString());
            }
            finally
            {
                table.Dispose();
                ad.Dispose();
                connect.Close();
            }
        }
    }
}
 