using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Table
    {
        public Column Column { get; set; }

        private readonly string _name;

        public Table(string name)
        {
            this._name = name;
            this.Column = new Column();
        }

        public override string ToString()
        {
            string res = string.Empty;
            res += this._name + Environment.NewLine;
            foreach(var c in this.Column)
            {
                res += c + Environment.NewLine;
            }
            return res;
        }
    }
}
