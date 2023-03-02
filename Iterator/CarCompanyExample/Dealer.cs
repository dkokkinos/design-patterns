using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExample
{
    public class Dealer
    {
        private readonly List<Company> _companies;

        public Dealer(params Company[] companies)
        {
            this._companies = companies.ToList();
        }

        public void PrintCars()
        {
            for (int i = 0; i < _companies.Count; i++)
            {
                PrintCars(_companies[i].CreateIterator());
            }
        }

        private void PrintCars(Iterator iterator)
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }
}
