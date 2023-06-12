using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.GenericVisitor.Expressions
{
    public class Group : Expression
    {
        public Expression Inner { get; }

        public Group(Expression inner)
        {
            Inner = inner;
        }

        public override T Accept<T>(IVisitor<T> visitor)
            => visitor.Visit(this);
    }
}
