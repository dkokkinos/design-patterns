using Builder.Client;
using Builder.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class RCCarBuilder : IRCCarBuilder
    {
        private List<Wheel> _wheels = new List<Wheel>();
        private int _numberOfMotors;
        private WheelType _wheelType;
        private Board _board;

        public IRCCarBuilder AddBoard(Board board)
        {
            _board = board;
            return this;
        }

        public IRCCarBuilder AddMotors(int count)
        {
            _numberOfMotors = count;
            return this;
        }

        public IRCCarBuilder AddWheelType(WheelType wheelType)
        {
            _wheelType = wheelType;
            return this;
        }

        public IRCCarBuilder AddWheels(int count)
        {
            _wheels.Clear();
            for (int i = 0; i < count; i++)
            {
                _wheels.Add(CreateWheel());
            }
            return this;
        }

        private Wheel CreateWheel()
        {
            switch (_wheelType)
            {
                case WheelType.Simple:
                    return new SimpleWheel();
                case WheelType.Omnidirectional:
                    return new OmnidirectionalWheel();
            }

            throw new ArgumentException();
        }

        public RCCar Build()
        {
            return new RCCar(_board, _wheels, _numberOfMotors);
        }
    }
}
