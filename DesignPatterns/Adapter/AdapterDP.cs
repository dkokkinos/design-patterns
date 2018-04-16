using Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public class AdapterDP : IDesignPattern
    {
        public void Run()
        {
            IAudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play("sound.mp3", "mp3");
            audioPlayer.Play("sound.mp4", "mp4");
            audioPlayer.Play("sound.wav", "wav");
            audioPlayer.Play("sound.flac", "flac");
            audioPlayer.Play("sound.aiff", "aiff");
        }
    }
}
