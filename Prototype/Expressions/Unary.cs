namespace Prototype.Expressions
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

        public override object Clone() => MemberwiseClone();

        public override string ToString()
            => $"{Operator.AsString()}{Expression}";
    }
}
