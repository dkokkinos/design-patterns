using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public abstract class MessageSender
    {
        public abstract void Send(string message);
    }
}
