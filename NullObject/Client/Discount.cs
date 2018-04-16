using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Client
{
    public abstract class Discount
    {
        public abstract decimal Calculate(decimal amount);
    }
}
