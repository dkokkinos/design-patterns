using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class BubbleSorter : SortStrategy
    {
        public override void Sort<T>(IList<T> collection, Comparer<T> comparer = null)
        {
            this.BubbleSort(collection, comparer);
        }

        public void BubbleSort<T>(IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            BubbleSortAscending(collection, comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public void BubbleSortAscending<T>(IList<T> collection, Comparer<T> comparer)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int index = 0; index < collection.Count - 1; index++)
                {
                    if (comparer.Compare(collection[index], collection[index + 1]) > 0)
                    {
                        Swap(collection, index, index + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public void BubbleSortDescending<T>(IList<T> collection, Comparer<T> comparer)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int index = 1; index < collection.Count - i; index++)
                {
                    if (comparer.Compare(collection[index], collection[index - 1]) > 0)
                    {
                        Swap(collection, index - 1, index);
                    }
                }
            }
        }

        public void Swap<T>(IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)   //This check is not required but Partition function may make many calls so its for perf reason
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }


    }
}
