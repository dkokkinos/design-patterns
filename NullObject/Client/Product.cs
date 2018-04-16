using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Client
{
    public class Product
    {
        public Product()
        {
            
        }
        public string Name { get; set; }
        public Price Price { get; set; }
        public decimal FinalPrice
        {
            get
            {
                return this.Price.FinalPrice;
            }
        }
    }
}
