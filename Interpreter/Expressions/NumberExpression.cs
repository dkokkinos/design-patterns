namespace Interpreter.Expressions
{
    public class NumberExpression : IExpression
    {
        private readonly decimal _number;

        public NumberExpression(decimal number)
        {
            this._number = number;
        }

        public decimal Evaluate() => this._number;
    }
}
