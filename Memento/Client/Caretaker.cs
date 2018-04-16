using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Client
{
    public class Caretaker
    {
        private Memento<float> MultiMemento;
        private Memento<float> SimpleMemento;

        public Caretaker()
        {
            this.MultiMemento = new Memento<float>(new List<float>() { 2323,42});
            this.SimpleMemento = new Memento<float>(new List<float>() { 2, 2 });
        }

        public MultiCalculator RestoreMultiCalculator()
        {
            MultiCalculator c = new MultiCalculator();
            c.Restore(this.MultiMemento);
            return c;
        }

        public Calculator RestoreSimpleCalculator()
        {
            Calculator c = new Calculator();
            c.Restore(this.SimpleMemento);
            return c;
        }

        public void SaveMultiCalculator(MultiCalculator calc)
        {
            this.MultiMemento = calc.Save();
        }
        public void SaveSimpleCalculator(Calculator calc)
        {
            this.SimpleMemento = calc.Save();
        }

    }
}
