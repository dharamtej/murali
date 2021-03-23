using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatatablePractice
{
  public   class DatatableExample
    {
         public static void DataExample()
        {
            DataTable table = new DataTable();
            // creating columns for datatable
            DataColumn Number = new DataColumn("number",typeof(System.Int32));
            table.Columns.Add(Number);
            DataColumn Name = new DataColumn("name",typeof(string));
            table.Columns.Add(Name);
            DataColumn Address = new DataColumn("Address",typeof(string));
            table.Columns.Add(Address);
            DataColumn Email = new DataColumn("Email", typeof(string));
            table.Columns.Add(Email);
            Number.AutoIncrement = true;
            Number.AutoIncrementSeed = 1;
            Number.ReadOnly = true;
            DataColumn[] primary = new DataColumn[1];
            primary[0] = Number;
            table.PrimaryKey = primary;
            table.Rows.Add(1,"Murali","Nellore","murali@gmail.com");
            table.Rows.Add(2,"krishna","mehaboobnagar","krishna@gmail.com");
            table.Rows.Add(3,"kumar","mehaboobnagar","kumar@gmail.com");

            //modify the data in datatable
            table.Rows[1]["Name"] = "sravan";
            table.Rows[1]["Address"] = "village";
            table.Rows[1]["Email"] = "sravan@gmail.com";
            table.AcceptChanges();


            //Deleting Data in DataTable
            table.Rows[1].Delete();
            table.AcceptChanges();


            //to get maximum values of Particular colomn
           var sum = table.Select("Number = max(Number)");
            Console.WriteLine(sum);
            //sorting the values of DataTable

            DataView view = new DataView(table);
            view.Sort = "Number DSEC";
            foreach (DataView  item in view)
            {
               // Console.WriteLine(item[].ToString());
            }

            foreach (DataRow  row in table.Rows)
            {
                Console.WriteLine(row["Number"]+"\t"+row["Name"]+"\t"+row["Address"]+"\t"+row["Email"]);
            }
        }
    }
}
