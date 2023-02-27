using Iterator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterators
{
    public class VehiclePartsIterator : Iterator<VehiclePart>
    {
        protected ICollection<VehiclePart> Parts { get; set; }
        private int _current = 0;

        public VehiclePartsIterator(ICollection<VehiclePart> parts)
        {
            Parts = parts;
        }

        VehiclePart Iterator<VehiclePart>.Current()
        {
            return Parts.ElementAt(_current);
        }

        bool Iterator<VehiclePart>.IsEnd()
        {
            return Parts.Count() <= _current;
        }

        VehiclePart Iterator<VehiclePart>.Next()
        {
            _current++;
            if (!(this as Iterator<VehiclePart>).IsEnd())
            {
                return Parts.ElementAt(_current);
            }

            return null;
        }

        VehiclePart Iterator<VehiclePart>.First()
        {
            return Parts.ElementAt(0);
        }
    }
}
