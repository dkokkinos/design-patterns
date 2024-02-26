using Autofac;
using Interpreter.Expressions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Interpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MathematicalExpressionExample1();
            MathematicalExpressionExample2();
            MathematicalExpressionExampleWithDI();
        }

        private static void MathematicalExpressionExampleWithDI()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SubtractionExpression>().Keyed<IExpression>("-");
            builder.RegisterType<MultiplicationExpression>().Keyed<IExpression>("*");
            builder.RegisterType<DivisionExpression>().Keyed<IExpression>("/");
            builder.RegisterType<AdditionExpression>().Keyed<IExpression>("+");
            builder.RegisterType<NumberExpression>().Keyed<IExpression>("num");

            IContainer container = builder.Build();

            // 1 * (4 - 5) / 6 + 10
            var num1 = container.ResolveKeyed<IExpression>("num", new NamedParameter("number", 1m));
            var num4 = container.ResolveKeyed<IExpression>("num", new NamedParameter("number", 4m));
            var num5 = container.ResolveKeyed<IExpression>("num", new NamedParameter("number", 5m));
            var num6 = container.ResolveKeyed<IExpression>("num", new NamedParameter("number", 6m));
            var num10 = container.ResolveKeyed<IExpression>("num", new NamedParameter("number", 10m));

            var subtraction = container.ResolveKeyed<IExpression>("-", 
                new NamedParameter("left", num4),
                new NamedParameter("right", num5));

            var multiplication = container.ResolveKeyed<IExpression>("*",
                new NamedParameter("left", num1),
                new NamedParameter("right", subtraction));

            var division = container.ResolveKeyed<IExpression>("/",
                new NamedParameter("left", multiplication),
                new NamedParameter("right", num6));

            var addition = container.ResolveKeyed<IExpression>("+",
                new NamedParameter("left", division),
                new NamedParameter("right", num10));

            var result = addition.Evaluate(); // Output: 9.8333
        }

        private static void MathematicalExpressionExample1()
        {
            // 1 * (4 - 5) / 6 + 10
            var subtraction = new SubtractionExpression(new NumberExpression(4), new NumberExpression(5));
            var multiplication = new MultiplicationExpression(new NumberExpression(1), subtraction);
            var division = new DivisionExpression(multiplication, new NumberExpression(6));
            var addition = new AdditionExpression(division, new NumberExpression(10));

            var result = addition.Evaluate(); // Output: 9.8333
        }

        private static void MathematicalExpressionExample2()
        {
            // 2 / mod(2*4, 3) + 2
            Console.WriteLine(2 / 2 * 4 % 3 + 2);
            var multiplication = new MultiplicationExpression(new NumberExpression(2), new NumberExpression(4));
            var mod = new ModExpression(multiplication, new NumberExpression(3));
            var division = new DivisionExpression(new NumberExpression(2), mod);
            var addition = new AdditionExpression(division, new NumberExpression(2));

            var result = addition.Evaluate(); // Output: 3
        }

    }
}