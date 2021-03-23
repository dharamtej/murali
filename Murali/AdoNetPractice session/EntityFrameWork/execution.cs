using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntityFrameWork
{
    class execution
    {
        public static void list()
        {

            using (context content = new context())
            {
                var order = content.Orders1;
                foreach(var item in order)
                {
                    Console.WriteLine("\t"+item.Name + "\t"+item.PhoneNumber+"\t"+item.ID);
                }
            }
        }
        public static void insert(string name,string phone,int  id)
        {
            using(context context = new context())
            {
                orders add = new orders()
                {
                    Name = name,
                    PhoneNumber=phone,
                    ID=id
                };
                context.Orders1.Add(add);
                context.SaveChanges();

            }
        }
        public static void update(string Name ,string changed)
        {
            using (context context = new context())
            {
                var department = context.Orders1.Where(d => d.Name == Name).FirstOrDefault();
                if(department!=null)
                {
                    department.Name = changed;
                    context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }

            }
        }
        public static void Delete(int id)
        {
            using (context context = new context())
            {
                var order = context.Orders1.Where(s=>s.ID == id).FirstOrDefault();
                if(order !=null)
                {
                    context.Orders1.Remove(order);
                    context.SaveChanges();
                }
            }
        }
    }
}
