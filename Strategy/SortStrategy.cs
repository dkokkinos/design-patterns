using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public abstract class SortStrategy
    {
        public abstract void Sort<T>(IList<T> collection, Comparer<T> comparer = null);
    }
}
