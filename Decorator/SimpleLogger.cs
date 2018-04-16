using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class SimpleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.Write(text);
        }
    }
}
