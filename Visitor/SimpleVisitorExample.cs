using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Common;
using Visitor.SimpleVisitor;
using Visitor.SimpleVisitor.Expressions;

namespace Visitor
{
    public class SimpleVisitorExample
    {
        public void Run()
        {
            var interpreter = new Interpreter();
            var res = interpreter.Visit(new Literal(100));

            res = interpreter.Visit(new Binary(new Literal(100), Operator.PLUS, new Literal(100)));

            // 10 / 10 - 1
            var divition = new Binary(new Literal(10), Operator.SLASH, new Literal(10));
            var root = new Binary(divition, Operator.MINUS, new Literal(1));
            res = interpreter.Visit(root);

            // 10 / (10 - 1)
            var diff = new Binary(new Literal(10), Operator.MINUS, new Literal(1));
            var divition2 = new Binary(new Literal(10), Operator.SLASH, diff);
            res = interpreter.Visit(divition2);

            // "a string"
            res = interpreter.Visit(new Literal("a string"));
            Console.WriteLine(res);

            // 1 > 10
            res = interpreter.Visit(new Binary(new Literal(1), Operator.GREATER, new Literal(10)));
            Console.WriteLine(res);

            // -1
            res = interpreter.Visit(new Unary(new Literal(1), Operator.MINUS));
            Console.WriteLine(res);

            res = interpreter.Visit(new Logical(new Literal(false), Operator.OR, new Literal(true)));
            Console.WriteLine(res);

            // 10 - ( -5/5 ) * 3
            var division = new Binary(new Unary(new Literal(5), Operator.MINUS), Operator.SLASH, new Literal(5));
            var multiplication = new Binary(division, Operator.STAR, new Literal(3));
            diff = new Binary(new Literal(10), Operator.MINUS, multiplication);
            res = interpreter.Visit(diff);

            // true AND 1 >= 0 AND 2 + 4 < 10
            var firstLogical = new Logical(new Literal(true), Operator.AND, new Binary(new Literal(1), Operator.GREATER_EQUAL, new Literal(0)));
            var secondLogical = new Logical(firstLogical, Operator.AND, new Binary(new Binary(new Literal(2), Operator.PLUS, new Literal(4)), Operator.LESS, new Literal(10)));
            res = interpreter.Visit(secondLogical);
        }
    }
}
