using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Client
{
    public interface IDataProvider<T>
    {
        T Next();
        bool IsEoF { get; }
    }
}
