namespace Lab4_2_MVC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.A_TextBox = new System.Windows.Forms.TextBox();
            this.B_TextBox = new System.Windows.Forms.TextBox();
            this.C_TextBox = new System.Windows.Forms.TextBox();
            this.A_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.B_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.C_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.A_trackBar = new System.Windows.Forms.TrackBar();
            this.B_trackBar = new System.Windows.Forms.TrackBar();
            this.C_trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.A_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(106, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 107);
            this.label1.TabIndex = 0;
            this.label1.Text = "A  <=  B  <=  C";
            // 
            // A_TextBox
            // 
            this.A_TextBox.Location = new System.Drawing.Point(88, 165);
            this.A_TextBox.Name = "A_TextBox";
            this.A_TextBox.Size = new System.Drawing.Size(150, 27);
            this.A_TextBox.TabIndex = 1;
            this.A_TextBox.Tag = "A";
            this.A_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.A_TextBox_KeyDown);
            this.A_TextBox.Leave += new System.EventHandler(this.A_TextBox_Leave);
            // 
            // B_TextBox
            // 
            this.B_TextBox.Location = new System.Drawing.Point(341, 165);
            this.B_TextBox.Name = "B_TextBox";
            this.B_TextBox.Size = new System.Drawing.Size(150, 27);
            this.B_TextBox.TabIndex = 2;
            this.B_TextBox.Tag = "B";
            this.B_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.A_TextBox_KeyDown);
            this.B_TextBox.Leave += new System.EventHandler(this.A_TextBox_Leave);
            // 
            // C_TextBox
            // 
            this.C_TextBox.Location = new System.Drawing.Point(593, 165);
            this.C_TextBox.Name = "C_TextBox";
            this.C_TextBox.Size = new System.Drawing.Size(150, 27);
            this.C_TextBox.TabIndex = 3;
            this.C_TextBox.Tag = "C";
            this.C_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.A_TextBox_KeyDown);
            this.C_TextBox.Leave += new System.EventHandler(this.A_TextBox_Leave);
            // 
            // A_numericUpDown
            // 
            this.A_numericUpDown.Location = new System.Drawing.Point(88, 222);
            this.A_numericUpDown.Name = "A_numericUpDown";
            this.A_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.A_numericUpDown.TabIndex = 4;
            this.A_numericUpDown.Tag = "A";
            this.A_numericUpDown.ValueChanged += new System.EventHandler(this.A_numericUpDown_ValueChanged);
            this.A_numericUpDown.Leave += new System.EventHandler(this.A_numericUpDown_Leave);
            // 
            // B_numericUpDown
            // 
            this.B_numericUpDown.Location = new System.Drawing.Point(341, 222);
            this.B_numericUpDown.Name = "B_numericUpDown";
            this.B_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.B_numericUpDown.TabIndex = 5;
            this.B_numericUpDown.Tag = "B";
            this.B_numericUpDown.ValueChanged += new System.EventHandler(this.A_numericUpDown_ValueChanged);
            this.B_numericUpDown.Leave += new System.EventHandler(this.A_numericUpDown_Leave);
            // 
            // C_numericUpDown
            // 
            this.C_numericUpDown.Location = new System.Drawing.Point(593, 222);
            this.C_numericUpDown.Name = "C_numericUpDown";
            this.C_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.C_numericUpDown.TabIndex = 6;
            this.C_numericUpDown.Tag = "C";
            this.C_numericUpDown.ValueChanged += new System.EventHandler(this.A_numericUpDown_ValueChanged);
            this.C_numericUpDown.Leave += new System.EventHandler(this.A_numericUpDown_Leave);
            // 
            // A_trackBar
            // 
            this.A_trackBar.Location = new System.Drawing.Point(88, 281);
            this.A_trackBar.Maximum = 100;
            this.A_trackBar.Name = "A_trackBar";
            this.A_trackBar.Size = new System.Drawing.Size(150, 56);
            this.A_trackBar.TabIndex = 7;
            this.A_trackBar.Tag = "A";
            this.A_trackBar.Scroll += new System.EventHandler(this.A_trackBar_Scroll);
            // 
            // B_trackBar
            // 
            this.B_trackBar.Location = new System.Drawing.Point(341, 281);
            this.B_trackBar.Maximum = 100;
            this.B_trackBar.Name = "B_trackBar";
            this.B_trackBar.Size = new System.Drawing.Size(150, 56);
            this.B_trackBar.TabIndex = 8;
            this.B_trackBar.Tag = "B";
            this.B_trackBar.Scroll += new System.EventHandler(this.A_trackBar_Scroll);
            // 
            // C_trackBar
            // 
            this.C_trackBar.Location = new System.Drawing.Point(593, 281);
            this.C_trackBar.Maximum = 100;
            this.C_trackBar.Name = "C_trackBar";
            this.C_trackBar.Size = new System.Drawing.Size(150, 56);
            this.C_trackBar.TabIndex = 9;
            this.C_trackBar.Tag = "C";
            this.C_trackBar.Scroll += new System.EventHandler(this.A_trackBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.C_trackBar);
            this.Controls.Add(this.B_trackBar);
            this.Controls.Add(this.A_trackBar);
            this.Controls.Add(this.C_numericUpDown);
            this.Controls.Add(this.B_numericUpDown);
            this.Controls.Add(this.A_numericUpDown);
            this.Controls.Add(this.C_TextBox);
            this.Controls.Add(this.B_TextBox);
            this.Controls.Add(this.A_TextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.A_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox A_TextBox;
        private TextBox B_TextBox;
        private TextBox C_TextBox;
        private NumericUpDown A_numericUpDown;
        private NumericUpDown B_numericUpDown;
        private TrackBar A_trackBar;
        private TrackBar B_trackBar;
        private TrackBar C_trackBar;
        private NumericUpDown C_numericUpDown;
    }
}