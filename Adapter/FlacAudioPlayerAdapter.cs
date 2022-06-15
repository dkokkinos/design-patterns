using Adapter.OtherAudioPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FlacAudioPlayerAdapter : LegacyAudioPlayer
    {
        FlacAudioPlayer flacAudioPlayer { get; set; }
        
        public override void SetAudioFileLocation(string audioFileLocation)
        {
            this.flacAudioPlayer = new FlacAudioPlayer(9600, audioFileLocation);
        }

        public override void StartPlayAudio()
        {
            this.flacAudioPlayer.PlayFlac();
        }

        public override void StopPlayAudio()
        {
            this.flacAudioPlayer.Pause();
        }

    }
}
