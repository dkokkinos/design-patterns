using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Canditate : Actor
    {
        public override Actor Clone(string newName)
        {
            Actor a = (Actor)this.MemberwiseClone();
            a.Name = newName;
            return a;
        }

        public override string ToString()
        {
            return $"{nameof(Canditate)} with name:{base.Name}";
        }
    }
}
