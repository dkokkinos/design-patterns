using Autofac;
using ChainOfResponsibility.ExpressionEvaluatorExample;
using ChainOfResponsibility.MoneyDispenserExample;
using ChainOfResponsibility.MoneyDispenserExample.Handlers;
using System;

namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("===== MoneyDispenserExample =====");
            MoneyDispenserExample();

            Console.WriteLine();
            Console.WriteLine("===== ExpressionEvaluatorExample =====");
            ExpressionEvaluatorExample();

            Console.WriteLine();
            Console.WriteLine("===== MoneyDispenserWithDIExample =====");
            MoneyDispenserWithDIExample();
        }

        private static void MoneyDispenserExample()
        {
            var director = new Director();
            var handlers = director.ConstructChain(
                new Euro500MoneyDispenserHandler(),
                new Euro200MoneyDispenserHandler(),
                new Euro50MoneyDispenserHandler(),
                new Euro10MoneyDispenserHandler(),
                new Cent50MoneyDispenserHandler(),
                new Cent10MoneyDispenserHandler());

            Money money = new Money(535.70m);

            handlers.SliceMoney(money);
            Console.WriteLine($"MoneyDispenserExample => The amount of 535.70 is divided: {money}");
        }

        private static void MoneyDispenserWithDIExample()
        {
            var builder = new ContainerBuilder();

            var director = new Director();

            // We can register multiple chain instances with a discriminator to use them
            // depending on the scenario.
            builder.RegisterInstance<MoneyDispenserHandler>(
                director.ConstructChain(
                    new Euro500MoneyDispenserHandler(),
                    new Euro200MoneyDispenserHandler(),
                    new Euro50MoneyDispenserHandler(),
                    new Euro10MoneyDispenserHandler(),
                    new Cent50MoneyDispenserHandler(),
                    new Cent10MoneyDispenserHandler()))
                .Keyed<MoneyDispenserHandler>("full");

            builder.RegisterInstance<MoneyDispenserHandler>(
                director.ConstructChain(
                    new Cent50MoneyDispenserHandler(),
                    new Cent10MoneyDispenserHandler()))
                .Keyed<MoneyDispenserHandler>("only-coins");

            IContainer container = builder.Build();

            var fullDispenser = container.ResolveKeyed<MoneyDispenserHandler>("full");
            var money = new Money(523);
            fullDispenser.SliceMoney(money);
            Console.WriteLine($"MoneyDispenserWithDIExample => With both coins and bills dispenser, the amount of 523 is divided:");
            Console.WriteLine(money);

            var onlyCoins = container.ResolveKeyed<MoneyDispenserHandler>("only-coins");
            money = new Money(523);
            onlyCoins.SliceMoney(money);
            Console.WriteLine($"MoneyDispenserWithDIExample => With only coins dispenser, the amount of 523 is divided:");
            Console.WriteLine(money);
        }

        private static void ExpressionEvaluatorExample()
        {
            var request = new Request("1 + 2 * 10 - 5");
            Handler chain = new MultiplyHandler()
            {
                Successor = new SumHandler()
                {
                    Successor = new SubtractHandler()
                }
            };
            chain.Handle(request); // Result: 16
            Console.WriteLine("With a chain:MultiplyHandler->SumHandler->SubtractHandler, the expression 1 + 2 * 10 - 5 is evaluated to 16");

            request = new Request("1 + 2 * 10 - 5");
            chain = new SubtractHandler()
            {
                Successor = new SumHandler()
                {
                    Successor = new MultiplyHandler()
                }
            };
            chain.Handle(request); // Result: 15
            Console.WriteLine("With a chain:SubtractHandler->SumHandler->MultiplyHandler, the expression 1 + 2 * 10 - 5 is evaluated to 15");
        }

    }
}