using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface ICache
    {
        string Get(string key);
        void Set(string key, string value);
        bool Exists(string key);
    }
}
