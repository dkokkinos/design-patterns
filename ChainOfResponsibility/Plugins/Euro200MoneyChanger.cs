using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Plugins
{
    public class Euro200MoneyChanger : MoneyChanger
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 200)
            {
                money.AddPiece(200);
            }

            base.Successor?.SliceMoney(money);
        }
    }
}
