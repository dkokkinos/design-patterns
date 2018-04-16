using Builder.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Plugin
{
    public class OmniDirectionalRCCarBuilder : RCCarBuilder
    {
        public OmniDirectionalRCCarBuilder()
        {
            base.RCCar = new RCCar("OmniDirectionalRCCar");
        }
        public override void BuildBoard()
        {
            base.RCCar.Board = "arduino uno";
        }

        public override void BuildMotorDrivers()
        {
            base.RCCar.MotorDriver = "4 servos for complete wheel independence";
        }

        public override void BuildWheels()
        {
            base.RCCar.NumberOfWheels = 4;
        }
    }
}
