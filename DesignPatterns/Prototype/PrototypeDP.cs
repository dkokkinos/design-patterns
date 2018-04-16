using Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public class PrototypeDP : IDesignPattern
    {
        public void Run()
        {
            ActorRegistry registry = new ActorRegistry();

            registry[typeof(Associate)] = new Associate();
            registry[typeof(Canditate)] = new Canditate();

            Associate ass1 = registry[typeof(Associate)].Clone("the new name") as Associate;
            Associate ass2 = registry[typeof(Associate)].Clone("the new name 222") as Associate;
            Associate ass3 = registry[typeof(Associate)].Clone("the new name 333") as Associate;

            Canditate cand1 = registry[typeof(Canditate)].Clone("the Canditate 11") as Canditate;
            Canditate cand2 = registry[typeof(Canditate)].Clone("the Canditate 22") as Canditate;

            this.Print(ass1, ass2, ass3, cand1, cand2);
        }

        private void Print(params Actor [] actors)
        {
            foreach(var a in actors)
            {
                Console.WriteLine(a);
            }
        }
    }
}
