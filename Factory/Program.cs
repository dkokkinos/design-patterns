using Factory;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LoggerClient("console");
            client.Log("a message");

            client = new LoggerClient("filesystem");
            client.Log("another message");
        }

        public class LoggerClient
        {
            private readonly string _type;

            public LoggerClient(string type)
            {
                _type = type;
            }

            public void Log(string message)
            {
                var messageDispatcher = MessageDispatcherFactory.Create(this._type, message);
                messageDispatcher.Dispatch();
            }
        }
    }

}
 