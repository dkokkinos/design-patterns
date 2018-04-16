using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Memento<T> : Stack<T>
    {
        public Memento(ICollection<T> numbers)
        {
            foreach(var n in numbers)
            {
                base.Push(n);
            }
        }
    }
}
