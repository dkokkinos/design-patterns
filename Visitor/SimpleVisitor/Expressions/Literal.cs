using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.SimpleVisitor.Expressions
{
    public class Literal : Expression
    {
        public object Value { get; private set; }

        public Literal(object value)
        {
            Value = value;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
