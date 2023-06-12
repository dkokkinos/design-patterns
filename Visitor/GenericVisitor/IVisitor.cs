using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.GenericVisitor.Expressions;

namespace Visitor.GenericVisitor
{
    public interface IVisitor<T>
    {
        T Visit(Literal expr);
        T Visit(Unary expr);
        T Visit(Binary expr);
        T Visit(Logical expr);
        T Visit(Group expr);
    }
}
