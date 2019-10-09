using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_visualizer
{
    class ArrayEventArgs : EventArgs
    {
        private int[] array { get; set; }

        public ArrayEventArgs(int[] array)
        {
            this.array = array;
        }
    }

    class Sorter
    {
        private int[] array
        {
            get
            {
                return array;
            }
            set
            {
                array = value;
                initialArray = value;
            }
        }

        private int[] initialArray { get; set; }

        public delegate void ArrayModifiedEventHandler(Object src, ArrayEventArgs array);
        public event ArrayModifiedEventHandler ArrayModified;

        public Sorter()
        {
        }

        protected virtual void onArrayModified(Object src, EventArgs args)
        {
            ArrayModified?.Invoke(this, new ArrayEventArgs(array));
        }
    }
}
