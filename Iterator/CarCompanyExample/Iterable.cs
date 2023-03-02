using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator = Iterator.CarCompanyExample.Iterator;

namespace Iterator.CarCompanyExample
{
    public interface Iterable
    {
        Iterator CreateIterator();
    }
}
