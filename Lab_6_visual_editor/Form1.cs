using Lab_6_visual_editor.Storage;
using System.Windows.Forms;

namespace Lab_6_visual_editor
{
    public partial class Form1 : Form
    {
        internal Storage<Figure> figures;
        //internal 
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
            CIterator<Figure> i = figures.CreateIterator();
            for(i.First(); !i.IsEol(); i.Next())
            {
                if(i.GetCurrent().CheckSelection(e.X, e.Y))
                {
                    i.GetCurrent().Select();
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
            CIterator<Figure> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().CheckSelection(e.X, e.Y))
                {
                    i.GetCurrent().Select();
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
                CIterator<Figure> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        figures.Remove(i.GetCurrent());

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
                CIterator<Figure> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        i.GetCurrent().Move(com);

                    }
                }
           }
           else if (com == '+' || com == '-')
            {
                CIterator<Figure> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        i.GetCurrent().ScaleChange(com);

                    }
                }
            }
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                CIterator<Figure> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        figures.Remove(i.GetCurrent());

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
                    CIterator<Figure> i = figures.CreateIterator();
                    for (i.First(); !i.IsEol(); i.Next())
                    {
                        i.GetCurrent().Deselect();
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
            CIterator<Figure> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                i.GetCurrent().Draw(e);
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
            Color oldColor = colordDialog1.Color;
            if (colordDialog1.ShowDialog() == DialogResult.OK)
            {
               // colordDialog1.Color = colordDialog1.Color;
            }
            CIterator<Figure> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    i.GetCurrent().ColorChange(colordDialog1.Color);

                }
            }
            colordDialog1.Color = oldColor;
            splitContainer1.Panel1.Refresh();
        }
    }
}