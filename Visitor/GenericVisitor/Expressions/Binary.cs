using Visitor.Common;

namespace Visitor.GenericVisitor.Expressions
{
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

        public override T Accept<T>(IVisitor<T> visitor)
            => visitor.Visit(this);
    }
}
