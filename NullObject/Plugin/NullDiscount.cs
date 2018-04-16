using NullObject.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Plugin
{
    public class NullDiscount : Discount
    {
        private readonly float _discountPercentage = 1;
        public override decimal Calculate(decimal amount)
        {
            return amount * Convert.ToDecimal(this._discountPercentage); 
        }
    }
}
