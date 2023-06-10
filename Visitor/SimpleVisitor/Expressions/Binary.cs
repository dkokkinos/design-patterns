using Visitor.Common;

namespace Visitor.SimpleVisitor.Expressions
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

        public override object Accept(IVisitor visitor)
            => visitor.Visit(this);
    }
}
