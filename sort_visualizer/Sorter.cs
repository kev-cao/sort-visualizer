using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_visualizer
{
    public class ArrayEventArgs : EventArgs
    {
        public int[] array { get; }
        public int currIndex { get; }
        public int checkedIndex { get; }

        public ArrayEventArgs(int[] array, int currIndex, int checkedIndex)
        {
            this.array = array;
            this.currIndex = currIndex;
            this.checkedIndex = checkedIndex;
        }
    }

    /// <summary>
    /// The class <c>Sorter</c> takes care of sorting an array and raises an event whenever the array is modified.
    /// </summary>
    /// <value>Property <c>array</c> is the array being sorted.</value>
    /// <value>Property <c>initialArray</c> stored the initial array before it was sorted.</value>
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

        protected virtual void OnArrayModified(int currIndex, int checkedIndex)
        {
            ArrayModified?.Invoke(this, new ArrayEventArgs((int[]) array.Clone(), currIndex, checkedIndex));
        }

        public void generateArray(int size, int min, int max)
        {
            array = new int[size];
            initialArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max + 1);
                initialArray[i] = array[i];
            }
            OnArrayModified(0, 0);
        }

        public void resetArray()
        {
            Console.WriteLine("Resetting...");
            this.array = (int[])this.initialArray.Clone();
            OnArrayModified(0, 0);
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
                    OnArrayModified(j + 1, j);
                }

                array[j + 1] = valueToSort;
            }
            Console.WriteLine("Done");
        }

        public void quickSort()
        {
            quickSortHelper(0, array.Length - 1);
            OnArrayModified(0, 0);
            Console.WriteLine("Done");
        }

        private void quickSortHelper(int start, int end)
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
                    OnArrayModified(pivotIndex, i);
                }
            }

            array[end] = array[lowBoundaryIndex];
            array[lowBoundaryIndex] = pivot;

            return lowBoundaryIndex;
        }
    }
}
