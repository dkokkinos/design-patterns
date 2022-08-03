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
        {
            _builder.AddBoard(new Arduino());
            _builder.AddMotors(1);
            _builder.AddWheelType(WheelType.Simple);
            _builder.AddWheels(4);

            return _builder.Build();
        }
    }

    public class OmnidirectionalDirector : IDirector
    {
        private readonly IRCCarBuilder _builder;

        public OmnidirectionalDirector(IRCCarBuilder builder)
        {
            _builder = builder;
        }

        public RCCar Construct()
        {
            _builder.AddBoard(new UDOO());
            _builder.AddMotors(4);
            _builder.AddWheelType(WheelType.Omnidirectional);
            _builder.AddWheels(4);

            return _builder.Build();
        }
    }

    public class DifferentialDirector : IDirector
    {
        private readonly IRCCarBuilder _builder;

        public DifferentialDirector(IRCCarBuilder builder)
        {
            _builder = builder;
        }

        public RCCar Construct()
        {
            _builder.AddBoard(new UDOO());
            _builder.AddMotors(2);
            _builder.AddWheelType(WheelType.Simple);
            _builder.AddWheels(6);

            return _builder.Build();
        }
    }
}
