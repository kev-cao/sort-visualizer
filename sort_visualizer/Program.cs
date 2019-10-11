using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sort_visualizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            /*
            Sorter model = new Sorter();
            int[] array = new int[100];
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                array[i] = rand.Next(200);
            }

            model.array = array;
            model.insertionSort();

            for (int i = 0; i < 100; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            */
        }
    }
}
