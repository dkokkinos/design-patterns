using NullObject.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Plugin
{
    public class Percent10Discount : Discount
    {
        private readonly float _discountPercentage = 0.9f;
        public override decimal Calculate(decimal amount)
        {
            return amount * Convert.ToDecimal(this._discountPercentage);
        }
    }
}
