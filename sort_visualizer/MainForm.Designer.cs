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
            this.picBoxVisualizer = new System.Windows.Forms.PictureBox();
            this.btnQuickSort = new System.Windows.Forms.Button();
            this.btnInsertionSort = new System.Windows.Forms.Button();
            this.grpBoxSortingAlgos = new System.Windows.Forms.GroupBox();
            this.grpBoxArraySetup = new System.Windows.Forms.GroupBox();
            this.lblRangeError = new System.Windows.Forms.Label();
            this.lblArrayError = new System.Windows.Forms.Label();
            this.btnSetupArray = new System.Windows.Forms.Button();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtBoxMax = new System.Windows.Forms.TextBox();
            this.txtBoxMin = new System.Windows.Forms.TextBox();
            this.lblArrayRange = new System.Windows.Forms.Label();
            this.lblArraySize = new System.Windows.Forms.Label();
            this.txtBoxArraySize = new System.Windows.Forms.TextBox();
            this.lblAnimationSpeed = new System.Windows.Forms.Label();
            this.tkBarAnimationSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVisualizer)).BeginInit();
            this.grpBoxSortingAlgos.SuspendLayout();
            this.grpBoxArraySetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBarAnimationSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxVisualizer
            // 
            this.picBoxVisualizer.BackColor = System.Drawing.Color.LightSkyBlue;
            this.picBoxVisualizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxVisualizer.Location = new System.Drawing.Point(12, 12);
            this.picBoxVisualizer.Name = "picBoxVisualizer";
            this.picBoxVisualizer.Size = new System.Drawing.Size(600, 500);
            this.picBoxVisualizer.TabIndex = 0;
            this.picBoxVisualizer.TabStop = false;
            this.picBoxVisualizer.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxVisualizer_Paint);
            // 
            // btnQuickSort
            // 
            this.btnQuickSort.Location = new System.Drawing.Point(6, 19);
            this.btnQuickSort.Name = "btnQuickSort";
            this.btnQuickSort.Size = new System.Drawing.Size(139, 23);
            this.btnQuickSort.TabIndex = 4;
            this.btnQuickSort.Text = "Quick Sort Me!";
            this.btnQuickSort.UseVisualStyleBackColor = true;
            this.btnQuickSort.Click += new System.EventHandler(this.btnQuickSort_Click);
            // 
            // btnInsertionSort
            // 
            this.btnInsertionSort.Location = new System.Drawing.Point(6, 48);
            this.btnInsertionSort.Name = "btnInsertionSort";
            this.btnInsertionSort.Size = new System.Drawing.Size(139, 23);
            this.btnInsertionSort.TabIndex = 5;
            this.btnInsertionSort.Text = "Insertion Sort Me!";
            this.btnInsertionSort.UseVisualStyleBackColor = true;
            this.btnInsertionSort.Click += new System.EventHandler(this.btnInsertionSort_Click);
            // 
            // grpBoxSortingAlgos
            // 
            this.grpBoxSortingAlgos.Controls.Add(this.btnQuickSort);
            this.grpBoxSortingAlgos.Controls.Add(this.btnInsertionSort);
            this.grpBoxSortingAlgos.Location = new System.Drawing.Point(618, 141);
            this.grpBoxSortingAlgos.Name = "grpBoxSortingAlgos";
            this.grpBoxSortingAlgos.Size = new System.Drawing.Size(324, 371);
            this.grpBoxSortingAlgos.TabIndex = 2;
            this.grpBoxSortingAlgos.TabStop = false;
            this.grpBoxSortingAlgos.Text = "Sorting Algorithms";
            // 
            // grpBoxArraySetup
            // 
            this.grpBoxArraySetup.Controls.Add(this.tkBarAnimationSpeed);
            this.grpBoxArraySetup.Controls.Add(this.lblAnimationSpeed);
            this.grpBoxArraySetup.Controls.Add(this.lblRangeError);
            this.grpBoxArraySetup.Controls.Add(this.lblArrayError);
            this.grpBoxArraySetup.Controls.Add(this.btnSetupArray);
            this.grpBoxArraySetup.Controls.Add(this.lblMax);
            this.grpBoxArraySetup.Controls.Add(this.lblMin);
            this.grpBoxArraySetup.Controls.Add(this.txtBoxMax);
            this.grpBoxArraySetup.Controls.Add(this.txtBoxMin);
            this.grpBoxArraySetup.Controls.Add(this.lblArrayRange);
            this.grpBoxArraySetup.Controls.Add(this.lblArraySize);
            this.grpBoxArraySetup.Controls.Add(this.txtBoxArraySize);
            this.grpBoxArraySetup.Location = new System.Drawing.Point(618, 12);
            this.grpBoxArraySetup.Name = "grpBoxArraySetup";
            this.grpBoxArraySetup.Size = new System.Drawing.Size(324, 123);
            this.grpBoxArraySetup.TabIndex = 1;
            this.grpBoxArraySetup.TabStop = false;
            this.grpBoxArraySetup.Text = "Parameters";
            // 
            // lblRangeError
            // 
            this.lblRangeError.AutoSize = true;
            this.lblRangeError.ForeColor = System.Drawing.Color.Red;
            this.lblRangeError.Location = new System.Drawing.Point(65, 94);
            this.lblRangeError.Name = "lblRangeError";
            this.lblRangeError.Size = new System.Drawing.Size(65, 13);
            this.lblRangeError.TabIndex = 9;
            this.lblRangeError.Text = "Max Range:";
            this.lblRangeError.Visible = false;
            // 
            // lblArrayError
            // 
            this.lblArrayError.AutoSize = true;
            this.lblArrayError.ForeColor = System.Drawing.Color.Red;
            this.lblArrayError.Location = new System.Drawing.Point(63, 41);
            this.lblArrayError.Name = "lblArrayError";
            this.lblArrayError.Size = new System.Drawing.Size(63, 13);
            this.lblArrayError.TabIndex = 8;
            this.lblArrayError.Text = "Max Value: ";
            this.lblArrayError.Visible = false;
            // 
            // btnSetupArray
            // 
            this.btnSetupArray.Location = new System.Drawing.Point(193, 80);
            this.btnSetupArray.Name = "btnSetupArray";
            this.btnSetupArray.Size = new System.Drawing.Size(104, 27);
            this.btnSetupArray.TabIndex = 4;
            this.btnSetupArray.Text = "Initialize Array";
            this.btnSetupArray.UseVisualStyleBackColor = true;
            this.btnSetupArray.Click += new System.EventHandler(this.btnSetupArray_Click);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(121, 55);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(27, 13);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(63, 55);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 13);
            this.lblMin.TabIndex = 5;
            this.lblMin.Text = "Min";
            // 
            // txtBoxMax
            // 
            this.txtBoxMax.Location = new System.Drawing.Point(124, 71);
            this.txtBoxMax.Name = "txtBoxMax";
            this.txtBoxMax.Size = new System.Drawing.Size(42, 20);
            this.txtBoxMax.TabIndex = 2;
            this.txtBoxMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxMax_KeyPress);
            // 
            // txtBoxMin
            // 
            this.txtBoxMin.Location = new System.Drawing.Point(66, 71);
            this.txtBoxMin.Name = "txtBoxMin";
            this.txtBoxMin.Size = new System.Drawing.Size(42, 20);
            this.txtBoxMin.TabIndex = 1;
            this.txtBoxMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxMin_KeyPress);
            // 
            // lblArrayRange
            // 
            this.lblArrayRange.AutoSize = true;
            this.lblArrayRange.Location = new System.Drawing.Point(21, 74);
            this.lblArrayRange.Name = "lblArrayRange";
            this.lblArrayRange.Size = new System.Drawing.Size(39, 13);
            this.lblArrayRange.TabIndex = 2;
            this.lblArrayRange.Text = "Range";
            // 
            // lblArraySize
            // 
            this.lblArraySize.AutoSize = true;
            this.lblArraySize.Location = new System.Drawing.Point(6, 23);
            this.lblArraySize.Name = "lblArraySize";
            this.lblArraySize.Size = new System.Drawing.Size(54, 13);
            this.lblArraySize.TabIndex = 1;
            this.lblArraySize.Text = "Array Size";
            // 
            // txtBoxArraySize
            // 
            this.txtBoxArraySize.Location = new System.Drawing.Point(66, 20);
            this.txtBoxArraySize.MaxLength = 4;
            this.txtBoxArraySize.Name = "txtBoxArraySize";
            this.txtBoxArraySize.Size = new System.Drawing.Size(42, 20);
            this.txtBoxArraySize.TabIndex = 0;
            this.txtBoxArraySize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxArraySize_KeyPress);
            // 
            // lblAnimationSpeed
            // 
            this.lblAnimationSpeed.AutoSize = true;
            this.lblAnimationSpeed.Location = new System.Drawing.Point(201, 16);
            this.lblAnimationSpeed.Name = "lblAnimationSpeed";
            this.lblAnimationSpeed.Size = new System.Drawing.Size(87, 13);
            this.lblAnimationSpeed.TabIndex = 10;
            this.lblAnimationSpeed.Text = "Animation Speed";
            // 
            // tkBarAnimationSpeed
            // 
            this.tkBarAnimationSpeed.LargeChange = 4;
            this.tkBarAnimationSpeed.Location = new System.Drawing.Point(193, 29);
            this.tkBarAnimationSpeed.Maximum = 20;
            this.tkBarAnimationSpeed.Minimum = 1;
            this.tkBarAnimationSpeed.Name = "tkBarAnimationSpeed";
            this.tkBarAnimationSpeed.Size = new System.Drawing.Size(104, 45);
            this.tkBarAnimationSpeed.TabIndex = 3;
            this.tkBarAnimationSpeed.Value = 10;
            this.tkBarAnimationSpeed.Scroll += new System.EventHandler(this.tkBarAnimationSpeed_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 521);
            this.Controls.Add(this.grpBoxArraySetup);
            this.Controls.Add(this.grpBoxSortingAlgos);
            this.Controls.Add(this.picBoxVisualizer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Sort Visualizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVisualizer)).EndInit();
            this.grpBoxSortingAlgos.ResumeLayout(false);
            this.grpBoxArraySetup.ResumeLayout(false);
            this.grpBoxArraySetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBarAnimationSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxVisualizer;
        private System.Windows.Forms.Button btnQuickSort;
        private System.Windows.Forms.Button btnInsertionSort;
        private System.Windows.Forms.GroupBox grpBoxSortingAlgos;
        private System.Windows.Forms.GroupBox grpBoxArraySetup;
        private System.Windows.Forms.Label lblArraySize;
        private System.Windows.Forms.TextBox txtBoxArraySize;
        private System.Windows.Forms.Button btnSetupArray;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtBoxMax;
        private System.Windows.Forms.TextBox txtBoxMin;
        private System.Windows.Forms.Label lblArrayRange;
        private System.Windows.Forms.Label lblRangeError;
        private System.Windows.Forms.Label lblArrayError;
        private System.Windows.Forms.TrackBar tkBarAnimationSpeed;
        private System.Windows.Forms.Label lblAnimationSpeed;
    }
}

