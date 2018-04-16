using Flyweight.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Flyweight
{
    public class FlyweightDP : IDesignPattern
    {
        public void Run()
        {
            for(int i = 0; i< 100; i++)
            {
                int rndSize = new Random().Next(3, 5);
                IDocument doc = DocumentFactory.GetDocument(rndSize);

                doc.SetText("Text");

                doc.Draw();
            }
        }
    }
}
