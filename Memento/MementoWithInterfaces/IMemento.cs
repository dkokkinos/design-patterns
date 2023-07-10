using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.MementoWithInterfaces
{
    public interface IMemento
    {
        char[,] GetBoard();
    }
}
