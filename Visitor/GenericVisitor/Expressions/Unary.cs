using Visitor.Common;

namespace Visitor.GenericVisitor.Expressions
{
    public class Unary : Expression
    {
        public Expression Expression { get; }
        public Operator Operator { get; }

        public Unary(Expression expression, Operator @operator)
        {
            Expression = expression;
            Operator = @operator;
        }

        public override T Accept<T>(IVisitor<T> visitor)
            => visitor.Visit(this);
    }
}
