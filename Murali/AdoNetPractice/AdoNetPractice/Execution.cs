using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetPractice
{
    class Execution
    {
        private string connectionstring = string.Empty;
        public static void Display()
        {
           string  connectionstring = ConfigurationManager.ConnectionStrings["connectingstring"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstring);
            var query = "Select * from CustomerDetails";
        }
    }
}
