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
using System.Diagnostics;

namespace sort_visualizer
{
    /// <summary>
    /// This partial class <c>MainForm</c> acts as the controller between the sorting model and the UI. 
    /// </summary>
    /// <value>Property <c>sorterModel</c> references the Sorter object that processes the sorting.</value>
    /// <value>Property <c>animationQueue</c> contains the sequence of animations left to be drawn.</value>
    /// <value>Property <c>currentImage</c> represents the current image to be drawn.</value>
    /// <value>Property <c>animationTimer</c> draws from the <c>animationQueue</c> on a set interval.</value>
    public partial class MainForm : Form
    {
        private Sorter sorterModel;
        private Queue<Image> animationQueue;
        private Image currentImage;
        private System.Windows.Forms.Timer animationTimer;
        private object sortLock;
        private bool resettingSort;
        public MainForm()
        {
            InitializeComponent();
            sorterModel = new Sorter();
            sorterModel.ArrayModified += this.OnArrayModified;

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 50;
            animationTimer.Tick += new EventHandler(animationTimerTick);
            animationQueue = new Queue<Image>();
            currentImage = new Bitmap(visualizerPicBox.Width, visualizerPicBox.Height);
            sortLock = new object();
            resettingSort = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int[] array = new int[50];
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                array[i] = rand.Next(400);
            }

            sorterModel.setArray(array);
        }

        /// <summary>
        /// When the array is updated, create a bitmap representation of the array and enqueue the image to <c>animationQueue</c>.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="args">Contains the array to be drawn, and array indexes being compared.</param>
        public void OnArrayModified(object src, ArrayEventArgs args)
        {
            Bitmap bitmap = new Bitmap(visualizerPicBox.Width, visualizerPicBox.Height);
            int[] arrayToDraw = args.array;
            Graphics visualizerGraphics = Graphics.FromImage(bitmap);
            int canvasWidth = bitmap.Width;
            int barWidth = Math.Max(1, canvasWidth / arrayToDraw.Length);

            Pen pen = new Pen(Color.White, barWidth);
            for (int i = 0; i < arrayToDraw.Length; i++)
            {
                if (i == args.currIndex)
                {
                    pen.Color = Color.Red;
                } else if (i == args.checkedIndex)
                {
                    pen.Color = Color.Green;
                } else
                {
                    pen.Color = Color.White;
                }
                visualizerGraphics.DrawLine(pen, i * barWidth, bitmap.Height, i * barWidth, bitmap.Height - arrayToDraw[i]);
            }

            animationQueue.Enqueue(bitmap);
            visualizerGraphics.Dispose();
        }

        /// <summary>
        /// On a timer tick, dequeue from <c>animationQueue</c> and update current image. Redraw <c>visualizerPicBox</c>.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="args">Additional arguments with the event.</param>
        private void animationTimerTick(Object src, EventArgs args)
        {
            if (animationQueue.Count > 0)
            {
                currentImage.Dispose();
                currentImage = animationQueue.Dequeue();
                visualizerPicBox.Refresh();
            }
             
        }

        private void visualizerPicBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics picBoxGraphics = e.Graphics;
            picBoxGraphics.DrawImage(currentImage, new Point(0, 0));
        }

        private async void btnQuickSort_Click(object sender, EventArgs e)
        {
            startNewSort();
            if (!animationTimer.Enabled)
            {
                animationTimer.Start();
            }
            await Task.Run(() =>
            {
                lock (sortLock)
                {
                    sorterModel.quickSort();
                }
            }
            );
        }

        private async void btnInsertionSort_Click(object sender, EventArgs e)
        {
            startNewSort();
            if (!animationTimer.Enabled)
            {
                animationTimer.Start();
            }
            await Task.Run(() =>
            {
                lock (sortLock)
                {
                    sorterModel.insertionSort();
                }
            });
        }

        private void startNewSort()
        {
            if (!resettingSort)
            {
                lock (sortLock)
                {
                    resettingSort = true;
                    while (animationQueue.Count > 0)
                    {
                        animationQueue.Dequeue().Dispose();
                    }
                    sorterModel.resetArray();
                    resettingSort = false;
                }

            }
        }
    }
}
