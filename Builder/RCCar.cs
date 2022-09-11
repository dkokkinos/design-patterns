using Builder.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class RCCar
    {
        public Board Board { get; }
        public List<Wheel> Wheels { get; }
        public int NumberOfMotors { get; }

        public RCCar(Board board, List<Wheel> wheels, int numberOfMotors)
        {
            Board = board;
            Wheels = wheels;
            NumberOfMotors = numberOfMotors;
        }

        public override string ToString()
        {
            return $"[Board:{Board}, Wheel Type:{Wheels.First()}, Number of wheels:{Wheels.Count()}, Number of motors:{NumberOfMotors}]";
        }
    }
}
