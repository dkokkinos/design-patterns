using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Expressions
{
    public class Logical : Expression
    {
        public Expression Left { get; }
        public Operator Operator { get; }
        public Expression Right { get; }

        public Logical(Expression left, Operator @operator, Expression right)
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override object Clone()
            => MemberwiseClone();

        public override string ToString()
            => $"{Left} {Operator.AsString()} {Right}";
    }
}
