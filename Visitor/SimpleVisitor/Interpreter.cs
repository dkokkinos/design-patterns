using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.SimpleVisitor.Expressions;
using static Visitor.SimpleVisitor.Expressions.Operator;

namespace Visitor.SimpleVisitor
{
    public class Interpreter : IVisitor
    {
        public object Visit(Literal expr)
        {
            return expr.Value;
        }

        public object Visit(Grouping expr)
        {
            return expr.Inner.Accept(this);
        }

        public object Visit(Binary expr)
        {
            Object left = expr.Left.Accept(this);
            Object right = expr.Right.Accept(this);

            switch (expr.Operator)
            {
                case BANG_EQUAL: return left != right;
                case EQUAL_EQUAL: return left == right;
                case GREATER:
                    return (double)left > (double)right;
                case GREATER_EQUAL:
                    return (double)left >= (double)right;
                case LESS:
                    return (double)left < (double)right;
                case LESS_EQUAL:
                    return (double)left <= (double)right;
                case MINUS:
                    return (double)left - (double)right;
                case PLUS:
                    if (left is double dLeft && right is double dRight)
                    {
                        return dLeft + dRight;
                    }

                    if (left is string leftStr && right is string rightStr)
                    {
                        return leftStr + rightStr;
                    }
                    break;
                case SLASH:
                    return (double)left / (double)right;
                case STAR:
                    return (double)left * (double)right;
            }

            return null;
        }
    }
}
