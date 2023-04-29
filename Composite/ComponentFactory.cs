using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class ComponentFactory
    {
        private readonly ILifetimeScope _lifeTimeScope;

        public ComponentFactory(ILifetimeScope lifeTimeScope)
        {
            _lifeTimeScope = lifeTimeScope;
        }

        public IComponent Create(string key, object _params)
        {
            var props = _params.GetType().GetProperties();
            var namedParameters = props.Select(x => new NamedParameter(x.Name, x.GetValue(_params, null)));
            return _lifeTimeScope.ResolveKeyed<IComponent>(key, namedParameters);
        }
    }
}
