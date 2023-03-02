﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExample
{
    public interface Iterator
    {
        bool MoveNext();
        object Current { get; }
    }
}
