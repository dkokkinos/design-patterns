using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.MoneyDispenserExample.Handlers
{
    public class Euro500MoneyDispenserHandler : MoneyDispenserHandler
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 500)
            {
                money.AddUnit(500);
            }

            Successor?.SliceMoney(money);
        }
    }
}
