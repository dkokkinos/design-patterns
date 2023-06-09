using System;
using System.Collections.Generic;
using System.Linq;
using Visitor.SimpleVisitor;
using Visitor.SimpleVisitor.Expressions;

namespace Visitor
{
    public class Program
    {
        public static void Main()
        {
            var interpreter = new Interpreter();
            var res = interpreter.Visit(new Literal(100));

            res = interpreter.Visit(new Binary(new Literal(100.0), Operator.PLUS, new Literal(100.0)));

            // 10 / 10 - 1  | 10 / (10 - 1)
            var divition = new Binary(new Literal(10.0), Operator.SLASH, new Literal(10.0));
            var root = new Binary(divition, Operator.MINUS, new Literal(1.0));
            res = interpreter.Visit(root);

            var diff = new Binary(new Literal(10.0), Operator.MINUS, new Literal(1.0));
            var divition2 = new Binary(new Literal(10.0), Operator.SLASH, diff);
            res = interpreter.Visit(divition2);

        }
    }
}
