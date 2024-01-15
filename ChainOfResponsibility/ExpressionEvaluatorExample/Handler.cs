using System;

namespace ChainOfResponsibility.ExpressionEvaluatorExample
{
    public abstract class Handler
    {
        public Handler Successor { get; set; }
        protected abstract string Operator { get; }

        public void Handle(Request request)
        {
            while (request.Expression.Contains(Operator))
            {
                var parts = request.Expression.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i].Trim() == Operator)
                    {
                        decimal left = Convert.ToDecimal(parts[i - 1]);
                        decimal right = Convert.ToDecimal(parts[i + 1]);
                        var res = DoHandle(left, right);

                        parts[i - 1] = "";
                        parts[i] = res.ToString();
                        parts[i + 1] = "";
                        request.Expression = string.Join(" ", parts);
                        break;
                    }
                }
            }
            Successor?.Handle(request);
        }
        protected abstract decimal DoHandle(decimal left, decimal right);
    }
}
