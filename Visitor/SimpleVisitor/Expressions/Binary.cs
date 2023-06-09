using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.SimpleVisitor.Expressions
{
    public enum Operator
    {
        BANG_EQUAL,
        EQUAL_EQUAL,
        GREATER,
        GREATER_EQUAL,
        LESS,
        LESS_EQUAL,
        MINUS,
        PLUS,
        SLASH,
        STAR
    }

    public class Binary : Expression
    {
        public Expression Left { get; }
        public Expression Right { get; }

        public Operator Operator { get; }

        public Binary(Expression left, Operator @operator, Expression right)
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override object Accept(IVisitor visitor)
            => visitor.Visit(this);
    }
}
