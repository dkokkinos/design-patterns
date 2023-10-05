using Mediator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Plugin
{
    public class Mediator// : IMediator
    {
        private ICollection<IConsumer> Consumers;

        public Mediator()
        {
            this.Consumers = new List<IConsumer>();
        }
         
        public void Add(string message)
        {
            this.Consumers.ToList().ForEach(x => x.Receive(message));
        }

        public void Add(int number)
        {
            this.Consumers.ToList().ForEach(x => x.Receive(number));
        }

        public void AddConsumer(IConsumer consumer)
        {
            this.Consumers.Add(consumer);
        }
    }
}
