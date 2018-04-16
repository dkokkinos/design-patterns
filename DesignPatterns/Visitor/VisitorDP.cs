using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor;

namespace DesignPatterns.Visitor
{
    public class VisitorDP : IDesignPattern
    {
        public void Run()
        {
            List<Particle> particles = new List<Particle>() {
                new Hydrogen("Hydrogen 1"),
                new Hydrogen("Hydrogen 2"),
                new Oxygen("Oxygen 1"),
                new Oxygen("Oxygen 2"),
            };

            ToUpperVisitor upperVisitor = new ToUpperVisitor();
            ToLowerVisitor lowerVisitor = new ToLowerVisitor();


            Console.WriteLine("visiting upperVisitor..");
            foreach(var p in particles)
            {
                p.Accept(upperVisitor);
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("visiting lowerVisitor..");
            foreach (var p in particles)
            {
                p.Accept(lowerVisitor);
                Console.WriteLine(p.Name);
            }


        }
    }
}
