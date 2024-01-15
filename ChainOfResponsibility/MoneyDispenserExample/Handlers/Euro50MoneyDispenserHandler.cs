using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.MoneyDispenserExample.Handlers
{
    public class Euro50MoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 50)
            {
                money.AddUnit(50);
            }

            Successor?.SliceMoney(money);
        }
    }
}
