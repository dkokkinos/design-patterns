using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace AbstractFactoryPlugins
{
    public class ColorfulStringFormatter : IStringFormatter
    {
        public string Format(string text)
        {
            return $"<red>{text}</red>";
        }
    }
}
