using AbstractFactory.Plugin.NumberFormatters;
using AbstractFactory.Plugin.StringFormatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace AbstractFactory.Plugin.Styles
{
    public class ComplexStyleFormatter : StyleFormatter
    {
        public override INumberFormatter CreateNumberFormatter()
        {
            return new ComplexNumberFormatter();
        }

        public override IStringFormatter CreateStringFormatter()
        {
            return new ComplexStringFormatter();
        }
    }
}
