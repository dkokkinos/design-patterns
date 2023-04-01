using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace State
{
    public class Program
    {
        static IContainer container;
        public static async Task Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<VendingMachine>().AsSelf();

            builder.RegisterType<IdleState>().Keyed<State>("idle");
            builder.RegisterType<PaymentState>().Keyed<State>("payment");
            builder.RegisterType<DispenseProductState>().Keyed<State>("dispense");
            builder.RegisterType<SoldOutState>().Keyed<State>("soldout");
            
            builder.RegisterType<StateFactory>().AsSelf();

            container = builder.Build();


            Example1();
            Example2();
            Example3();
        }

        private static void Example3()
        {
            VendingMachine vendingMachine = container.Resolve<VendingMachine>(new NamedParameter("products", new List<Product>(){
                new Product("SPCOM1", 1, 1),
                new Product("SPCOM2", 3, 1)
            }));
            
            vendingMachine.DispenseProduct();
            vendingMachine.InsertMoney(2);
        }

        private static void Example2()
        {
            VendingMachine vendingMachine = container.Resolve<VendingMachine>(new NamedParameter("products", new List<Product>(){
                new Product("SPCOM1", 1, 1),
                new Product("SPCOM2", 3, 1)
            }));

            vendingMachine.InsertMoney(1);
            vendingMachine.SelectProduct("SPCOM1");
            vendingMachine.InsertMoney(0.4m);
            vendingMachine.InsertMoney(1.2m);
            vendingMachine.SelectProduct("SPCOM2");
            vendingMachine.InsertMoney(3.2m);
            // Vending Machine is now sold out.
            vendingMachine.Refill(new List<Product>()
            {
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 4)
            });
            vendingMachine.SelectProduct("SPCOM2");
            vendingMachine.InsertMoney(5.2m);
        }

        private static void Example1()
        {
            VendingMachine vendingMachine = container.Resolve<VendingMachine>(new NamedParameter("products", new List<Product>(){
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 1)
            }));

            vendingMachine.SelectProduct("SPCOM1");
            vendingMachine.InsertMoney(1);
        }
    }
}
