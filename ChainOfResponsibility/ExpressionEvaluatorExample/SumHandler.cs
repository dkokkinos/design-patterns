namespace ChainOfResponsibility.ExpressionEvaluatorExample
{
    public class SumHandler : Handler
    {
        protected override string Operator => "+";
        protected override decimal DoHandle(decimal left, decimal right)
            => left + right;
    }
}
