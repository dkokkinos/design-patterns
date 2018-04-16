using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public interface IPluginLoader<T>
    {
        ICollection<T> LoadPlugins();
    }
}
