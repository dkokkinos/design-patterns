using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Client
{
    public class Director
    {
        public MoneyDispenserHandler ConstructChain(params MoneyDispenserHandler[] changers)
        {
            MoneyDispenserHandler pre = changers[0];
            MoneyDispenserHandler last = null;
            foreach(var changer in changers.Skip(1))
            {
                pre.SetSuccessor(changer);
                last = changer;
                pre = changer;
            }
            last.SetSuccessor(changers[0]);
            return changers[0];
        }
    }
}
