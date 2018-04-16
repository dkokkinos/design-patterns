using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class SelectProductState : State
    {
        public override void ProductSelected(object product, ISubject subject)
        {
            subject.SetState(new WaitingForMoneyState());
        }

        public override string ToString()
        {
            return nameof(SelectProductState);
        }
    }
}
