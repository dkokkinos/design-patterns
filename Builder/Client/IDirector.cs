using Builder.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Client
{
    public interface IDirector
    {
        RCCar Construct();
    }

    public class AckermanDirector : IDirector
    {
        private readonly IRCCarBuilder _builder;

        public AckermanDirector(IRCCarBuilder builder)
        {
            _builder = builder;
        }

        public RCCar Construct()
            => _builder.AddBoard(new Arduino())
                .AddMotors(1)
                .AddWheelType(WheelType.Simple)
                .AddWheels(4)
                .Build();
    }

    public class OmnidirectionalDirector : IDirector
    {
        private readonly IRCCarBuilder _builder;

        public OmnidirectionalDirector(IRCCarBuilder builder)
        {
            _builder = builder;
        }

        public RCCar Construct()
            => _builder.AddBoard(new UDOO())
                .AddMotors(4)
                .AddWheelType(WheelType.Omnidirectional)
                .AddWheels(4)
                .Build();
    }

    public class DifferentialDirector : IDirector
    {
        private readonly IRCCarBuilder _builder;

        public DifferentialDirector(IRCCarBuilder builder)
        {
            _builder = builder;
        }

        public RCCar Construct()
            => _builder.AddBoard(new UDOO())
                .AddMotors(2)
                .AddWheelType(WheelType.Simple)
                .AddWheels(6)
                .Build();
    }
}
