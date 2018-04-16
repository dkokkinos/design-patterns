using Iterator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.VehicleParts
{
    public class Motor : MechanicalVehiclePart
    {
        public override string ToString()
        {
            return nameof(Motor);
        }
    }
}
