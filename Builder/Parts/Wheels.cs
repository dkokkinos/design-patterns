using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Parts
{
    public abstract class Wheel
    {

    }

    public class SimpleWheel : Wheel
    {
        public override string ToString() => "Simple Wheel";
    }

    public class OmnidirectionalWheel : Wheel 
    {
        public override string ToString() => "Omnidirectional Wheel";
    }

    public enum WheelType 
    { 
        Simple,
        Omnidirectional
    }
}
