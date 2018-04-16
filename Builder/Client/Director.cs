using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Client
{
    public class Director
    {
        public RCCar Construct(RCCarBuilder builder)
        {
            builder.BuildBoard();
            builder.BuildMotorDrivers();
            builder.BuildWheels();
            return builder.GetRCCar();
        }
    }
}
