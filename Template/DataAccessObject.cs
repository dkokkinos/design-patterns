using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class DataAccessObject
    {
        protected StreamReader _reader;

        public void Run()
        {
            this._reader = this.Initialize();
            string res = this.GetRecords(_reader);
            this.ProcessRecords(res);
            this.Finilize();
        }

        protected abstract StreamReader Initialize();
        protected abstract void ProcessRecords(string records);

        protected virtual string GetRecords(StreamReader reader)
        {
            var result = new char[reader.BaseStream.Length];
            reader.Read(result, 0, (int)reader.BaseStream.Length);

            StringBuilder builder = new StringBuilder();
            foreach (char c in result)
            {
                if (c == '\n')
                {
                    builder.AppendLine();
                }
                else if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }

        protected virtual void Finilize()
        {
            this._reader.Dispose();
        }
    }
}
