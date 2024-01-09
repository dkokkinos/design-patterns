using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Handlers
{
    public class Cent10MoneyMoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 0.1m)
            {
                money.AddUnit(0.1m);
            }

            Successor?.SliceMoney(money);
        }
    }
}
