using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    [Serializable]
    public class Memento
    {
        private char[,] state;

        public Memento(char[,] state)
        {
            this.state = state;
        }

        public char[,] GetState()
        {
            return state;
        }
    }
}
