using State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State
{
    public class StateDP : IDesignPattern
    {
        public void Run()
        {
            VendingMachine machine = new VendingMachine();
            Console.WriteLine(machine.CurrentState);

            machine.ProductSelected("product");

            Console.WriteLine(machine.CurrentState);

            machine.GiveMoney(10m);

            Console.WriteLine(machine.CurrentState);

            machine.CustomerGotTheProduct();

            Console.WriteLine(machine.CurrentState);

        }
    }
}
