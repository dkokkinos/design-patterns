using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Common;
using Visitor.GenericVisitor;
using Visitor.GenericVisitor.Expressions;

namespace Visitor
{
    public class GenericVisitorExample
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Interpreter>()
                .As(typeof(IVisitor<object>));
            builder.RegisterType<PrintVisitor>()
                .As(typeof(IVisitor<string>));

            var container = builder.Build();

            var printVisitor = container.Resolve<IVisitor<string>>();
            var interpreter = container.Resolve<IVisitor<object>>();

            // true AND 1 >= 0 AND 2 + 4 < 10
            var firstLogical = new Logical(new Literal(true), Operator.AND, new Binary(new Literal(1), Operator.GREATER_EQUAL, new Literal(0)));
            var secondLogical = new Logical(firstLogical, Operator.AND, new Binary(new Binary(new Literal(2), Operator.PLUS, new Literal(4)), Operator.LESS, new Literal(10)));
            var res = printVisitor.Visit(secondLogical); // result: True AND 1 >= 0 AND 2 + 4 < 10
            var evaled = interpreter.Visit(secondLogical); // result: true

            // 10 - ( -5/5 ) * 3
            var division = new Group(new Binary(new Unary(new Literal(5), Operator.MINUS), Operator.SLASH, new Literal(5)));
            var multiplication = new Binary(division, Operator.STAR, new Literal(3));
            var diff = new Binary(new Literal(10), Operator.MINUS, multiplication);
            res = printVisitor.Visit(diff); // result: 10 - ( -5 / 5 ) * 3
            evaled = interpreter.Visit(diff); // result: 13
        }
    }
}
