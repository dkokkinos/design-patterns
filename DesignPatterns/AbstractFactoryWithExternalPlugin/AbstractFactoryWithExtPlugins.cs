using PluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace DesignPatterns.AbstractFactoryWithExternalPlugin
{
    public class AbstractFactoryWithExtPlugins : IDesignPattern
    {
        public void Run()
        {
            IPluginLoader<StyleFormatter> pluginLoader = new PluginManager<StyleFormatter>(@"C:\Users\kodi\Documents\Visual Studio 2015\Tests\DesignPatterns\AbstractFactory\ExternalPlugins");
            ICollection<StyleFormatter> formatters = pluginLoader.LoadPlugins();

            StyleFormatter firstFormatter = formatters.ElementAt(0);
            IStringFormatter stringFormatter = firstFormatter.CreateStringFormatter();
            INumberFormatter numberFormatter = firstFormatter.CreateNumberFormatter();
            
            string myMessage = "my message";
            int myNumber = 444;

            myMessage = stringFormatter.Format(myMessage);
            string myNumberStr = numberFormatter.Format(myNumber);

            Console.WriteLine($"formatted string:{myMessage} && formatted number:{myNumberStr}");

        }
    }
}
