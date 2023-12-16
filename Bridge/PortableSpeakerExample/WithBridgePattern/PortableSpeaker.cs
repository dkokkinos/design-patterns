using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.PortableSpeakerExample.WithBridgePattern
{
    // In Bridge Pattern we separate the Abstraction for its implementation.
    // In this example one concept is the company (sony, samsung etc) that has different implementation details.
    // The other is which type of interface and functionality the speaker will have (Cubed-shaped speaker, Column-shaped speaker etc).
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
}
