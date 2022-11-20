using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class SecuredCache : CacheDecorator
    {
        private readonly string _location;

        public SecuredCache(string location, ICache inner) : base(inner)
        {
            Directory.CreateDirectory(location);
            this._location = location;
        }

        public override void Set(string key, string value)
        {
            _inner.Set(key, value);
            var hash = CalculateHash(value);
            StoreHash(key, hash);
        }

        public override string Get(string key)
        {
            var entry = _inner.Get(key);
            var hash = CalculateHash(entry);
            EnsureHashIsValid(key, hash);
            return entry;
        }

        private byte[] CalculateHash(string entry)
        {
            var tmpSource = ASCIIEncoding.ASCII.GetBytes(entry);
            var tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return tmpHash;
        }

        private void StoreHash(string key, byte[] data)
            => File.WriteAllBytes(Path.Combine(_location, key), data);
        
        private void EnsureHashIsValid(string key, byte[] hash)
        {
            var oldHash = File.ReadAllBytes(Path.Combine(_location, key));
            if (!CompareByteArrays(oldHash, hash))
                throw new HashValidationException($"Hashes are not equal! Key {key} is not valid");
        }

        private bool CompareByteArrays(byte[] oldHash, byte[] newHash)
        {
            if (newHash.Length == oldHash.Length)
            {
                int i = 0;
                while ((i < newHash.Length) && (newHash[i] == oldHash[i]))
                {
                    i += 1;
                }
                if (i == newHash.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class HashValidationException : Exception
    {
        public HashValidationException(string message) : base(message)
        {
        }
    }
}
