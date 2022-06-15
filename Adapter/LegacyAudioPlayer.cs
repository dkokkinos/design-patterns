using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class LegacyAudioPlayer
    {
        private string _audioFileLocation;

        public virtual void SetAudioFileLocation(string audioFileLocation)
        {
            _audioFileLocation = audioFileLocation;
        }

        public virtual void StartPlayAudio()
        {
            Console.WriteLine($"start playing mp3 audio file:{_audioFileLocation} from:{nameof(LegacyAudioPlayer)}");
        }

        public virtual void StopPlayAudio()
        {
            Console.WriteLine($"stop playing mp3 audio file:{_audioFileLocation} from:{nameof(LegacyAudioPlayer)}");
        }
    }
}
