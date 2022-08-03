using Builder.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Client
{
    public interface IRCCarBuilder
    {
        IRCCarBuilder AddBoard(Board board);
        IRCCarBuilder AddWheels(int count);
        IRCCarBuilder AddWheelType(WheelType wheelType);
        IRCCarBuilder AddMotors(int count);

        RCCar Build();
    }
}
