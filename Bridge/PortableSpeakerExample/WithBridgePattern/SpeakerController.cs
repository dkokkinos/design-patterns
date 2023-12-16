namespace Bridge.PortableSpeakerExample.WithBridgePattern
{
    // The company specific details are abstracted through the SpeakerController class.
    public abstract class SpeakerController
    {
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void SetVolume(int volume);
        public abstract int GetVolume();
        public abstract void CheckBattery();
    }

}
