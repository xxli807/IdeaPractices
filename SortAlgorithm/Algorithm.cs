using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public class Algorithm
    {
        public int[] unSortedArray = new int[] { 49, 28, 65, 97, 76, 13, 27, 49 };

        public void Print(int[] unSortedArray)
        {
            var length = unSortedArray.Count();
            for(var i= 0; i < length; i++)
            {
                Console.WriteLine(unSortedArray[i]);
            }
        }

        public void InsertSort()
        {

            Console.WriteLine("insert sort");

            var length = unSortedArray.Count();

            for(var i = 1; i < length; i++)
            {
                var temp = unSortedArray[i];
                for(int j = i-1; j>=0; j--)
                {
                    if (unSortedArray[j] > temp)
                    {
                        unSortedArray[j + 1] = unSortedArray[j];
                        if(j == 0)
                        {
                            unSortedArray[0] = temp;
                            break;
                        }
                    }
                    else
                    {
                        unSortedArray[j + 1] = temp;
                        break;
                    }
                }
            }

            Print(unSortedArray);
        }


        public void QuickSort()
        {
            Console.WriteLine("quick sort");

            QuickSortStrict(unSortedArray, 0, unSortedArray.Length - 1);

            Print(unSortedArray);
        }

        private void QuickSortStrict(int[] data, int low, int high)
        {
            if (low >= high) return;
            int temp = data[(low + high) / 2];
            int i = low - 1, j = high + 1;
            while (true)
            {
                while (data[++i] < temp) ;
                while (data[--j] > temp) ;
                if (i >= j) break;
                Swap(data, i, j);
            }
            QuickSortStrict(data, j + 1, high);
            QuickSortStrict(data, low, i - 1);
        }

        private void Swap(int[] data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
         
    }
}
