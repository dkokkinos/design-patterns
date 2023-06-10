using Visitor.Common;

namespace Visitor.SimpleVisitor.Expressions
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

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
