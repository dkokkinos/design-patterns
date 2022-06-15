using AbstractFactory.Messaging.Anayzers;
using AbstractFactory.Messaging.Senders;
using AbstractFactory.Messaging.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    public class DevelopmentMessageFactory : MessageFactory
    {
        public override MessageSerializer CreateMessageSerializer(string message)
        {
            return new CsvMessageSerializer(message);
        }

        public override Analyzer CreateAnalyzer()
        {
            return new CharacterAnalyzer();
        }

        public override MessageSender CreateSender()
        {
            return new ConsoleMessageSender();
        }
    }
}
