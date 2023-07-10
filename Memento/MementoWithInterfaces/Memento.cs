using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.MementoWithInterfaces
{
    [Serializable]
    public class Memento : IMemento
    {
        private readonly char[,] _board;

        public Memento(char[,] board)
        {
            _board = board;
        }
        
        char[,] IMemento.GetBoard() => _board;
    }
}
