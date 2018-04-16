using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Client
{
    public abstract class RCCarBuilder
    {
        protected RCCar RCCar { get; set; }
        public RCCar GetRCCar()
        {
            return this.RCCar;
        }
        public abstract void BuildWheels();
        public abstract void BuildMotorDrivers();
        public abstract void BuildBoard();
    }
}
