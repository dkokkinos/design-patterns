using Mediator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Plugin
{
    public class NumberConsumer : IConsumer
    {
        
        public void Receive(object message)
        {
            if (!(message is int))
                return;
            this.Receive((int)message);
        }

        private void Receive(int number)
        {
            Console.WriteLine( nameof(NumberConsumer) + " received a number " + number);
        }
    }
}
