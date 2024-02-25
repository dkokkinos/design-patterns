using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class MultiplicationExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public MultiplicationExpression(IExpression left, IExpression right)
        {
            this._left = left;
            this._right = right;
        }

        public decimal Evaluate()
            => this._left.Evaluate() * this._right.Evaluate();
    }
}
