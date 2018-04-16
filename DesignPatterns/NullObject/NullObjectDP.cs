using NullObject.Client;
using NullObject.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.NullObject
{
    public class NullObjectDP : IDesignPattern
    {
        public void Run()
        {
            Product productWithNullDiscount = new Product()
            {
                Name = "product 1",
                Price = new Price()
                {
                    InitialPrice = 10m
                }
            };

            Product productWithDiscount = new Product()
            {
                Name = "product 1",
                Price = new Price()
                {
                    InitialPrice = 10m
                }
            };

            productWithDiscount.Price.Discount = new Percent10Discount();

            Console.WriteLine("product with nulldiscount " + productWithNullDiscount.FinalPrice);
            Console.WriteLine("product with a real discount " + productWithDiscount.FinalPrice);
        }
    }
}
