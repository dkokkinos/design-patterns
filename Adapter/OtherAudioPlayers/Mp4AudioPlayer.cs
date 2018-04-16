using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OtherAudioPlayers
{
    public class Mp4AudioPlayer
    {
        string Path { get; set; }
        public void SetPath(string path)
        {
            this.Path = path;
        }
        public void PlayMp4()
        {
            Console.WriteLine($"playing mp4 file:{this.Path} from:{nameof(Mp4AudioPlayer)}");
        }
    }
}
