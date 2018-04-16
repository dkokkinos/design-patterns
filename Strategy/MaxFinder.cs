using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class MaxFinder
    {
        public SortStrategy sortStrategy { get; set; }

        public MaxFinder()
        {

        }

        public T GetMax<T>(IList<T> list)
        {
            
            this.sortStrategy.Sort<T>(list);
            return list.Last();
        }
    }
}
