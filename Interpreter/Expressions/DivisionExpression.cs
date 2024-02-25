using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class DivisionExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public DivisionExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public decimal Evaluate()
            => this._left.Evaluate() / this._right.Evaluate();
    }
}
