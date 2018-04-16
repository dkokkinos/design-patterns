using Factory.Client;
using Factory.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class FactoryDP : IDesignPattern
    {
        public void Run()
        {
            Image image = null;
            ImageReader reader = new PngImageReader();

            image = reader.GetImage("image 1");

            Console.WriteLine(image);
        }
    }
}
