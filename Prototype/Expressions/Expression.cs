using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Expressions
{
    public abstract class Expression : ICloneable
    {
        public abstract object Clone();
    }
}
