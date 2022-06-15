using AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class Program
    {
        public static void Main()
        {
            var client = new LoggerClient(new DevelopmentMessageFactory());
            client.Log("a test message.");

            client = new LoggerClient(new ProductionMessageFactory());
            client.Log("another test message.");
        }

        /// <summary>
        /// The client that uses the factory in order to get a family of related objects
        /// </summary>
        public class LoggerClient
        {
            private readonly MessageFactory _factory;

            public LoggerClient(MessageFactory factory)
            {
                this._factory = factory;
            }

            public void Log(string message)
            {
                var messageSerializer = this._factory.CreateMessageSerializer(message);
                
                var analyzer = this._factory.CreateAnalyzer();
                var result = analyzer.Analyze(messageSerializer.Message);
                Console.WriteLine("Analyze result: " + result);

                var sender = this._factory.CreateSender();
                sender.Send(messageSerializer.GetSerializedMessage());
            }
        }
    }
}
