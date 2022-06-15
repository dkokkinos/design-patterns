using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class ConsoleMessageDispatcher : MessageDispatcher
    {
        public override string Description => "I am a console message dispatcher.";

        public override void Dispatch()
        {
            Console.WriteLine(this.Message);
        }

        public override void SetMessage(string message)
        {
            this.Message = message;
        }

        public override void PrepareMessage()
        {
            this.Message = Regex.Replace(this.Message, @"\s+", " ").Trim();
        }
    }
}
