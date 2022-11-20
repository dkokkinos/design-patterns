using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class BufferedCache : CacheDecorator
    {
        private readonly Dictionary<string, string> values;

        public BufferedCache(ICache inner) : base(inner)
        {
            values = new();
        }

        public override string Get(string key)
        {
            if (values.TryGetValue(key, out string value))
                return value;
            var entry = _inner.Get(key);
            values.Add(key, entry);
            return entry;
        }

        public override void Set(string key, string value)
        {
            if (values.ContainsKey(key))
                values.Remove(key);

            _inner.Set(key, value);
            values.Add(key, value);
        }
    }
}
