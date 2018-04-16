using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class WaitingForMoneyState : State
    {
        public override void GiveMoney(decimal money, ISubject subject)
        {
            subject.SetState(new GiveProductState());
        }

        public override string ToString()
        {
            return nameof(WaitingForMoneyState);
        }
    }
}
