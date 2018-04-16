using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public class StrategyDP : IDesignPattern
    {
        public void Run()
        {
            MaxFinder maxFinder = new MaxFinder();

            SortStrategy bubble = new BubbleSorter();
            SortStrategy insertion = new InsertionSorter();

            List<int> list = new List<int>()
            {
                23,3,4,5,34,223,3,34,23,4,4,2,5,5,2,345,2
            };

            maxFinder.sortStrategy = bubble;
            int max = maxFinder.GetMax<int>(list);
            Console.WriteLine("max found with bubble sort strategy is: " + max);

            maxFinder.sortStrategy = insertion;
            max = maxFinder.GetMax<int>(list);
            Console.WriteLine("max found with insertion sort strategy is: " + max);

        }
    }
}
