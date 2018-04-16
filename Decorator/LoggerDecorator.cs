using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class LoggerDecorator : ILogger
    {
        public abstract void Log(string text);
    }
}
