using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Handlers
{
    public class Euro10MoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 10)
            {
                money.AddCoin(10);
            }

            Successor?.SliceMoney(money);
        }
    }
}
