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
    /// <value>Property <c>sortLock</c> prevents simultaneous sorting on the same array and keeps the sorting thread-safe.</value>
    /// <value>Property <c>resettingSort</c> prevents threads from resetting the sort after it's already been reset.</value>
    public partial class MainForm : Form
    {
        private Sorter sorterModel;
        private Queue<Image> animationQueue;
        private Image currentImage;
        private System.Windows.Forms.Timer animationTimer;
        private object sortLock;
        private bool resettingSort;
        private int defaultArraySize, defaultRangeMin, defaultRangeMax, maxSize;
        private enum Sorts
        {
            Insertion,
            Quick
        }
        public MainForm()
        {
            InitializeComponent();
            sorterModel = new Sorter();
            sorterModel.ArrayModified += this.OnArrayModified;

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += new EventHandler(animationTimerTick);
            animationQueue = new Queue<Image>();
            currentImage = new Bitmap(picBoxVisualizer.Width, picBoxVisualizer.Height);
            sortLock = new object();
            resettingSort = false;

            defaultArraySize = 50;
            defaultRangeMin = 50;
            defaultRangeMax = 200;
            maxSize = 100;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sorterModel.generateArray(defaultArraySize, defaultRangeMin, defaultRangeMax);
        }

        /// <summary>
        /// When the array is updated, create a bitmap representation of the array and enqueue the image to <c>animationQueue</c>.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="args">Contains the array to be drawn, and array indexes being compared.</param>
        public void OnArrayModified(object src, ArrayEventArgs args)
        {
            Bitmap bitmap = new Bitmap(picBoxVisualizer.Width, picBoxVisualizer.Height);
            int[] arrayToDraw = args.array;
            Graphics visualizerGraphics = Graphics.FromImage(bitmap);
            int canvasWidth = bitmap.Width;
            int barWidth = Math.Max(1, canvasWidth / arrayToDraw.Length);
            int offset = (canvasWidth - arrayToDraw.Length * barWidth) / 2;

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
                visualizerGraphics.DrawLine(pen, offset + i * barWidth, bitmap.Height, offset + i * barWidth, bitmap.Height - arrayToDraw[i]);
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
                picBoxVisualizer.Refresh();
            }
             
        }

        private void picBoxVisualizer_Paint(object sender, PaintEventArgs e)
        {
            Graphics picBoxGraphics = e.Graphics;
            picBoxGraphics.DrawImage(currentImage, new Point(0, 0));
        }

        /// <summary>
        /// Begins sorting with a specified method. First attempts to clear the sort, and if that succeeds, proceeds to begin sorting and places a
        /// lock on <c>sortLock</c>.
        /// </summary>
        /// <param name="sortMethod">The desired sorting method.</param>
        private async void runSort(Sorts sortMethod)
        {
            bool hasResetSort = await Task.Run(() =>
            {
                return resetSort();
            });

            if (hasResetSort)
            {
                if (!animationTimer.Enabled)
                {
                    animationTimer.Start();
                }
                await Task.Run(() =>
                {
                    lock (sortLock)
                    {
                        switch (sortMethod)
                        {
                            case Sorts.Insertion:
                                sorterModel.insertionSort();
                                break;
                            case Sorts.Quick:
                                sorterModel.quickSort();
                                break;
                            default:
                                break; // Should never get here.
                        }
                    }
                });
            }
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            runSort(Sorts.Quick);
        }

        private void btnInsertionSort_Click(object sender, EventArgs e)
        {
            runSort(Sorts.Insertion);
        }

        /// <summary>
        /// Removes all images from <c>animationQueue</c> and resets the array. Will wait for sorting to finish before doing so, and
        /// will stop sorting while it is resetting. Only one reset will be run at a time.
        /// </summary>
        /// <returns>Returns true if successfully reset the array and false otherwise.</returns>
        private bool resetSort()
        {
            // Only reset if there isn't a reset already happening.
            if (!resettingSort)
            {
                resettingSort = true;
                // Wait for sorting to finish before proceeding and block all sort attempts while resetting.
                lock (sortLock)
                {
                    while (animationQueue.Count > 0)
                    {
                        animationQueue.Dequeue().Dispose();
                    }
                    sorterModel.resetArray();
                    resettingSort = false;
                }
                return true;
            } else
            {
                return false;
            }
        }

        private void txtBoxArraySize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSetupArray_Click(object sender, EventArgs e)
        {
            lblArrayError.Visible = false;
            lblRangeError.Visible = false;

            int arraySize = parseInt(txtBoxArraySize.Text);
            int rangeMin = parseInt(txtBoxMin.Text);
            int rangeMax = parseInt(txtBoxMax.Text);

            // If txtBoxArraySize has no contents, set arraySize to default value.
            arraySize = arraySize == -1 ? defaultArraySize : arraySize;

            // If neither of txtBoxMin and txtBoxMax have contents, set them to their default values.
            if (rangeMin == -1 && rangeMax == -1)
            {
                rangeMin = defaultRangeMin;
                rangeMax = defaultRangeMax;
            }

            // Show all needed error messages.
            lblArrayError.Text = "Max Value: " + maxSize;
            lblArrayError.Visible = arraySize > maxSize;
            
            if (rangeMin >= rangeMax)
            {
                lblRangeError.Text = "Min must be less than Max.";
                lblRangeError.Visible = true;
            } else if (rangeMin == -1 ^ rangeMax == -1)
            {
                lblRangeError.Text = "Max Range is 0 - 500.";
                lblRangeError.Visible = true;
            }

            // If any one of the error messages are visible, do not continue.
            if (lblArrayError.Visible || lblRangeError.Visible)
            {
                return;
            }

            // If there are no errors, generate the array. Make sure to let any sorts finish first before generating the array.
            lock (sortLock)
            {
                if (!animationTimer.Enabled)
                {
                    animationTimer.Start();
                }

                sorterModel.generateArray(arraySize, rangeMin, rangeMax);
                resetSort();
            }

        }

        private int parseInt(String s)
        {
            int result;
            if (!Int32.TryParse(s, out result))
            {
                result = -1;
            }
            return result;
        }
    }
}
