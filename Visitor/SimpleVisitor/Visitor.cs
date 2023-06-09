using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.SimpleVisitor.Expressions;

namespace Visitor.SimpleVisitor
{
    public interface IVisitor
    {
        object Visit(Literal expr);
        object Visit(Grouping expr);
        object Visit(Binary expr);
    }
}
