using Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class DecoratorDP : IDesignPattern
    {
        public void Run()
        {
            ILogger logger = new SimpleLogger();
            logger.Log("text with simple logger");
            logger.Log("another text with simple logger");
            logger.Log("123123 123 1text with simple logger");

            ILogger withNewLine = new NewLineLoggerDecorator(logger);
            withNewLine.Log("text with new line logger");
            withNewLine.Log("another text with new line logger");

            ILogger colorfulLogger = new ColofulLoggerDecorator(logger);
            colorfulLogger.Log("text with colorful logger");
            colorfulLogger.Log("another text colorful line logger");

            ILogger fullLogger = new ColofulLoggerDecorator(withNewLine);
            fullLogger.Log(" rewegsdgsdfg dsfg 5g erg g dfdsg");
            fullLogger.Log("another text full logger1 2312");
            fullLogger.Log("text with full logger1 23123 ");
            fullLogger.Log("another text full logger 123123");

        }
    }
}
