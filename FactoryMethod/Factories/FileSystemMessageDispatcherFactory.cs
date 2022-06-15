using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class FileSystemMessageDispatcherFactory : MessageDispatcherFactory
    {
        protected override MessageDispatcher CreateDispatcher()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "logs.txt");
            return new FileSystemMessageDispatcher(path);
        }
    }
}
