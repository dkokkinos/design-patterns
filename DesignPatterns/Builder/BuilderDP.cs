using Builder.Client;
using Builder.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class BuilderDP : IDesignPattern
    {
        public void Run()
        {
            RCCarBuilder ackermanBuilder = new AckermanRCCarBuilder();
            RCCarBuilder differentialBuilder = new DifferentialRCCarBuilder();
            RCCarBuilder omnidirectionalBuilder = new OmniDirectionalRCCarBuilder();

            Director director = new Director();
            RCCar ackermanCar = director.Construct(ackermanBuilder);
            Console.WriteLine(ackermanCar);
            RCCar differentialCar = director.Construct(differentialBuilder);
            Console.WriteLine(differentialCar);
            RCCar omnidirectionalCar = director.Construct(omnidirectionalBuilder);
            Console.WriteLine(omnidirectionalCar);
            
        }
    }
}
