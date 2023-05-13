using Lab_6_visual_editor.Commands;
using Lab_6_visual_editor.Figures;
using Lab_6_visual_editor.Storage;
using System.Windows.Forms;
// using System.Xml;

namespace Lab_6_visual_editor
{
    public partial class Form1 : Form
    {
        internal ShapeStorage figures;
        //internal 
        internal MyFactory factory;
        TreeHandler treeHandler;
        Dictionary<Keys, Command> commands;
        // Dictionary<char, StorageCommand> storageCommands;
        Stack<Command> history;

        public Form1()
        {
            InitializeComponent();
            history = new Stack<Command>();
            figures = new ShapeStorage();
            treeHandler = new TreeHandler(treeView1);

            figures.AddObserver(treeHandler);

            treeHandler.AddObserver(figures);
            // storageCommands = new Dictionary<char, StorageCommand>();

            commands = new Dictionary<Keys, Command>();
            commands[Keys.A] = new MoveCommand(-10, 0);
            commands[Keys.D] = new MoveCommand(10, 0);
            commands[Keys.W] = new MoveCommand(0, -10);
            commands[Keys.S] = new MoveCommand(0, 10);

            commands[Keys.OemMinus] = new ScaleCommand(0.8f);
            commands[Keys.Oemplus] = new ScaleCommand(1.25f);

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
                    figures.SelectElement(i.GetCurrent());
                    flag = true;
                }
            }
            if (!flag)
            {
                Figure figure = factory.CreateFigure(toolStripComboBox1.Text, colordDialog1.Color, true, e.X, e.Y, 40, 25);
                Command new_command = new AddCommand(figures, figure);
                new_command.Execute(figure);
                history.Push(new_command);
                toolStripDropDownButton2.DropDownItems.Insert(0, new ToolStripLabel("Ñîçäàíèå ýëåìåíòà"));
                //figures.PushBack(figure);
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
                    figures.SelectElement(i.GetCurrent());
                    // i.GetCurrent().Select();
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Element figure = factory.CreateFigure(toolStripComboBox1.Text, colordDialog1.Color, true, e.X, e.Y);
                Command new_command = new AddCommand(figures, figure);
                new_command.Execute(figure);
                history.Push(new_command);
                // figures.PushBack(figure);
            }
        }

        private void splitContainer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void Unexecute()
        {
            if (history.Count > 0)
            {
                Command last_command = history.Pop();
                last_command.Unexecute();
            }
            splitContainer1.Panel1.Refresh();
        }
        private void Delete()
        {
            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    Command new_command = new DeleteCommand(figures, i.GetCurrent());
                    new_command.Execute(i.GetCurrent());
                    history.Push(new_command);
                }
            }
            if (figures.Count != 0)
            {
                figures.SelectElement(figures.Tail.Value);
            }
            splitContainer1.Panel1.Refresh();
        }
        protected override bool ProcessCmdKey(ref Message message, Keys keyData)
        {
            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.Z) == Keys.Z))
            {
                Unexecute();
            }
            else if (keyData == Keys.Back)
            {
                Delete();
            }

            return base.ProcessCmdKey(ref message, keyData);
        }
        private void splitContainer1_Panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                i.GetCurrent().Draw(e);
            }
            splitContainer1.Panel1.Select();
        }
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Select();
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            Element.UpdateBorder(splitContainer1.Panel1.Right, splitContainer1.Panel1.Bottom);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colordDialog1.FullOpen = false;
            Color oldColor = colordDialog1.Color;
            if (colordDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    Command new_command = new ColorCommand(colordDialog1.Color, oldColor);
                    new_command.Execute(i.GetCurrent());
                    history.Push(new_command);
                }
            }
            colordDialog1.Color = oldColor;
            splitContainer1.Panel1.Refresh();
        }

        private void ñãðóïïèðîâàòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CGroup new_group = new CGroup(true);
            Command group = new GroupCommand(figures);
            group.Execute(new_group);
            if (new_group.Count() > 0)
            {
                history.Push(group);
            }
            /* CIterator<Element> i = figures.CreateIterator();
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
                     //storageCommands['D'] = new DeleteCommand(figures, figures.Head, i.GetCurrent());
                     //storageCommands['D'].Execute(i.GetCurrent());
                     figures.Remove(i.GetCurrent());
                 }
             }
            
            if (new_group.Count() > 0)
            {
                figures.PushBack(new_group);
            }
            */
            splitContainer1.Panel1.Refresh();
        }

        private void ðàçãðóïïèðîâàòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command group = new DeGroupCommand(figures);

            //ShapeStorage group_elements = new ShapeStorage();

            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected && i.GetCurrent() is CGroup)
                {
                    group.Execute(i.GetCurrent());
                    history.Push(group);
                    //(i.GetCurrent() as CGroup).Decompose(group_elements);
                    //figures.Remove(i.GetCurrent());
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

            // i = group_elements.CreateIterator();
            //for (i.First(); !i.IsEol(); i.Next())
            //{
            //    figures.PushBack(i.GetCurrent());
            //}
            splitContainer1.Panel1.Refresh();
        }

        private async void ñîõðàíèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\Äåìèä\source\repos\Lab_6_visual_editor";
            sfd.Filter = "TXT files|*.txt";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = sfd.FileName;
            using (StreamWriter fs = new StreamWriter(filename))
            {
                await fs.WriteLineAsync(figures.Count.ToString());

                CIterator<Element> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    i.GetCurrent().Save(fs);
                }
            }
        }

        private void îòêðûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT files|*.txt";
            ofd.InitialDirectory = @"C:\Users\Äåìèä\source\repos\Lab_6_visual_editor";
            string path;
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            path = ofd.FileName;
            figures.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                figures.LoadFigures(reader, factory);
            }

            splitContainer1.Panel1.Refresh();
        }

        private void çàêðûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figures.Clear();
            splitContainer1.Panel1.Refresh();
        }

        bool draging = false;
        bool was_dragged = false;
        int curPosX, curPosY, start_x, start_y;
        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            CIterator<Element> i = figures.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected && i.GetCurrent().CheckSelection(e.X, e.Y))
                {
                    draging = true;
                }
            }
            curPosX = Cursor.Position.X;
            curPosY = Cursor.Position.Y;
            start_x = curPosX;
            start_y = curPosY;
        }

        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (draging)
            {
                Command move = new MoveCommand(Cursor.Position.X - curPosX, Cursor.Position.Y - curPosY);
                CIterator<Element> i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        Command new_command = move.Copy();
                        new_command.Execute(i.GetCurrent());
                        if (i.GetCurrent().IsOnEdge())
                        {
                            new_command.Unexecute();
                        }
                    }
                }
                was_dragged = true;
                curPosX = Cursor.Position.X;
                curPosY = Cursor.Position.Y;
                splitContainer1.Panel1.Refresh();
            }
        }
        private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            draging = false;
            CIterator<Element> i = figures.CreateIterator();

            if (CtrlCheck.Checked && Control.ModifierKeys == Keys.Control)
            { }
            else if (!was_dragged)
            {
                i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    figures.DeselectElement(i.GetCurrent());
                }
            }
            if (!was_dragged)
            {
                if (IntersectionCheck.Checked)
                    MouseClickWithIntersection(sender, e);
                else
                    MouseClickNoIntersection(sender, e);
            }
            else
            {
                i = figures.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsSelected)
                    {
                        Command new_com = new MoveCommand(curPosX - start_x, curPosY - start_y, i.GetCurrent());
                        history.Push(new_com);
                    }

                }
            }
            was_dragged = false;
            splitContainer1.Panel1.Refresh();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Action == TreeViewAction.ByMouse)
            {
                for (int i = 0; i < treeHandler.treeView.Nodes.Count; i++)
                {
                    treeHandler.treeView.Nodes[i].BackColor = Color.White;
                }
                TreeNode tmp = e.Node;
                while (tmp.Parent != null)
                {
                    tmp = tmp.Parent;
                }
                tmp.BackColor = Color.Gray;
                treeHandler.Notify();
            }
            splitContainer1.Panel1.Refresh();
        }

        private void splitContainer1_Panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Keys com = e.KeyData;
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
                        Command new_command = current.Copy();
                        new_command.Execute(i.GetCurrent());
                        if (i.GetCurrent().IsOnEdge())
                        {
                            new_command.Unexecute();
                        }
                        else
                        {
                            history.Push(new_command);
                        }
                    }
                }
            }
            splitContainer1.Panel1.Refresh();
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
            {
                e.Cancel = true;
            }
            splitContainer1.Panel1.Select();
        }
    }
}