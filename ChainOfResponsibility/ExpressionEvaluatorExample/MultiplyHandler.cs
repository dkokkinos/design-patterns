namespace ChainOfResponsibility.ExpressionEvaluatorExample
{
    public class MultiplyHandler : Handler
    {
        protected override string Operator => "*";
        protected override decimal DoHandle(decimal left, decimal right)
            => left * right;
    }
}