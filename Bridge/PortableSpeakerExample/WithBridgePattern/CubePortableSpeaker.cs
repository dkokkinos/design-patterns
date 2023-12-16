namespace Bridge.PortableSpeakerExample.WithBridgePattern
{
    public class CubePortableSpeaker : PortableSpeaker
    {
        public CubePortableSpeaker(SpeakerController speakerController)
            : base(speakerController) { }

        public void Mute() => speakerController.SetVolume(0);
    }

}
