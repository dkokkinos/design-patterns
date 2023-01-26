using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class Report
    {
        protected readonly string _filePath;

        protected Report(string filePath)
        {
            _filePath = filePath;
        }

        // This is the template method.
        public void Run()
        {
            var records = ReadRecords();
            var result = ProcessRecords(records);
            SendResult(result);
        }

        // Methods that must be implemented by subclasses
        protected abstract List<string[]> ReadRecords();
        protected abstract object ProcessRecords(List<string[]> records);

        // Method with default implementation.
        protected virtual void SendResult(object result) => Console.WriteLine(result.ToString());
    }
}
