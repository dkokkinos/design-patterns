using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Client
{
    public abstract class MoneyDispenserHandler
    {
        protected MoneyDispenserHandler Successor;
        public void SetSuccessor(MoneyDispenserHandler successor)
        {
            this.Successor = successor;
        }

        public void SliceMoney(Money money)
        {
            if (money.Amount == 0)
                return;
            this.ProcessRequest(money);
        }

        protected abstract void ProcessRequest(Money money);
    }
}
