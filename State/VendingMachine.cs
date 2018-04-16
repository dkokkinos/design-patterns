using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class VendingMachine : ISubject
    {
        public State CurrentState { get; private set; }

        public VendingMachine()
        {
            this.CurrentState = new SelectProductState();
        }

        public void GiveMoney(decimal money)
        {
            this.CurrentState.GiveMoney(money, this);
        }

        public void ProductSelected(object product)
        {
            this.CurrentState.ProductSelected(product, this);
        }

        public void CustomerGotTheProduct()
        {
            this.CurrentState.CustomerGotTheProduct(this);
        }

        public void SetState(State state)
        {
            this.CurrentState = state;
        }
    }
}
