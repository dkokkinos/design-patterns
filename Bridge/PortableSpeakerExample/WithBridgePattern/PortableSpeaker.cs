using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.PortableSpeakerExample.WithBridgePattern
{
    // In Bridge Pattern we separate the Abstraction for its implementation.
    // In this example one concept is the company (sony, samsung etc) that has different implementation details.
    // The other is which type of interface and functionality the speaker will have (Cube, Column etc).
    public abstract class PortableSpeaker
    {
        // The bridge reference.
        protected readonly SpeakerController speakerController;

        protected PortableSpeaker(SpeakerController speakerController)
        {
            this.speakerController = speakerController;
        }

        public void On() => speakerController.TurnOn();

        public void Off() => speakerController.TurnOff();

        public void IncreaseVolume() => speakerController.SetVolume(speakerController.GetVolume() + 5);
        public void DecreaseVolume() => speakerController.SetVolume(speakerController.GetVolume() - 5);

        public void CheckBattery() => speakerController.CheckBattery();
    }

    public class CubePortableSpeaker : PortableSpeaker
    {
        public CubePortableSpeaker(SpeakerController speakerController)
            : base(speakerController) { }

        public void Mute() => speakerController.SetVolume(0);
    }

    // The company specific details are abstracted through the SpeakerController class
    public abstract class SpeakerController
    {
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void SetVolume(int volume);
        public abstract int GetVolume();
        public abstract void CheckBattery();
    }

    public class SoneSpeakerController : SpeakerController
    {
        public override void CheckBattery() => Console.WriteLine("Report the battery level.");

        public override int GetVolume() => 40; // Returning the volume percentage.

        public override void SetVolume(int volume) { /* Setting the volume. */ }

        public override void TurnOff() { /* Turn off device. */ }

        public override void TurnOn() { /* Turn on device. */ }
    }

    public class MarshallSpeakerController : SpeakerController
    {
        public override void CheckBattery() { /* Report the battery level. */ }

        public override int GetVolume() => 40; // Returning the volume percentage.

        public override void SetVolume(int volume) { /* Setting the volume. */ }

        public override void TurnOff() { /* Turn off device. */ }

        public override void TurnOn() { /* Turn on device. */ }
    }

}
