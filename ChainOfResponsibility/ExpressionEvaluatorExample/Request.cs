namespace ChainOfResponsibility.ExpressionEvaluatorExample
{
    public class Request
    {
        public string Expression { get; set; }
        public Request(string expression)
        {
            Expression = expression;
        }
    }
}