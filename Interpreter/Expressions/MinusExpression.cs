using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class MinusExpression : IExpression
    {
        private IExpression Left { get; set; }
        private IExpression Right { get; set; }

        public MinusExpression(IExpression left, IExpression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public float Evaluate()
        {
            return this.Left.Evaluate() - this.Right.Evaluate();
        }
    }
}
