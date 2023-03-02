using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator = Iterator.CarCompanyExample.Iterator;

namespace Iterator.CarCompanyExample
{
    public class FerrariIterator : Iterator
    {
        private List<Car> _data;
        private int _position = -1;

        public FerrariIterator(List<Car> data)
        {
            _data = data;
        }

        public bool MoveNext()
        {
            if (_position < _data.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public object Current => _data[_position];
    }
}
