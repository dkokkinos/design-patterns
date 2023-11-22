using Bridge.PortableSpeakerExample.WithBridgePattern;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.PortableSpeakerExample.WithoutBridgePattern
{
    public abstract class PortableSpeaker
    {
        public abstract void On();
        public abstract void Off();

        public abstract void IncreaseVolume();
        public abstract void DecreaseVolume();

        public abstract void CheckBattery();
    }

    public class SonyPortableSpeaker : PortableSpeaker
    {
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine("Turning off the portable speaker.");
        
        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");
    }

    public class MarshallPortableSpeaker : PortableSpeaker
    {
        public override void On() => Console.WriteLine($"{GetType().Name} =>Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} =>Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} =>Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} =>Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} =>Report the battery level.");
    }

    // If we want a new interface for our Portable Speaker, which will have different or
    // new methods in the PortableSpeaker abstract class, the subclasses will be greatly increased,
    // because we probably also have to support every company for this new interface.
    public abstract class CubePortableSpeaker : PortableSpeaker
    {
        public abstract void Mute();
    }

    public class SonyCubePortableSpeaker : CubePortableSpeaker
    {
        // A lot of duplicate code also.
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} =>Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");

        public override void Mute() => Console.WriteLine($"{GetType().Name} => Mute.");
    }

    public class SonyMarshallPortableSpeaker : CubePortableSpeaker
    {
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} =>Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");

        public override void Mute() => Console.WriteLine($"{GetType().Name} => Mute.");
    }
}
