using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.GenericVisitor.Expressions
{
    public abstract class Expression
    {
        public abstract T Accept<T>(IVisitor<T> visitor);
    }
}
