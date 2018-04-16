using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace AbstractFactoryPlugins
{
    public class ColorfulNumberStyleFormatter : INumberFormatter
    {
        public string Format(object number)
        {
            return $"<green>{number}</green>";
        }
    }
}
