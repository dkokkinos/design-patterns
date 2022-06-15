using Factory.MessageDispatchers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Factory
{
    public class MessageDispatcherFactory
    {
        public static MessageDispatcher Create(string type, string message)
        {
            MessageDispatcher messageDispatcher = null;

            if (type == "console")
                messageDispatcher = new ConsoleMessageDispatcher();
            else if (type == "filesystem")
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "logs.txt");
                messageDispatcher = new FileSystemMessageDispatcher(path);
            }else
                throw new InvalidOperationException("There is no message dispatcher for type:" + type);

            messageDispatcher.SetMessage(message);
            messageDispatcher.PrepareMessage();
            return messageDispatcher;
        }
    }
}
