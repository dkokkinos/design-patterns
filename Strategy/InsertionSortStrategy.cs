using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class InsertionSorter : SortStrategy
    {
        public override void Sort<T>(IList<T> collection, Comparer<T> comparer = null)
        {
            this.InsertionSort(collection, comparer);
        }

        // The quick insertion sort algorithm.
        // For any collection that implements the IList interface.
        public void InsertionSort<T>(IList<T> list, Comparer<T> comparer = null)
        {
            //
            // If the comparer is Null, then initialize it using a default typed comparer
            comparer = comparer ?? Comparer<T>.Default;

            // Do sorting if list is not empty.
            int i, j;
            for (i = 1; i < list.Count; i++)
            {
                T value = list[i];
                j = i - 1;

                while ((j >= 0) && (comparer.Compare(list[j], value) > 0))
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = value;
            }
        }
        
    }
}
