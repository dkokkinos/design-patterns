using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Cell
    {
        public object Value { get; set; }

        public Cell(object val)
        {
            this.Value = val;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
