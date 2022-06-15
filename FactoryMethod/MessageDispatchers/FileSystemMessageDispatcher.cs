using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class FileSystemMessageDispatcher : MessageDispatcher
    {
        private readonly string path;

        public override string Description => "I am a file system message dispatcher.";

        public FileSystemMessageDispatcher(string path)
        {
            this.path = path;
        }

        public override void Dispatch()
        {
            File.AppendAllText(this.path, this.Message);
        }

        public override void SetMessage(string message)
        {
            this.Message = message;
        }

        public override void PrepareMessage() { }
    }
}
