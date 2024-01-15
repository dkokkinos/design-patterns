namespace ChainOfResponsibility.ExpressionEvaluatorExample
{
    public class SubtractHandler : Handler
    {
        protected override string Operator => "-";
        protected override decimal DoHandle(decimal left, decimal right)
            => left - right;
    }
}