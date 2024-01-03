using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Plugins
{
    public class Cent10MoneyMoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while(money.Amount >= 0.1m)
            {
                money.AddCoin(0.1m);
            }

            base.Successor?.SliceMoney(money);
        }
    }
}
