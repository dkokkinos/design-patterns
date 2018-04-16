using Observer.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public class ObserverDP : IDesignPattern
    {
        public void Run()
        {
            Vehicle vehicle = new Vehicle();

            Wheel wheelRight = new Wheel("back right")
            {
                Diameter = 13.5f
            };
            Wheel wheelLeft = new Wheel("back left")
            {
                Diameter = 13.5f
            };

            Engine engine = new Engine("porse engine")
            {
                HorsePower = 400f
            };

            vehicle.AddPart(wheelRight);
            vehicle.AddPart(wheelLeft);
            vehicle.AddPart(engine);

            wheelLeft.Diameter = 15.4f;
            wheelRight.Diameter = 10.4f;
            engine.HorsePower = 350f;

        }
    }
}
