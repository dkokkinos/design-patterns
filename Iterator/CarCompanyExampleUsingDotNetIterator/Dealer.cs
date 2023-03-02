using Iterator.CarCompanyExample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExampleUsingDotNetIterator
{
    public class Dealer
    {
        private readonly List<IEnumerable> _companies;

        public Dealer(params IEnumerable[] companies)
        {
            _companies = companies.ToList();
        }

        public void PrintCars()
        {
            for (int i = 0; i < _companies.Count; i++)
            {
                PrintCars(_companies[i].GetEnumerator());
            }
        }

        private void PrintCars(IEnumerator iterator)
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }
}
