using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.MoneyDispenserExample.Handlers
{
    public class Euro200MoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 200)
            {
                money.AddUnit(200);
            }

            Successor?.SliceMoney(money);
        }
    }
}
