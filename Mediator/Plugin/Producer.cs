using Mediator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Plugin
{
    public class Producer : IProducer
    {
        private readonly IMediator _mediator;
        public Producer(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        // TODO hacky! only for testing
        public void Impersonate(object message)
        {
            if (message is string)
                this._mediator.Add(message.ToString());
            else if (message is int)
                this._mediator.Add((int)message);
        }

    }
}
