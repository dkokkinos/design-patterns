using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Plugins
{
    public class Cent50MoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while(money.Amount >= 0.5m)
            {
                money.AddCoin(0.5m);
            }
            base.Successor?.SliceMoney(money);
        }
    }
}
