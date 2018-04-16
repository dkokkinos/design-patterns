using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace DesignPatterns.Template
{
    public class TemplateDP : IDesignPattern
    {
        public void Run()
        {
            DataAccessObject customer = new CustomerReport();

            DataAccessObject products = new ProductsReport();

            if (!File.Exists("customers.txt"))
            {
                File.WriteAllLines("customers.txt", new List<string>()
                {
                    "customer 1","customer 2","customer 3","customer 4"
                });
            }

            if (!File.Exists("products.txt"))
            {
                File.WriteAllLines("products.txt", new List<string>()
                {
                    "product 1","product 2","product 3","product 4"
                });
            }


            Console.WriteLine("running for customers");
            customer.Run();
            
            Console.WriteLine("running for products");
            products.Run();
        }
    }
}
