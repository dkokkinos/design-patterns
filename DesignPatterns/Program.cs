using DesignPatterns.AbstractFactory;
using DesignPatterns.AbstractFactoryWithExternalPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IDesignPattern designPattern = new Visitor.VisitorDP();
            
            designPattern.Run();
            Console.ReadKey();
        }
    }
}
