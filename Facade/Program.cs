using System;

namespace Facade
{
    public class Program
    {
        public static void Main()
        {
            CoffeeMachineFacade facade = new CoffeeMachineFacade(new Pump(), new Heater(), new Grinder());
            facade.MakeEspresso();
            Console.WriteLine("Coffee is ready!");
        }

    }
}
