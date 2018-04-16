using Factory.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class PngImage : Image
    {
        public PngImage(string name) : base(name)
        {
            this.Type = "png";
        }
    }
}
