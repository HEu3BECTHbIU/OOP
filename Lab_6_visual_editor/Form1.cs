using Lab_6_visual_editor.Commands;
using Lab_6_visual_editor.Figures;
using Lab_6_visual_editor.Storage;
using System.Configuration;
using System.Windows.Forms;

namespace Lab_6_visual_editor
{
    public partial class Form1 : Form
    {
        internal Storage<Element> figures;
        //internal 
        internal MyFactory factory;

        Dictionary<char, Command> commands;
        public Form1()
        {
            InitializeComponent();
            figures = new Storage<Element>();
            commands = new Dictionary<char, Command>();
            commands['a'] = new MoveCommand(-10, 0);
            commands['d'] = new MoveCommand(10, 0);
            commands['w'] = new MoveCommand(0, -10);
            commands['s'] = new MoveCommand(0, 10);

            commands['-'] = new ScaleCommand(0.8f);
            commands['+'] = new ScaleCommand(1.25f);

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
                // óñòàíîâêà öâåòà ôîðìû
                toolStripButton1.BackColor = colordDialog1.Color;
            }
        }
        private void MouseClickWithIntersection(object sender, MouseEventArgs e)
        {
            bool flag = false;
            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().CheckSelection(e.X, e.Y))
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
            CIterator<Element> i = figures.CreateIterator();
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
                Element figure = factory.CreateFigure(toolStripComboBox1.Text, colordDialog1.Color, true, e.X, e.Y);
                figures.PushBack(figure);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                CIterator<Element> i = figures.CreateIterator();
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
            Command current = null;
            if (commands.ContainsKey(com))
            {
                current = commands[com];
            }
            if (current != null)
            {
                CIterator<Element> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        current.Execute(i.GetCurrent());
                        if (i.GetCurrent().IsOnEdge())
                        {
                            current.Unexecute();
                        }
                        // i.GetCurrent().Move(com);
                        // char edge = i.GetCurrent().WhatEdge();
                        // i.GetCurrent().Correct(edge);

                    }
                }
            }
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                CIterator<Element> i = figures.CreateIterator();
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
                    CIterator<Element> i = figures.CreateIterator();
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
            CIterator<Element> i = figures.CreateIterator();
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
            Element.UpdateBorder(splitContainer1.Panel1.Right, splitContainer1.Panel1.Bottom);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colordDialog1.FullOpen = false;
            Color oldColor = colordDialog1.Color;
            if (colordDialog1.ShowDialog() == DialogResult.OK)
            {
                // colordDialog1.Color = colordDialog1.Color;
            }
            CIterator<Element> i = figures.CreateIterator();
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

        private void ñãðóïïèðîâàòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CIterator<Element> i = figures.CreateIterator();
            CGroup new_group = new CGroup(true);
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    new_group.AddFigure(i.GetCurrent());
                }
            }

            i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    figures.Remove(i.GetCurrent());
                }
            }
            figures.PushBack(new_group);
            splitContainer1.Panel1.Refresh();
        }

        private void ðàçãðóïïèðîâàòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Storage<Element> group_elements = new Storage<Element>();

            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected && i.GetCurrent() is CGroup)
                {

                    (i.GetCurrent() as CGroup).Decompose(group_elements);
                    figures.Remove(i.GetCurrent());
                }
            }
            //i = figures.CreateIterator();
            //for (i.First(); !i.IsEol(); i.Next())
            //{
            //    if (i.GetCurrent().IsSelected)
            //    {
            //        figures.Remove(i.GetCurrent());
            //    }
           // }

            i = group_elements.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                figures.PushBack(i.GetCurrent());
            }
            splitContainer1.Panel1.Refresh();
        }
    }
}