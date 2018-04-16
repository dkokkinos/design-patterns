using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Expressions
{
    public class NumberExpression : IExpression
    {
        private float Number { get; set; }

        public NumberExpression(float number)
        {
            this.Number = number;
        }

        public float Evaluate()
        {
            return this.Number;
        }
    }
}
