using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace AbstractFactory.Plugin.StringFormatters
{
    public class ComplexStringFormatter : IStringFormatter
    {
        public string Format(string text)
        {
            return $"({text})";
        }
    }
}
