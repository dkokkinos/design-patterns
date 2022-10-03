using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface ISubject
    {
        public void AddObserver(IObserver observer);

        public void RemoveObserver(IObserver observer);

        public void NotifyObservers();
    }
}
