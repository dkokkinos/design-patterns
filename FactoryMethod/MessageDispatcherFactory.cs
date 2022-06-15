using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class MessageDispatcherFactory
    {
        public MessageDispatcher Create(string message)
        {
            MessageDispatcher dispatcher = this.CreateDispatcher();
            dispatcher.SetMessage(message);
            dispatcher.PrepareMessage();
            return dispatcher;
        }

        protected abstract MessageDispatcher CreateDispatcher();
    }
}
