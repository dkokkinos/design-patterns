using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Expressions
{
    public class Literal : Expression
    {
        public object Value { get; set; }

        public Literal(object value)
        {
            Value = value;
        }

        public override object Clone()
            => MemberwiseClone();

        public override string ToString() => Value.ToString();
    }
}
