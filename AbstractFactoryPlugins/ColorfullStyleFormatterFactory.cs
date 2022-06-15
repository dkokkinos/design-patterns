using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Client;

namespace AbstractFactoryPlugins
{
    public class ColorfullStyleFormatterFactory : StyleFormatterFactory
    {
        public override INumberFormatter CreateNumberFormatter()
        {
            return new ColorfulNumberStyleFormatter();
        }

        public override IStringFormatter CreateStringFormatter()
        {
            return new ColorfulStringFormatter();
        }
    }
}
