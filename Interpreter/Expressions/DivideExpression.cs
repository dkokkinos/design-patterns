using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class DivideExpression : IExpression
    {
        IExpression Left { get; set; }
        IExpression Right { get; set; }
        public DivideExpression(IExpression left, IExpression right)
        {
            this.Left = left;
            this.Right = right;
        }
        public float Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}
