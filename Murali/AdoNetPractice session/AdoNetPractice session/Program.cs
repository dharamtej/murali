using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetPractice_session
{
    class Program
    {
        private string ConnectingString = string.Empty;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Display();
            // insert();
            //transcation();
            // Delete();
            //update();
            //storedProcedure();
            StoredDelete();
        }
        public static void update()
        {
            string ConnectingString = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            Console.WriteLine("enter the product Name");
            var Name = Console.ReadLine();
            SqlConnection connection = new SqlConnection(ConnectingString);
            var query2 = "update Product set Product = '@Name' where Product = 'Name'";
            SqlCommand command = new SqlCommand(query2, connection);
            try
            {
                connection.Open();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@Name",SqlDbType.VarChar,50);
                prms[0].Value = Name;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update is not done"+ex.Message);
            }
        }
        public static void Delete()
        {
            string ConnectingString = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectingString);
            var sql = "delete from CustomerDetails where CustomerName = 'gopal'";
            SqlCommand command = new SqlCommand(sql,connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("SomeThing Went Wrong"+ex.Message);
            }
        }
        public static void transcation()
        {
            string ConnectingString = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectingString))
            {
                connection.Open();
                var transcation = connection.BeginTransaction();
                try
                {
                    var query = "insert into CustomerDetails(CustomerName)values(@name)";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@name","gopal");
                        command.Transaction = transcation;
                        command.ExecuteNonQuery();
                    }

                    var query1 = "insert into Product(Product)values(@Product)";
                    using (SqlCommand command = new SqlCommand(query1,connection))
                    {
                        command.Parameters.AddWithValue("@Product","VolleyBall");
                        command.Transaction = transcation;
                        command.ExecuteNonQuery();
                    }
                    transcation.Commit();
                    connection.Close();


                }
                catch (Exception ex)
                {

                    Console.WriteLine("something Went Wrong"+ex.Message);
                }
                finally
                {
                    transcation.Dispose();
                }
            }

           
        }
        public static void Display()
        {
            string ConnectingString = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectingString);
            var query = "select * from CustomerDetails";
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter dta = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                dta.Fill(table);
                connection.Close();
                foreach(DataRow row in table.Rows)
                {
                    Console.WriteLine(row["CustomerName"]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Some thing Went Wrong"+ex.ToString());
            }
            finally
            {
                table.Dispose();
                dta.Dispose();
                command.Dispose();
                connection.Close();
            }
        }
        public static void insert()
        {
            Console.WriteLine("enter the CustomerName,Phonenumber,ProductId");
            var Name = Console.ReadLine();
            var Number = Console.ReadLine();
            int id = int.Parse(Console.ReadLine());
            string ConnectingString = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectingString);
            var query = "insert into CustomerDetails(CustomerName,Phonenumber,ProductId)values(@CustomerName,@PhoneNumber,@Productid)";
            SqlCommand command = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);
                parameters[0].Value = Name;
                parameters[1] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 50);
                parameters[1].Value = Number;
                parameters[2] = new SqlParameter("@Productid", SqlDbType.Int);
                parameters[2].Value = id;
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Some thing Went Wrong"+ex.Message);
            }

        }
        public  static void storedProcedure()
        {
            string ConnectingString = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectingString))
            {
                using (SqlCommand command = new SqlCommand("Details",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                       
                        ad.Fill(table);
                    }

                }

            }
            foreach (DataRow  item in table.Rows)
            {
                Console.WriteLine(item["CustomerName"]);
            }
        }
        public static void StoredDelete()
        {
            
            string conect = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conect) )
            {
                using (SqlCommand command  = new SqlCommand("Details",connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("id", 101);
                    command.ExecuteNonQuery();
                    connection.Close();
                    
                }
            }
        }
    }
}
