namespace Prototype.Expressions
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

        public override object Clone()
            => new Binary(Left.Clone() as Expression, Operator, Right.Clone() as Expression);

        public override string ToString()
            => $"{Left} {Operator.AsString()} {Right}";
    }
}
