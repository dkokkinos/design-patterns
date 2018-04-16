using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class Target : IDisposable
    {
        public Target Parent { get; private set; }
        public string Name { get; set; }

        public Target(Target parent, string name)
        {
            this.Parent = parent;
            this.Name = name;
        }

        private Target()
        {

        }

        public override string ToString()
        {
            if (this.Parent == null && string.IsNullOrWhiteSpace(this.Name))
                return "released object";
            return this.Name + " with parent " + this.Parent;
        }

        public void Dispose()
        {
            this.Parent = null;
            this.Name = string.Empty;
        }
    }
}
