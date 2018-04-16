using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Hydrogen : Particle
    {
        public Hydrogen(string name) : base(name)
        {
        }

        public override void Accept(ParticleVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
