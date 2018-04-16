using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Client
{
    public class Calculator
    {
        public float Number1 { get; set; }
        public float Number2 { get; set; }

        public Memento<float> Save() {
            return new Memento<float>(new List<float>() { Number1, Number2 });
        }

        public void Restore(Memento<float> memento)
        {
            if (memento.Count != 2)
                return;
            this.Number1 = memento.Pop();
            this.Number2 = memento.Pop();
        }

        public float Calculate()
        {
            return this.Number1 + this.Number2;
        }
    }
}
