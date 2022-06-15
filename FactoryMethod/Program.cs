using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLogger = new LoggerClient(new ConsoleMessageDispatcherFactory());
            var fileSystemLogger = new LoggerClient(new FileSystemMessageDispatcherFactory());

            consoleLogger.Log("a message for console dispatcher.");
            fileSystemLogger.Log("a message for file system dispatcher.");
        }

        public class LoggerClient
        {
            private readonly MessageDispatcherFactory _factory;

            public LoggerClient(MessageDispatcherFactory factory)
            {
                _factory = factory;
            }

            public void Log(string message)
            {
                var messageDispatcher = this._factory.Create(message);
                messageDispatcher.Dispatch();
            }
        }
    }

}
 