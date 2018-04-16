using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class Actor
    {
        public string Name { get; set; }
        
        public abstract Actor Clone(string newName);
    }
}
