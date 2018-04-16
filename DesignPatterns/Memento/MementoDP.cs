using Memento.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Memento
{
    public class MementoDP : IDesignPattern
    {
        public void Run()
        {
            Caretaker careTaker = new Caretaker();

            MultiCalculator multiCalculator = careTaker.RestoreMultiCalculator();
            Calculator calculator = careTaker.RestoreSimpleCalculator();

            Console.WriteLine("multicalculator: " + multiCalculator.Calculate());
            Console.WriteLine("calculator: " + calculator.Calculate());

            calculator.Number1 = 10;
            calculator.Number2 = 10;

            Console.WriteLine("calculator: " + calculator.Calculate());
            Console.WriteLine("saving state of calculator");
            careTaker.SaveSimpleCalculator(calculator);


            calculator.Number1 = 100;
            calculator.Number2 = 100;
            Console.WriteLine("calculator: " + calculator.Calculate());

            calculator = careTaker.RestoreSimpleCalculator();
            Console.WriteLine("calculator after restore: " + calculator.Calculate());

        }
    }
}
