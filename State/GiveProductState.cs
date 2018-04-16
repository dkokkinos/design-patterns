using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class GiveProductState : State
    {
        public override void CustomerGotTheProduct(ISubject subject)
        {
            subject.SetState(new SelectProductState());
        }

        public override string ToString()
        {
            return nameof(GiveProductState);
        }
    }
}
