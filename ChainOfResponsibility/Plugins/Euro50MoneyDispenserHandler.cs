using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Plugins
{
    public class Euro50MoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while(money.Amount >= 50)
            {
                money.AddCoin(50);
            }

            base.Successor?.SliceMoney(money);
        }
    }
}
