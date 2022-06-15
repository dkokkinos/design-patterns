using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Messaging.Senders
{
    public class ConsoleMessageSender : MessageSender
    {
        public override void Send(string message)
        {
            Console.WriteLine("sending message:" + message + " via console");
        }
    }
}
