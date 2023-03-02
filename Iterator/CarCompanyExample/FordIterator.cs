using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExample
{
    public class FordIterator : Iterator
    {
        private Car[] _data;
        private int _position = -1;

        public FordIterator(Car[] data)
        {
            _data = data;
        }

        public bool MoveNext()
        {
            if (_position < _data.Length - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public object Current => _data[_position];
    }
}
