using Builder.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Plugin
{
    public class AckermanRCCarBuilder : RCCarBuilder
    {
        public AckermanRCCarBuilder()
        {
            base.RCCar = new RCCar("AckermanRCCar");
        }
        public override void BuildBoard()
        {
            base.RCCar.Board = "arduino uno";
        }

        public override void BuildMotorDrivers()
        {
            base.RCCar.MotorDriver = "with servo for steering";
        }

        public override void BuildWheels()
        {
            this.RCCar.NumberOfWheels = 4;
        }
    }
}
