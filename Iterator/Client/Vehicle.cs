using Iterator.Iterators;
using Iterator.VehicleParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Client
{
    public class Vehicle : IAggregate
    {
        ICollection<VehiclePart> Parts { get; set; }
        public Vehicle()
        {
            this.Parts = new List<VehiclePart>()
            {
                new Wheel(),
                new Shassi(),
                new Motor(),
                new Window()
            };
        }

        public Iterator<VehiclePart> CreatePartIterator()
        {
            return new VehiclePartsIterator(this.Parts);
        }

        public Iterator<VehiclePart> CreateMechanicalPartIterator()
        {
            return new VehicleMechanicalPartsIterator(this.Parts);
        }

    }
}
