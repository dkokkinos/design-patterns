using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public abstract class Particle
    {
        public string Name { get; set; }

        public abstract void Accept(ParticleVisitor visitor);

        public Particle(string name)
        {
            this.Name = name;
        }
    }
}
