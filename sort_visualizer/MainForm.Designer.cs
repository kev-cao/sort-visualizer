namespace sort_visualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.visualizerPicBox = new System.Windows.Forms.PictureBox();
            this.btnQuickSort = new System.Windows.Forms.Button();
            this.btnInsertionSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.visualizerPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // visualizerPicBox
            // 
            this.visualizerPicBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this.visualizerPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visualizerPicBox.Location = new System.Drawing.Point(12, 12);
            this.visualizerPicBox.Name = "visualizerPicBox";
            this.visualizerPicBox.Size = new System.Drawing.Size(630, 537);
            this.visualizerPicBox.TabIndex = 0;
            this.visualizerPicBox.TabStop = false;
            this.visualizerPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.visualizerPicBox_Paint);
            // 
            // btnQuickSort
            // 
            this.btnQuickSort.Location = new System.Drawing.Point(650, 12);
            this.btnQuickSort.Name = "btnQuickSort";
            this.btnQuickSort.Size = new System.Drawing.Size(296, 23);
            this.btnQuickSort.TabIndex = 1;
            this.btnQuickSort.Text = "QUICK SORT THE EVER LIVING SHIT OUT OF ME";
            this.btnQuickSort.UseVisualStyleBackColor = true;
            this.btnQuickSort.Click += new System.EventHandler(this.btnQuickSort_Click);
            // 
            // btnInsertionSort
            // 
            this.btnInsertionSort.Location = new System.Drawing.Point(650, 42);
            this.btnInsertionSort.Name = "btnInsertionSort";
            this.btnInsertionSort.Size = new System.Drawing.Size(296, 23);
            this.btnInsertionSort.TabIndex = 2;
            this.btnInsertionSort.Text = "GIMME THAT THICC SLOW INSERTION SORT";
            this.btnInsertionSort.UseVisualStyleBackColor = true;
            this.btnInsertionSort.Click += new System.EventHandler(this.btnInsertionSort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnInsertionSort);
            this.Controls.Add(this.btnQuickSort);
            this.Controls.Add(this.visualizerPicBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizerPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox visualizerPicBox;
        private System.Windows.Forms.Button btnQuickSort;
        private System.Windows.Forms.Button btnInsertionSort;
    }
}

