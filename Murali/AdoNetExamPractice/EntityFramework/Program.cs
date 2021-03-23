using System;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Execution.updateproducts(103,"carroms");
            Execution.insert("hockeystick");
            Execution.DisplayProducts();
            Execution.Displaycustomers();
        }
    }
}
