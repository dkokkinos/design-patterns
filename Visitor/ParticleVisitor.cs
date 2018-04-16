using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public abstract class ParticleVisitor
    {
        public abstract void Visit(Hydrogen particle);
        public abstract void Visit(Oxygen particle);
    }
}
