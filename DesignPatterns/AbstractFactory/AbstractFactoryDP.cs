using AbstractFactory.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    public class AbstractFactoryDP : IDesignPattern
    {
        public void Run()
        {
            StyleFormatter formatter = StyleFormatterFactory.CreateFormatter(2);
            // or
            //StyleFormatter defaultFormatter = StyleFormatterFactory.Default;

            IStringFormatter stringFormatter = formatter.CreateStringFormatter();
            INumberFormatter numberFormatter = formatter.CreateNumberFormatter();


            string myMessage = "my message";
            int myNumber = 444;

            myMessage = stringFormatter.Format(myMessage);
            string myNumberStr = numberFormatter.Format(myNumber);

            Console.WriteLine($"formatted string:{myMessage} && formatted number:{myNumberStr}");
            
        }
    }
}
