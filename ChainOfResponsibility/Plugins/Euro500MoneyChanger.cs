using ChainOfResponsibility.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Plugins
{
    public class Euro500MoneyChanger : MoneyChanger
    {
        protected override void ProcessRequest(Money money)
        {
            while(money.Amount >= 500)
            {
                money.AddPiece(500);
            }

            base.Successor?.SliceMoney(money);
        }
    }
}
