using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class NewLineLoggerDecorator : ILogger
    {
        ILogger Logger;
        public NewLineLoggerDecorator(ILogger logger)
        {
            this.Logger = logger;
        }
        public void Log(string text)
        {
            this.Logger.Log(text);
            Console.WriteLine();
        }
    }
}
