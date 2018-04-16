using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class CustomerReport : DataAccessObject
    {
        private readonly string _path;

        public CustomerReport()
        {
            this._path = "customers.txt";
        }

        protected override StreamReader Initialize()
        {
            return File.OpenText(this._path);
        }

        protected override void ProcessRecords(string records)
        {
            Console.WriteLine("processing the customer records: " + records);
        }
    }
}
