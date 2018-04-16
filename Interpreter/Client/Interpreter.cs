using Interpreter.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Client
{
    public class Interpreter
    {
        private string Context { get; set; }
        public Interpreter(string context)
        {
            this.Context = context;
        }
        public float Interpret()
        {
            if (string.IsNullOrEmpty(this.Context))
            {
                return float.NaN;
            }
            this.Context = this.Context.Replace(" ", string.Empty);
            List<string> _operations = new List<string>() { "*", "/", "+", "-" };

            string[] numbers;
            string[] operators;
            this.BreakNumbersFromOperators(this.Context, _operations, out numbers, out operators);
            List<IExpression> expressions = InitializeExpressions(numbers);

            List<string> operatorsList = operators.ToList();
            foreach(var _operation in _operations)
            {
                MergeExpressions(_operation, ref operatorsList, ref expressions);
            }


            return expressions[0].Evaluate();
        }

        void MergeExpressions(string operation, ref List<string> operations, ref List<IExpression> expressions)
        {
            for(int i = 0; i < operations.Count; i++)
            {
                if(operations[i] == operation)
                {
                    IExpression left = expressions[i];
                    IExpression right = expressions[i + 1];

                    IExpression complex = this.CreateExpression(left, right, operation);

                    expressions.Remove(left);
                    expressions.Remove(right);
                    expressions.Insert(i, complex);
                    operations.Remove(operation);
                    i--;
                }
            }

            operations.RemoveAll(x => x == operation);
        }

        private IExpression CreateExpression(IExpression left, IExpression right, string operation)
        {
            if(operation == "*")
            {
                return new ProductExpression(left, right);
            }else if(operation == "+")
            {
                return new SumExpression(left, right);
            }else if(operation == "-")
            {
                return new MinusExpression(left, right);
            }else if(operation == "/")
            {
                return new DivideExpression(left, right);
            }
            return null;
        }

        private List<IExpression> InitializeExpressions(string[] numbers)
        {
            List<IExpression> expressions = new List<IExpression>();
            foreach(var n in numbers)
            {
                expressions.Add(new NumberExpression(float.Parse(n)));
            }
            return expressions;
        }

        private void BreakNumbersFromOperators(string context, List<string> _operations,  out string[] numbers, out string[] operators)
        {
            numbers = this.Context.Split(_operations.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            int opCount = 0;
            foreach(var op in _operations)
            {
                opCount += context.Count(x => x.ToString() == op);
            }

            operators = new string[opCount];

            int opIndex = 0;
            for(int i = 0; i < context.Length; i++)
            {
                if( _operations.Contains(context[i].ToString()))
                {
                    operators[opIndex] = context[i].ToString();
                    opIndex++;
                }
            }

        }
        
    }
}
