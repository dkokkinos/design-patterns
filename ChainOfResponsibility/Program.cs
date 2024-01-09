using Autofac;
using ChainOfResponsibility.Client;
using ChainOfResponsibility.Handlers;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var director = new Director();
            var handlers = director.ConstructChain(
                new Euro500MoneyDispenserHandler(),
                new Euro200MoneyDispenserHandler(),
                new Euro50MoneyDispenserHandler(),
                new Euro10MoneyDispenserHandler(),
                new Cent50MoneyDispenserHandler(),
                new Cent10MoneyMoneyDispenserHandler());

            Money money = new Money(535.70m);

            handlers.SliceMoney(money);

            Console.WriteLine(money);
        }
    }
}