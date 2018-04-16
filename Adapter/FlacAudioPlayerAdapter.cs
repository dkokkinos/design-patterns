using Adapter.OtherAudioPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FlacAudioPlayerAdapter : IAudioPlayer
    {
        FlacAudioPlayer flacAudioPlayer { get; set; }
        public FlacAudioPlayerAdapter()
        {
            this.flacAudioPlayer = new FlacAudioPlayer(9600);
        }

        public void Play(string filePath, string fileType)
        {
            this.flacAudioPlayer.PlayFlac(filePath);
        }
    }
}
