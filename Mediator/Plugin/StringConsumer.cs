using Mediator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Plugin
{
    public class StringConsumer : IConsumer
    {
        public void Receive(object message)
        {
            if (!(message is string))
                return;
            this.Receive(message.ToString());
        }

        private void Receive(string message)
        {
            Console.WriteLine( nameof(StringConsumer) + "received a string: " + message);
        }
    }
}
