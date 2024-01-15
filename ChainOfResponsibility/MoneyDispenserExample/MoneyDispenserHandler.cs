using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.MoneyDispenserExample
{
    /// <summary>
    /// Represents a Handler in the Chain that will handle and/or forward the request to its successor.
    /// </summary>
    public abstract class MoneyDispenserHandler
    {
        protected MoneyDispenserHandler Successor;
        public void SetSuccessor(MoneyDispenserHandler successor)
        {
            Successor = successor;
        }

        public void SliceMoney(Money money)
        {
            if (money.Amount == 0)
                return;
            ProcessRequest(money);
        }

        protected abstract void ProcessRequest(Money money);
    }
}
