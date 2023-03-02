using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExample
{
    public class Ford : Company
    {
        private Car[] _cars;

        public Ford(Car[] cars)
        {
            _cars = cars;
        }

        public override Iterator CreateIterator()
        {
            return new FordIterator(_cars);
        }
    }
}
