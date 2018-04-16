using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class ProductsReport : DataAccessObject
    {
        private readonly string _path;

        public ProductsReport()
        {
            this._path = "products.txt";
        }

        protected override string GetRecords(StreamReader reader)
        {
            return base.GetRecords(reader);
        }

        protected override StreamReader Initialize()
        {
            return File.OpenText(this._path);
        }

        protected override void ProcessRecords(string records)
        {
            Console.WriteLine("processing the product records " + records);
        }
    }
}
