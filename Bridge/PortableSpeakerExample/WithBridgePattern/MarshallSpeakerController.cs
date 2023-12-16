namespace Bridge.PortableSpeakerExample.WithBridgePattern
{
    public class MarshallSpeakerController : SpeakerController
    {
        public override void CheckBattery() { /* Report the battery level. */ }

        public override int GetVolume() => 40; // Returning the volume percentage.

        public override void SetVolume(int volume) { /* Setting the volume. */ }

        public override void TurnOff() { /* Turn off device. */ }

        public override void TurnOn() { /* Turn on device. */ }
    }

}
