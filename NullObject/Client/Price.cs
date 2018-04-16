using NullObject.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Client
{
    public class Price
    {
        public Price()
        {
            this.Discount = new NullDiscount();
        }
        public Discount Discount { get; set; }
        public decimal InitialPrice { get; set; }
        public decimal FinalPrice
        {
            get
            {
                return this.Discount.Calculate(this.InitialPrice);
            }
        }
    }
}
