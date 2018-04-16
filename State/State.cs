using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public abstract class State
    {
        public virtual void GiveMoney(decimal money, ISubject subject)
        {
            throw new InvalidOperationException();
        }

        public virtual void ProductSelected(object product, ISubject subject)
        {
            throw new InvalidOperationException();
        }

        public virtual void CustomerGotTheProduct( ISubject subject)
        {
            throw new InvalidOperationException();
        }

        public abstract override string ToString();
    }
}
