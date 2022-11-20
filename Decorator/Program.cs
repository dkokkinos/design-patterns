using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("---------------- SimpleCacheScenario ----------------");
            SimpleCacheScenario();
            Console.WriteLine();

            Console.WriteLine("---------------- SecuredCacheScenario ----------------");
            SecuredCacheScenario();
            Console.WriteLine();

            Console.WriteLine("---------------- SecuredWithBufferedCacheScenario ----------------");
            SecuredWithBufferedCacheScenario();
            Console.WriteLine();
        }

        private static void SimpleCacheScenario()
        {
            var cache = new FileCache(Path.Combine(nameof(SimpleCacheScenario), "cache"));
            var client = new Client(cache);
            client.DoWork();
        }

        private static void SecuredCacheScenario()
        {
            var cache = new FileCache(Path.Combine(nameof(SecuredCacheScenario), "cache"));
            var securedCache = new SecuredCache(Path.Combine(nameof(SecuredCacheScenario), "hashes"), cache);
            var client = new Client(securedCache);
            client.DoWork();
            File.WriteAllText(Path.Combine(Path.Combine(nameof(SecuredCacheScenario), "cache"), "a"), "1112");
            try
            {
                client.DoAnotherWork();
            }
            catch (HashValidationException e)
            {
                Console.WriteLine(e.Message);
            }

            client.DoALotOfWork();
        }

        private static void SecuredWithBufferedCacheScenario()
        {
            var cache = new FileCache(Path.Combine(nameof(SecuredWithBufferedCacheScenario), "cache"));
            var bufferedCache = new BufferedCache(cache);
            var securedAndBufferedCache = new SecuredCache(Path.Combine(nameof(SecuredWithBufferedCacheScenario), "hashes"), bufferedCache);

            var client = new Client(securedAndBufferedCache);
            client.DoWork();
            client.DoAnotherWork();
            client.DoALotOfWork();
        }

        public class Client
        {
            private readonly ICache _cache;

            public Client(ICache cache)
            {
                _cache = cache;
            }

            public void DoWork()
            {
                _cache.Set("a", "11111");
                _cache.Set("b", "22222");
                _cache.Set("c", "33333");
                _cache.Set("b", "23456");

                var a = _cache.Get("a");
                var b = _cache.Get("b");
                var c = _cache.Get("c");
                Console.WriteLine("The entry with key a has value: " + a);
                Console.WriteLine("The entry with key b has value: " + b);
                Console.WriteLine("The entry with key c has value: " + c);
            }

            public void DoAnotherWork()
            {
                var a = _cache.Get("a");
                Console.WriteLine("The entry with key a has value: " + a);
            }

            public void DoALotOfWork()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                _cache.Set("d", "very big value...!");
                for (int i = 0; i < 1000; i++)
                {
                    var value = _cache.Get("d");
                    int numOfChars = value.Length; // do some calculation
                }
                sw.Stop();
                Console.WriteLine($"The work is finished after {sw.ElapsedMilliseconds} millis");
            }
        }

    }
}
