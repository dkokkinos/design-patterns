using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator = Iterator.CarCompanyExample.Iterator;

namespace Iterator.CarCompanyExample
{
    public class Ferrari : Company
    {
        private List<Car> _cars;

        public Ferrari()
        {
            _cars = new();
        }

        public void AddItem(Car car)
        {
            _cars.Add(car);
        }

        public void RemoveItem(string name)
        {
            var item = _cars.FirstOrDefault(x => x.Name == name);
            _cars.Remove(item);
        }

        public override Iterator CreateIterator()
        {
            return new FerrariIterator(_cars);
        }
    }
}
