using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.SimpleVisitor.Expressions
{
    public abstract class Expression
    {
        public abstract object Accept(IVisitor visitor);
    }
}
