using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CarCompanyExampleUsingDotNetIterator
{
    class DealerUsingForeach
    {
        private readonly List<IEnumerable> _companies;

        public DealerUsingForeach(params IEnumerable[] companies)
        {
            _companies = companies.ToList();
        }

        public void PrintCars()
        {
            for (int i = 0; i < _companies.Count; i++)
            {
                PrintCars(_companies[i]);
            }
        }

        private void PrintCars(IEnumerable iterable)
        {
            foreach(var item in iterable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
