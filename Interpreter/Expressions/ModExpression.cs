using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class ModExpression : IExpression
    {
        private readonly IExpression _dividend;
        private readonly IExpression _divisor;

        public ModExpression(IExpression dividend, IExpression divisor)
        {
            _dividend = dividend;
            _divisor = divisor;
        }

        public decimal Evaluate()
            => _dividend.Evaluate() % _divisor.Evaluate();
    }
}
