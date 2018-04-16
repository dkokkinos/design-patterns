using Iterator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Iterator = Iterator.Client.Iterator<Iterator.Client.VehiclePart>;

namespace DesignPatterns.Iterator
{
    public class IteratorDP : IDesignPattern
    {
        public void Run()
        {
            IAggregate vehicle = new Vehicle();

            Console.WriteLine("VehicleParts");
            _Iterator _iterator = vehicle.CreatePartIterator();
            this.Iterate(_iterator);
            Console.WriteLine();

            Console.WriteLine("Vehicle Mechanical Parts");
            _Iterator _mechanicalIterator = vehicle.CreateMechanicalPartIterator();
            this.Iterate(_mechanicalIterator);
            
        }

        private void Iterate(_Iterator _iterator)
        {
            for (VehiclePart part = _iterator.First(); !_iterator.IsEnd(); part = _iterator.Next())
            {
                Console.WriteLine(part);
            }
        }
    }
}
