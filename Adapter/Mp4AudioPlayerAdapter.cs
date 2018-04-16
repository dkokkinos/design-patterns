using Adapter.OtherAudioPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Mp4AudioPlayerAdapter : IAudioPlayer
    {
        Mp4AudioPlayer mp4AudioPlayer { get; set; }
        public Mp4AudioPlayerAdapter()
        {
            this.mp4AudioPlayer = new Mp4AudioPlayer();
        }
        public void Play(string filePath, string fileType)
        {
            this.mp4AudioPlayer.SetPath(filePath);
            this.mp4AudioPlayer.PlayMp4();
        }
    }
}
