using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_visualizer
{
    public class ArrayEventArgs : EventArgs
    {
        public int[] array { get; }

        public ArrayEventArgs(int[] array)
        {
            this.array = array;
        }
    }

    class Sorter
    {
        private int[] array;
        private int[] initialArray;
        private static Random rand = new Random();

        public delegate void ArrayModifiedEventHandler(object src, ArrayEventArgs array);
        public event ArrayModifiedEventHandler ArrayModified;

        public Sorter()
        {
        }

        protected virtual void OnArrayModified()
        {
            ArrayModified?.Invoke(this, new ArrayEventArgs(array));
        }

        public void setArray(int[] array)
        {
            this.array = array;
            this.initialArray = array;
            OnArrayModified();
        }

        public void insertionSort()
        {
            for (int i = 0; i < array.Length; i++)
            {
                int valueToSort = array[i];
                int j = i - 1;

                while (j >= 0 && valueToSort < array[j])
                {
                    array[j + 1] = array[j--];
                    OnArrayModified();
                }

                array[j + 1] = valueToSort;
            }
        }

        public void quickSort()
        {
            quickSortHelper(0, array.Length - 1);
            OnArrayModified();
        }

        public void quickSortHelper(int start, int end)
        {
            if (start < end)
            {
                int pivot = partition(start, end);

                quickSortHelper(start, pivot - 1);
                quickSortHelper(pivot + 1, end);
            }
        }

        private int chooseCentralZonePivot(int start, int end)
        {
            int pivotIndex;
            int rankOfPivot;
            int count = 0;
            do
            {
                rankOfPivot = 0;
                pivotIndex = rand.Next(start, end + 1);
                count++;
                for (int i = start; i <= end; i++)
                {
                    if (array[i] < array[pivotIndex])
                    {
                        rankOfPivot++;
                    }
                }
            } while (count <= 5 && (rankOfPivot < Math.Floor((end - start) / 4.0) || rankOfPivot > Math.Ceiling(3 * (end - start) / 4.0)));

            return pivotIndex;
        }

        private int partition(int start, int end)
        {
            int pivotIndex = chooseCentralZonePivot(start, end);

            int pivot = array[pivotIndex];
            array[pivotIndex] = array[end];
            array[end] = pivot;

            int lowBoundaryIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] <= pivot)
                {
                    int tmp = array[lowBoundaryIndex];
                    array[lowBoundaryIndex] = array[i];
                    array[i] = tmp;
                    lowBoundaryIndex++;
                    OnArrayModified();
                }
            }

            array[end] = array[lowBoundaryIndex];
            array[lowBoundaryIndex] = pivot;

            return lowBoundaryIndex;
        }
    }
}
