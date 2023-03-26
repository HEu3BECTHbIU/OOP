namespace Circles
{
    partial class Form1
    {
        Storage<Circle> circles = new Storage<Circle>();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrl_check = new System.Windows.Forms.CheckBox();
            this.Intersection_check = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(504, 437);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // ctrl_check
            // 
            this.ctrl_check.AutoSize = true;
            this.ctrl_check.Location = new System.Drawing.Point(582, 56);
            this.ctrl_check.Name = "ctrl_check";
            this.ctrl_check.Size = new System.Drawing.Size(183, 24);
            this.ctrl_check.TabIndex = 1;
            this.ctrl_check.Text = "клавиша ctrl работает";
            this.ctrl_check.UseVisualStyleBackColor = true;
            this.ctrl_check.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            // 
            // Intersection_check
            // 
            this.Intersection_check.AutoSize = true;
            this.Intersection_check.Location = new System.Drawing.Point(581, 101);
            this.Intersection_check.Name = "Intersection_check";
            this.Intersection_check.Size = new System.Drawing.Size(217, 44);
            this.Intersection_check.TabIndex = 2;
            this.Intersection_check.Text = "выделяются все\r\nобъекты при пересечении\r\n";
            this.Intersection_check.UseVisualStyleBackColor = true;
            this.Intersection_check.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Intersection_check);
            this.Controls.Add(this.ctrl_check);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox ctrl_check;
        private CheckBox Intersection_check;
    }
}