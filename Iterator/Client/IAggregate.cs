using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Client
{
    public interface IAggregate
    {
        Iterator<VehiclePart> CreatePartIterator();

        Iterator<VehiclePart> CreateMechanicalPartIterator();
    }
}
