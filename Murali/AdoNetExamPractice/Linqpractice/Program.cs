using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Linqpractice
{
    class Program
    {
        static string connectstring = string.Empty;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var Department = Display();
            var Employee = Display1();
            var join = from De in Department
                       join emp in Employee on De.id equals emp.id
                       select new
                       {
                           Name = De.Name,
                           Loc = De.Loc,
                           emp.Salary,
                           emp.DeptNo
                       };
            var join1 = from De in Department
                        join emp in Employee on De.id equals emp.id into joined
                        from j in joined.DefaultIfEmpty()
                       select new
                       {
                           Name = De.Name,
                           Loc = De.Loc,
                           Salary = j.Salary,
                           deptNo = j.DeptNo
                       };

            //foreach (var item in Department)
            //{
            //   Console.WriteLine(item.id + "\t" + item.Name + "\t" + item.Loc );
            //}
            //foreach (var item in Employee)
            //{
            //    Console.WriteLine(item.id + "\t" + item.Name + "\t" + item.Salary+"\t"+item.DeptNo);
            //}
            foreach (var item in join)
            {
                Console.WriteLine(item.Name + "\t" + item.Salary + "\t" + item.DeptNo + "\t" + item.Loc);
            }
            foreach (var item in join1)
            {
                Console.WriteLine(item.Name + "\t" + item.Salary + "\t" + item.deptNo + "\t" + item.Loc);
            }

        }
        public static IList<Department> Display()
        {
            DataTable table = new DataTable();
            connectstring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
               
                var query = "select * from Department";
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        ad.Fill(table);
                        connection.Close();
                    }
                }
            }
            IList<Department> Department = new List<Department>();
            foreach(DataRow row in table.Rows)
            {
                var customer = new Department()
                {
                    id =int.Parse(row["id"].ToString()),
                    Name = row["Name"].ToString(),
                    Loc = row["Loc"].ToString()
                };
                Department.Add(customer);
            }
            return Department;
        }
        public static IList<Employee> Display1()
        {
            DataTable table = new DataTable();
            connectstring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectstring))
            {

                var query = "select * from Employee";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        ad.Fill(table);
                        connection.Close();
                    }
                }
            }
            IList<Employee> Employess = new List<Employee>();
            foreach (DataRow row in table.Rows)
            {
                var Employee = new Employee()
                {
                    id = int.Parse(row["id"].ToString()),
                    Name = row["Name"].ToString(),
                    Salary = row["Salary"].ToString(),
                    DeptNo = int.Parse(row["DeptNo"].ToString())
                };
                Employess.Add(Employee);
            }
            return Employess;
        }
    }
}
