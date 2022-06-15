using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.MessageDispatchers
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
            File.AppendAllText(path, Message);
        }

        public override void SetMessage(string message)
        {
            Message = message;
        }

        public override void PrepareMessage()
        {
            // other formatting
        }
    }
}
