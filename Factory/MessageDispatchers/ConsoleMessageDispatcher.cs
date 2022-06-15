using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Factory.MessageDispatchers
{
    public class ConsoleMessageDispatcher : MessageDispatcher
    {
        public override string Description => "I am a console message dispatcher.";

        public override void Dispatch()
        {
            Console.WriteLine(Message);
        }

        public override void SetMessage(string message)
        {
            Message = message;
        }

        public override void PrepareMessage()
        {
            Message = Regex.Replace(Message, @"\s+", " ").Trim();
        }
    }
}
