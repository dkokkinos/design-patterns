using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class GroupExpression : IExpression
    {
        public readonly IExpression _expression;

        public GroupExpression(IExpression expression)
        {
            _expression = expression;
        }

        public decimal Evaluate()
            => _expression.Evaluate();
    }
}
