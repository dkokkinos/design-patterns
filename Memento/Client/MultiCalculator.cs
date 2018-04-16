using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Client
{
    public class MultiCalculator
    {
        private ICollection<float> Numbers;

        public MultiCalculator()
        {
            this.Numbers = new List<float>();
        }

        public Memento<float> Save()
        {
            return new Memento<float>(this.Numbers);
        }
        
        public void Restore(Memento<float> memento)
        {
            while (memento.Any())
            {
                this.Numbers.Add(memento.Pop());
            }
        }

        public float Calculate()
        {
            float res = 0;
            foreach(var n in this.Numbers)
            {
                res += n;
            }
            return res;
        }
    }
}
