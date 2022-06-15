using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class MessageSerializer
    {
        public string Message { get; }

        protected MessageSerializer(string message)
        {
            Message = message;
        }

        public abstract string Description { get; }

        public abstract string GetSerializedMessage();
    }
}
