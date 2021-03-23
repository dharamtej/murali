using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework
{
  public  class Execution
    {
        public static void DisplayProducts()
        {
            using (context context = new context())
            {
                var Productss = context.Product;
                foreach (var item in Productss)
                {
                    Console.WriteLine(item.ProductId+"\t"+item.Product);
                }
            }
        }
        public static void Displaycustomers()
        {
            using (context context = new context())
            {
                var customers = context.CustomerDetails;
                foreach (var item in customers)
                {
                    Console.WriteLine(item.Sno+"\t"+item.CustomerName+"\t"+item.PhoneNumber+"\t"+item.ProductId);
                }
            }
        }
        public static void updateproducts(int id,string name)
        {
            using (context con = new context())
            {
                var update = con.Product.Where(s=>s.ProductId == id).FirstOrDefault();
                if(update!=null)
                {
                    update.Product = name;
                    con.Entry(update).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    con.SaveChanges();
                }
            }
        }
        public static void insert(string product)
        {
            using(context con = new context())
            {
                products pro = new products()
                {
                    Product = product
                };
                con.Product.Add(pro);
                con.SaveChanges();
            }
        }
    }
}
