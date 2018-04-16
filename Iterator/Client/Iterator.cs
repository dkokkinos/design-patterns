using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Client
{
    public interface Iterator<T>
    {
        T First();
        T Next();
        T Current();
        bool IsEnd();
    }
}
