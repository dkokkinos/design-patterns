using Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class SingletonDP : IDesignPattern
    {
        public void Run()
        {
            Engine engine = EngineContext.Instance;

            engine.DoSomething();

            Engine engine2 = EngineContext.Instance;

            engine2.DoSomething();

            Console.WriteLine("are the same instance? " + (engine == engine2).ToString());
        }
    }
}
