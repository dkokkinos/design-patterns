using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class MessageDispatcher
    {
        protected string Message;
        public abstract string Description { get; }
        public abstract void Dispatch();

        public abstract void SetMessage(string message);
        public abstract void PrepareMessage();
    }
}
