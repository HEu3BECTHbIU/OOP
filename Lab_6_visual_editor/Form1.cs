using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lab_6_visual_editor
{
    public partial class Form1 : Form
    {
        internal Storage<Figure> figures;
        internal MyFactory factory;
        public Form1()
        {
            InitializeComponent();

            figures = new Storage<Figure>();
            colordDialog1 = new ColorDialog();
            factory = new MyFactory();
            Figure.UpdateBorder(splitContainer1.Panel1.Right, splitContainer1.Panel1.Bottom);
            colordDialog1.Color = Color.Aquamarine;

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            colordDialog1.FullOpen = false;

            if (colordDialog1.ShowDialog() == DialogResult.OK)
            {
                // установка цвета формы
                toolStripButton1.BackColor = colordDialog1.Color;
            }
        }
        private void MouseClickWithIntersection(object sender, MouseEventArgs e)
        {
            bool flag = false;
            for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
            {
                if (i.Value.CheckSelection(e.X, e.Y))
                {
                    i.Value.Select();
                    flag = true;
                }
            }
            if (!flag)
            {
                Figure figure = factory.CreateFigure(toolStripComboBox1.Text, colordDialog1.Color, true, e.X, e.Y, 40, 25);
                figures.PushBack(figure);
            }
        }
        private void MouseClickNoIntersection(object sender, MouseEventArgs e)
        {
            bool flag = false;
            for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
            {
                if (i.Value.CheckSelection(e.X, e.Y))
                {
                    i.Value.Select();
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Figure figure = factory.CreateFigure(toolStripComboBox1.Text, colordDialog1.Color, true, e.X, e.Y);
                figures.PushBack(figure);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
                {
                    if (i.Value.IsSelected)
                    {
                        figures.Remove(i.Value);

                    }
                }
            }
            splitContainer1.Panel1.Refresh();
        }


        private void splitContainer1_KeyPress(object sender, KeyPressEventArgs e)
        {
           // MessageBox.Show(e.KeyChar.ToString());
           char com = e.KeyChar;
           if (com == 'w' || com == 's' || com == 'a' || com == 'd')
           {
                for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
                {
                    if (i.Value.IsSelected)
                    {
                        i.Value.Move(com);
                    }
                }
            }
           else if (com == '+' || com == '-')
            {
                for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
                {
                    if (i.Value.IsSelected)
                    {
                        i.Value.ScaleChange(com);
                    }
                }
            }
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
                {
                    if (i.Value.IsSelected)
                    {
                        figures.Remove(i.Value);
                    }
                }
                if (figures.Count != 0)
                {
                    figures.Tail.Value.Select();
                }
            }
            splitContainer1.Panel1.Refresh();
        }

        private void splitContainer1_Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            {
                if (CtrlCheck.Checked && Control.ModifierKeys == Keys.Control)
                {

                }
                else
                {
                    for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
                    {
                        i.Value.Deselect();
                    }
                }
                if (IntersectionCheck.Checked)
                {
                    MouseClickWithIntersection(sender, e);
                }
                else
                {
                    MouseClickNoIntersection(sender, e);
                }
                splitContainer1.Panel1.Refresh();
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
            {
                i.Value.Draw(e);
            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            splitContainer1.Select();
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            Figure.UpdateBorder(splitContainer1.Panel1.Right, splitContainer1.Panel1.Bottom);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colordDialog1.FullOpen = false;
            if (colordDialog1.ShowDialog() == DialogResult.OK)
            {
                colordDialog1.Color = colordDialog1.Color;
            }
            for (Node<Figure>? i = figures.Head; figures.Exists(i); i = i.Next)
            {
                if (i.Value.IsSelected)
                {
                    i.Value.ColorChange(colordDialog1.Color);
                }
            }
            splitContainer1.Panel1.Refresh();
        }
    }
}