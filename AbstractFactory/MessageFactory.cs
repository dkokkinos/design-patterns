using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    /// <summary>
    /// The factory that creates a family of related objects
    /// </summary>
    public abstract class MessageFactory
    {
        public abstract MessageSerializer CreateMessageSerializer(string message);

        public abstract Analyzer CreateAnalyzer();

        public abstract MessageSender CreateSender();
    }
}
