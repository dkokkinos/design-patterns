using AbstractFactory.Messaging.Anayzers;
using AbstractFactory.Messaging.Senders;
using AbstractFactory.Messaging.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    class ProductionMessageFactory : MessageFactory
    {
        public override MessageSerializer CreateMessageSerializer(string message)
        {
            return new JsonMessageSerializer(message);
        }

        public override Analyzer CreateAnalyzer()
        {
            return new TokenAnalyzer();
        }

        public override MessageSender CreateSender()
        {
            return new HttpMessageSender();
        }
    }
}
