﻿using Iterator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.VehicleParts
{
    public class Wheel : MechanicalVehiclePart
    {
        public override string ToString()
        {
            return nameof(Wheel);
        }
    }

    
}
