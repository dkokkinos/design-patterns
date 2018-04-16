using ChainOfResponsibility.Client;
using ChainOfResponsibility.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility
{
    public class ChainOfResponsibilityDP : IDesignPattern
    {
        public void Run()
        {
            MoneyChanger _500 = new Euro500MoneyChanger();
            MoneyChanger _200 = new Euro200MoneyChanger();
            MoneyChanger _10 = new Euro10MoneyChanger();
            MoneyChanger _50cent = new Cent50MoneyChanger();

            _500.SetSuccessor(_200);
            _200.SetSuccessor(_10);
            _10.SetSuccessor(_50cent);
            _50cent.SetSuccessor(_500); // recursive

            Money money = new Money(1312.5m);
            _500.SliceMoney(money);

            Console.WriteLine(money);

            // ή

            Director moneyChangerDirector = new Director();

            MoneyChanger _50 = new Euro50MoneyChanger();
            MoneyChanger _10cent = new Cent10MoneyMoneyChanger();

            MoneyChanger root = moneyChangerDirector.ConstructChain(_500, _200, _50, _10, _50cent, _10cent);

            Money money2 = new Money(9600.9m);
            root.SliceMoney(money2);
            Console.WriteLine(money2);
        }
    }
}
