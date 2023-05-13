namespace Lab_6_visual_editor
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            закрытьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSplitButton1 = new ToolStripSplitButton();
            IntersectionCheck = new ToolStripMenuItem();
            CtrlCheck = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            сгруппироватьToolStripMenuItem = new ToolStripMenuItem();
            разгруппироватьToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            treeView1 = new TreeView();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripSeparator4, toolStripComboBox1, toolStripSeparator1, toolStripButton1, toolStripSeparator2, toolStripSplitButton1, toolStripSeparator5, toolStripDropDownButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 28);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem, закрытьToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(59, 25);
            toolStripDropDownButton1.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(166, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // закрытьToolStripMenuItem
            // 
            закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            закрытьToolStripMenuItem.Size = new Size(166, 26);
            закрытьToolStripMenuItem.Text = "Очистить";
            закрытьToolStripMenuItem.Click += закрытьToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 28);
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.CausesValidation = false;
            toolStripComboBox1.Items.AddRange(new object[] { "Circle", "Square", "Triangle", "Ellipse", "Pentagon" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(140, 28);
            toolStripComboBox1.Text = "Выберите фигуру";
            toolStripComboBox1.Leave += toolStripComboBox1_TextChanged;
            toolStripComboBox1.TextChanged += toolStripComboBox1_TextChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.ForeColor = SystemColors.ButtonFace;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(123, 25);
            toolStripButton1.Text = "Выбор цвета";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.BackColor = SystemColors.ActiveBorder;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { IntersectionCheck, CtrlCheck });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(187, 25);
            toolStripSplitButton1.Text = "Параметры выбора";
            // 
            // IntersectionCheck
            // 
            IntersectionCheck.CheckOnClick = true;
            IntersectionCheck.Name = "IntersectionCheck";
            IntersectionCheck.Size = new Size(380, 26);
            IntersectionCheck.Text = "выделение всех объектов в пересечении";
            // 
            // CtrlCheck
            // 
            CtrlCheck.CheckOnClick = true;
            CtrlCheck.Name = "CtrlCheck";
            CtrlCheck.Size = new Size(380, 26);
            CtrlCheck.Text = "выбор нескольких элеметов";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 28);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.ContextMenuStrip = contextMenuStrip1;
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            splitContainer1.Panel1.MouseClick += splitContainer1_Panel1_MouseClick;
            splitContainer1.Panel1.MouseDown += splitContainer1_Panel1_MouseDown;
            splitContainer1.Panel1.MouseMove += splitContainer1_Panel1_MouseMove;
            splitContainer1.Panel1.MouseUp += splitContainer1_Panel1_MouseUp;
            splitContainer1.Panel1.PreviewKeyDown += splitContainer1_Panel1_PreviewKeyDown;
            splitContainer1.Panel1.Resize += splitContainer1_Panel1_Resize;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(800, 422);
            splitContainer1.SplitterDistance = 529;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 1;
            splitContainer1.KeyPress += splitContainer1_KeyPress;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator3, сгруппироватьToolStripMenuItem, разгруппироватьToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(200, 82);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(199, 24);
            toolStripMenuItem1.Text = "изменить цвет";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(196, 6);
            // 
            // сгруппироватьToolStripMenuItem
            // 
            сгруппироватьToolStripMenuItem.Name = "сгруппироватьToolStripMenuItem";
            сгруппироватьToolStripMenuItem.Size = new Size(199, 24);
            сгруппироватьToolStripMenuItem.Text = "сгруппировать";
            сгруппироватьToolStripMenuItem.Click += сгруппироватьToolStripMenuItem_Click;
            // 
            // разгруппироватьToolStripMenuItem
            // 
            разгруппироватьToolStripMenuItem.Name = "разгруппироватьToolStripMenuItem";
            разгруппироватьToolStripMenuItem.Size = new Size(199, 24);
            разгруппироватьToolStripMenuItem.Text = "разгруппировать";
            разгруппироватьToolStripMenuItem.Click += разгруппироватьToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeView1);
            panel1.Location = new Point(17, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(241, 359);
            panel1.TabIndex = 1;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 26);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(222, 263);
            treeView1.TabIndex = 0;
            treeView1.BeforeSelect += treeView1_BeforeSelect;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(138, 25);
            toolStripDropDownButton2.Text = "История команд";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 28);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            KeyPreview = true;
            MinimumSize = new Size(700, 400);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private ToolStrip toolStrip1;
        private ColorDialog colordDialog1;
        private ToolStripButton toolStripButton1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem IntersectionCheck;
        private ToolStripMenuItem CtrlCheck;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private SplitContainer splitContainer1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem сгруппироватьToolStripMenuItem;
        private ToolStripMenuItem разгруппироватьToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
        private Panel panel1;
        private TreeView treeView1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripDropDownButton toolStripDropDownButton2;
    }
}