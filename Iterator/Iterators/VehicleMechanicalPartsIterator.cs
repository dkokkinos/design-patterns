using Iterator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterators
{
    public class VehicleMechanicalPartsIterator : VehiclePartsIterator
    {

        public VehicleMechanicalPartsIterator(ICollection<VehiclePart> parts) : base(parts)
        {
            Parts = parts.Where(x => x is MechanicalVehiclePart).Cast<VehiclePart>().ToList();

        }

    }
}
