using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class AudioPlayer : IAudioPlayer
    {
        public void Play(string filePath, string fileType)
        {
            if(fileType == "mp3" || fileType == "wav")
            {
                Console.WriteLine("playing " + filePath + " from existing player");
            }else if(fileType == "flac")
            {
                IAudioPlayer audioPlayer = new FlacAudioPlayerAdapter();
                audioPlayer.Play(filePath, fileType);
            }else if(fileType == "mp4")
            {
                IAudioPlayer audioPlayer = new Mp4AudioPlayerAdapter();
                audioPlayer.Play(filePath, fileType);
            }else
            {
                Console.WriteLine($"{fileType} is not supported");
            }
            
        }
    }
}
