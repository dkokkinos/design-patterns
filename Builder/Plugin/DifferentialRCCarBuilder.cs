using Builder.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Plugin
{
    public class DifferentialRCCarBuilder : RCCarBuilder
    {
        public DifferentialRCCarBuilder()
        {
            base.RCCar = new RCCar("DifferentialRCCar");
        }
        public override void BuildBoard()
        {
            base.RCCar.Board = "arduino uno";
        }

        public override void BuildMotorDrivers()
        {
            base.RCCar.MotorDriver = "with 2 servo for independent steering";
        }

        public override void BuildWheels()
        {
            base.RCCar.NumberOfWheels = 3;
        }
    }
}
