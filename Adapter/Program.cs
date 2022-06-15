using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayerClient client = new AudioPlayerClient(new LegacyAudioPlayer());
            client.Play("song.mp3");
            client.Stop();

            client = new AudioPlayerClient(new FlacAudioPlayerAdapter());
            client.Play("song.flac");
            client.Stop();
        }

        public class AudioPlayerClient
        {
            private readonly LegacyAudioPlayer _audioPlayer;

            public AudioPlayerClient(LegacyAudioPlayer audioPlayer)
            {
                _audioPlayer = audioPlayer;
            }

            public void Play(string audioFileLocation)
            {
                _audioPlayer.SetAudioFileLocation(audioFileLocation);
                _audioPlayer.StartPlayAudio();
            }

            public void Stop()
            {
                _audioPlayer.StopPlayAudio();
            }
        }
    }
}
