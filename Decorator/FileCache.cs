using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class FileCache : ICache
    {
        private readonly string _location;

        public FileCache(string location)
        {
            Directory.CreateDirectory(location);
            _location = location;
        }

        public string GetFilePath(string key)
            => Path.Combine(_location, key);

        public bool Exists(string key)
            => File.Exists(GetFilePath(key));

        public string Get(string key)
        {
            if (!Exists(key))
                throw new KeyNotFoundException(key);

            return File.ReadAllText(GetFilePath(key));
        }

        public void Set(string key, string value)
        {
            if (Exists(key))
                File.Delete(GetFilePath(key));

            File.WriteAllText(GetFilePath(key), value);
        }
    }
}
