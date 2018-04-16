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
    public class PlainStyleFormatter : StyleFormatter
    {
        public override INumberFormatter CreateNumberFormatter()
        {
            return new PlainNumberFormatter();
        }

        public override IStringFormatter CreateStringFormatter()
        {
            return new PlainStringFormatter();
        }
    }
}
