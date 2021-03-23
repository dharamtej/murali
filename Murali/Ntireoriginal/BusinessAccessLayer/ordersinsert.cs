using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace BusinessAccessLayer
{
   public class ordersinsert
    {
        string connection = ConfigurationManager.ConnectionStrings["connections"].ConnectionString;

        public void insertion()
        {
            using(SqlConnection connect = new SqlConnection(connection))
            {
                // var query = "insert into Orders1(Name,PhoneNumber,ID)values(@Name,@Phonenumber,@ID)";
                //var query = "update Orders1 set Name = @Name,PhoneNumber=@PhoneNumber,ID=@ID where Name = '@Name'";
                var query = "delete from Orders1 where Name='Sivareddy'";
                using(SqlCommand command = new SqlCommand(query,connect))
                {
                    connect.Open();
                    //command.Parameters.AddWithValue("@Name","sravan");
                    //command.Parameters.AddWithValue("@PhoneNumber", "7845961");
                    //command.Parameters.AddWithValue("@ID", 1002);
                    
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }

        }
    }
}
