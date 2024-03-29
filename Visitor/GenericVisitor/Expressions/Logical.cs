﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Common;
using Visitor.SimpleVisitor;

namespace Visitor.GenericVisitor.Expressions
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

        public override T Accept<T>(IVisitor<T> visitor)
            => visitor.Visit(this);
    }
}
