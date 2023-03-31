using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Product
    {
        public string Code { get; }
        public decimal Price { get; }
        public int Stock { get; set; }

        public Product(string code, decimal price, int stock)
        {
            Code = code;
            Price = price;
            Stock = stock;
        }
    }
}
