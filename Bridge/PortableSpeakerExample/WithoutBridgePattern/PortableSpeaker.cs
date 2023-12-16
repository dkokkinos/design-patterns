using System;

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
        // The Cube portable speakers should provide this extra operation.
        public abstract void Mute();
    }

    public class SonyCubePortableSpeaker : CubePortableSpeaker
    {
        // A lot of duplicate code also.
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} => Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");

        public override void Mute() => Console.WriteLine($"{GetType().Name} => Mute.");
    }

    public class MarshallCubePortableSpeaker : CubePortableSpeaker
    {
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} => Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");

        public override void Mute() => Console.WriteLine($"{GetType().Name} => Mute.");
    }

    // The same is true for a column portable speaker, which will have different needs and a different interface
    public abstract class ColumnPortableSpeaker : PortableSpeaker
    {
        // The Cube portable speakers should provide these extra operations.
        public abstract void TurnOnBluetooth();
        public abstract void TurnOffBluetooth();
    }

    public class SonyColumnPortableSpeaker : ColumnPortableSpeaker
    {
        // A lot of duplicate code also.
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} => Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");

        public override void TurnOnBluetooth() => Console.WriteLine($"{GetType().Name} => Turn on bluetooth.");
        public override void TurnOffBluetooth() => Console.WriteLine($"{GetType().Name} => Turn off bluetooth.");
    }

    public class MarshallColumnPortableSpeaker : ColumnPortableSpeaker
    {
        public override void On() => Console.WriteLine($"{GetType().Name} => Turning on the portable speaker.");
        public override void Off() => Console.WriteLine($"{GetType().Name} => Turning off the portable speaker.");

        public override void IncreaseVolume() => Console.WriteLine($"{GetType().Name} => Increasing the volume.");
        public override void DecreaseVolume() => Console.WriteLine($"{GetType().Name} => Decreasing the volume.");

        public override void CheckBattery() => Console.WriteLine($"{GetType().Name} => Report the battery level.");

        public override void TurnOnBluetooth() => Console.WriteLine($"{GetType().Name} => Turn on bluetooth.");
        public override void TurnOffBluetooth() => Console.WriteLine($"{GetType().Name} => Turn off bluetooth.");
    }

}
