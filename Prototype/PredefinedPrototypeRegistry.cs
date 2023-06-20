using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class PredefinedPrototypeRegistry
    {
        public ConcretePrototype1 ConcretePrototype1;
        public ConcretePrototype2 ConcretePrototype2;

        public PredefinedPrototypeRegistry(ConcretePrototype1 concretePrototype1, 
            ConcretePrototype2 concretePrototype2)
        {
            this.ConcretePrototype1 = concretePrototype1;
            this.ConcretePrototype2 = concretePrototype2;
        }
    }

    public class DynamicPrototypeRegistry
    {
        private readonly Dictionary<string, Prototype> _prototypes;

        public void Register(string key, Prototype prototype)
            => _prototypes.Add(key, prototype);

        public Prototype Get(string key)
            => _prototypes[key];
    }
}
