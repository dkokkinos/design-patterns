using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OtherAudioPlayers
{
    public class FlacAudioPlayer
    {
        private readonly int baudRate;
        private readonly string audioFileLocation;

        public FlacAudioPlayer(int baudRate, string audioFileLocation)
        {
            this.baudRate = baudRate;
            this.audioFileLocation = audioFileLocation;
        }

        public void PlayFlac()
        {
            Console.WriteLine($"playing flac file:{this.audioFileLocation} at baudrate:{baudRate} from {nameof(FlacAudioPlayer)}");
        }

        public void Pause()
        {
            Console.WriteLine($"paused flac file:{this.audioFileLocation} from {nameof(FlacAudioPlayer)}");
        }
    }
}
