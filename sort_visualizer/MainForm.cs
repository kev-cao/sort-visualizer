using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace sort_visualizer
{
    public partial class MainForm : Form
    {
        private Sorter sorterModel;
        private Bitmap bitmapBuffer;
        private readonly SynchronizationContext syncContext;
        private readonly object locker;
        public MainForm()
        {
            InitializeComponent();
            sorterModel = new Sorter();
            syncContext = SynchronizationContext.Current;
            sorterModel.ArrayModified += this.OnArrayModified;
            bitmapBuffer = new Bitmap(visualizerPicBox.Width, visualizerPicBox.Height);
            locker = new object();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int[] array = new int[500];
            Random rand = new Random();
            for (int i = 0; i < 500; i++)
            {
                array[i] = rand.Next(400);
            }

            sorterModel.setArray(array);
        }

        public async void OnArrayModified(object src, ArrayEventArgs args)
        {
            await Task.Run(() =>
            {
                lock (locker)
                {
                    Bitmap bitmapClone = new Bitmap(bitmapBuffer.Width, bitmapBuffer.Height);
                    int[] arrayToDraw = args.array;
                    Graphics visualizerGraphics = Graphics.FromImage(bitmapClone);
                    int canvasWidth = bitmapClone.Width;
                    int barWidth = Math.Max(1, arrayToDraw.Length / canvasWidth);

                    Pen pen = new Pen(Color.Green, barWidth);
                    for (int i = 0; i < arrayToDraw.Length; i++)
                    {
                        visualizerGraphics.DrawLine(pen, i * barWidth, bitmapClone.Height, (i + 1) * barWidth, bitmapClone.Height - arrayToDraw[i]);
                    }
                    visualizerGraphics.Dispose();
                    bitmapBuffer = bitmapClone;
                }
            });

            syncContext.Post(new SendOrPostCallback(o =>
            {
                visualizerPicBox.Refresh();
            }), null);
        }

        private void visualizerPicBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics picBoxGraphics = e.Graphics;
            picBoxGraphics.DrawImage(bitmapBuffer, new Point(30, 40));
        }

        private async void btnQuickSort_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                sorterModel.quickSort();
            }
            );
        }
    }
}
