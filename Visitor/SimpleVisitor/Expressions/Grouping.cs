using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.SimpleVisitor;

namespace Visitor.SimpleVisitor.Expressions
{
    public class Grouping : Expression
    {
        public Expression Inner { get; }

        public Grouping(Expression inner)
        {
            Inner = inner;
        }

        public override object Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
