using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OtherAudioPlayers
{
    public class FlacAudioPlayer
    {
        public FlacAudioPlayer(int baudRate)
        {

        }

        public void PlayFlac(string path)
        {
            Console.WriteLine($"paying flac file:{path} from {nameof(FlacAudioPlayer)}");
        }

    }
}
