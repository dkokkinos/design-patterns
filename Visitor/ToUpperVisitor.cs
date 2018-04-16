using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class ToUpperVisitor : ParticleVisitor
    {
        public override void Visit(Oxygen particle)
        {
            particle.Name = particle.Name.ToUpper();
        }

        public override void Visit(Hydrogen particle)
        {
            particle.Name = particle.Name.ToUpper();
        }
    }
}
