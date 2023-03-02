using Iterator.CarCompanyExample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExampleUsingDotNetIterator
{
    public class Ford : IEnumerable
    {
        private Car[] _cars;

        public Ford(Car[] cars)
        {
            _cars = cars;
        }

        public IEnumerator GetEnumerator() => _cars.GetEnumerator();
    }
}
