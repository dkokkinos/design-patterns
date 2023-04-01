using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class StateFactory
    {
        private readonly ILifetimeScope _lifeTimeScope;

        public StateFactory(ILifetimeScope lifeTimeScope)
        {
            _lifeTimeScope = lifeTimeScope;
        }

        public State Create(string key, VendingMachine context)
        {
            return _lifeTimeScope.ResolveKeyed<State>(key, new NamedParameter("vendingMachine", context));
        }
    }
}
