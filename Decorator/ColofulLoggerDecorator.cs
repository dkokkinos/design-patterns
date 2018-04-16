using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ColofulLoggerDecorator : ILogger
    {
        ILogger Logger;
        public ColofulLoggerDecorator(ILogger logger)
        {
            this.Logger = logger;
        }
        public void Log(string text)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            this.Logger.Log(text);
            Console.ResetColor();
        }
    }
}
