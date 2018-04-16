using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class SumExpression : IExpression
    {
        private IExpression Expression1 { get; set; }
        private IExpression Expression2 { get; set; }

        public SumExpression(IExpression ex1, IExpression ex2)
        {
            this.Expression1 = ex1;
            this.Expression2 = ex2;
        }
        public float Evaluate()
        {
            return this.Expression1.Evaluate() + this.Expression2.Evaluate();
        }
    }
}
