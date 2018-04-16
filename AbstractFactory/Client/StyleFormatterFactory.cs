using AbstractFactory.Plugin.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Client
{
    public class StyleFormatterFactory
    {
        public static StyleFormatter CreateFormatter(int code)
        {
            switch (code)
            {
                case 1:
                    return new PlainStyleFormatter();
                case 2:
                    return new ComplexStyleFormatter();
            }

            throw new ArgumentOutOfRangeException(code.ToString());
        }

        public static StyleFormatter Default
        {
            get
            {
                return new ComplexStyleFormatter();
            }
        }
    }
}
