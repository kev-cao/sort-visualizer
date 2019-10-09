using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sort_visualizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void visualizerPicBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics visualizerGraphics = e.Graphics;
            Pen pen = new Pen(Color.Green, 10);
            visualizerGraphics.DrawLine(pen, 10, 10, 50, 50);
        }
    }
}
