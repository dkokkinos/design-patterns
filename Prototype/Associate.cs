using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Associate : Actor
    {
        public override Actor Clone(string newName)
        {
            Actor a = (Actor)this.MemberwiseClone();
            a.Name = newName;
            return a;
        }

        public override string ToString()
        {
            return $"{nameof(Associate)} with name:{base.Name}";
        }
    }
}
