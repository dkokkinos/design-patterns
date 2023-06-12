using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.GenericVisitor.Expressions
{
    public class Literal : Expression
    {
        public object Value { get; private set; }

        public Literal(object value)
        {
            Value = value;
        }

        public override T Accept<T>(IVisitor<T> visitor)
            => visitor.Visit(this);
    }
}
