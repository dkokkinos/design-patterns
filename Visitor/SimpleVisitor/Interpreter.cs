using Visitor.SimpleVisitor.Expressions;
using static Visitor.Common.Operator;

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
            var left = expr.Left.Accept(this);
            var right = expr.Right.Accept(this);

            switch (expr.Operator)
            {
                case BANG_EQUAL: return left != right;
                case EQUAL_EQUAL: return left == right;
                case GREATER:
                    return (int)left > (int)right;
                case GREATER_EQUAL:
                    return (int)left >= (int)right;
                case LESS:
                    return (int)left < (int)right;
                case LESS_EQUAL:
                    return (int)left <= (int)right;
                case MINUS:
                    return (int)left - (int)right;
                case PLUS:
                    if (left is int leftAsInt && right is int rightAsInt)
                    {
                        return leftAsInt + rightAsInt;
                    }

                    if (left is string leftStr && right is string rightStr)
                    {
                        return leftStr + rightStr;
                    }
                    break;
                case SLASH:
                    return (int)left / (int)right;
                case STAR:
                    return (int)left * (int)right;
            }

            return null;
        }

        public object Visit(Unary expr)
        {
            var value = expr.Expression.Accept(this);

            switch (expr.Operator) {
                case BANG:
                    if (value == null) return false;
                    if (value is bool valueAsBool)
                        return valueAsBool;
                    return true;
                case MINUS:
                    return -(int)value;
            }

            // Unreachable.
            return null;
        }

        public object Visit(Logical expr)
        {
            var left = expr.Left.Accept(this);

            if (expr.Operator == OR) {
                if (isTruthy(left)) return left;
            } else
            {
                if (!isTruthy(left)) return left;
            }

            return expr.Right.Accept(this);
        }
    }
}
