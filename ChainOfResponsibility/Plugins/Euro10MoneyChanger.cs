using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Plugins
{
    public class Euro10MoneyChanger : MoneyChanger
    {
        protected override void ProcessRequest(Money money)
        {
            while (money.Amount >= 10)
            {
                money.AddPiece(10);
            }

            base.Successor?.SliceMoney(money);
        }
    }
}
