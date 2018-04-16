using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Client
{
    public abstract class Image
    {
        string Name { get; set; }
        protected string Type { get; set; }
        public Image(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{this.Name} of type {this.Type}";
        }

    }
}
