using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class CacheDecorator : ICache
    {
        protected readonly ICache _inner;

        protected CacheDecorator(ICache inner)
        {
            _inner = inner;
        }

        public virtual bool Exists(string key)
            => _inner.Exists(key);

        public virtual string Get(string key)
            => _inner.Get(key);

        public virtual void Set(string key, string value)
            => _inner.Set(key, value);

    }
}
