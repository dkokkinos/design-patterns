using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace AbstractFactory.Plugin.NumberFormatters
{
    public class ComplexNumberFormatter : INumberFormatter
    {
        public string Format(object number)
        {
            return $"<{number}>";
        }
    }
}
