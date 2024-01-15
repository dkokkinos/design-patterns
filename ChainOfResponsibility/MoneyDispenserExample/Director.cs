using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.MoneyDispenserExample
{
    /// <summary>
    /// A Director is a helper class that constructs a chain of handlers.
    /// </summary>
    public class Director
    {
        public MoneyDispenserHandler ConstructChain(params MoneyDispenserHandler[] dispencers)
        {
            MoneyDispenserHandler pre = dispencers[0];
            MoneyDispenserHandler last = null;
            foreach (var changer in dispencers.Skip(1))
            {
                pre.SetSuccessor(changer);
                last = changer;
                pre = changer;
            }
            last.SetSuccessor(dispencers[0]);
            return dispencers[0];
        }
    }
}
