namespace Circles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MouseClickWithIntersection(object sender, MouseEventArgs e)
        {
            bool flag = false;
            bool ctrl = ctrl_check.Checked & Control.ModifierKeys == Keys.Control;
            for (Node<Circle>? i = circles.Head; circles.Exists(i); i = i.Next)
            {
                if (i.Value.CheckSelection(e.X, e.Y))
                {
                    flag = true;
                }
                else if (!ctrl)
                {
                    i.Value.IsSelected = false;
                }
            }
            if (flag == false)
            {
                circles.PushBack(new Circle(e.X, e.Y));
                circles.Tail.Value.IsSelected = true;
            }
        }
        private void MouseClickNoIntersection(object sender, MouseEventArgs e)
        {
            bool flag = false;
            bool ctrl = ctrl_check.Checked & Control.ModifierKeys == Keys.Control;
            for (Node<Circle>? i = circles.Head; circles.Exists(i); i = i.Next)
            {
                if (flag == false)
                {
                    if (i.Value.CheckSelection(e.X, e.Y))
                    {
                        flag = true;
                    }
                    else if (!ctrl)
                    {
                        i.Value.IsSelected = false;
                    }
                }
                else if (!ctrl)
                {
                    i.Value.IsSelected = false;
                }
            }
            if (flag == false)
            {
                circles.PushBack(new Circle(e.X, e.Y));
                circles.Tail.Value.IsSelected = true;
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Intersection_check.Checked)
            {
                MouseClickWithIntersection(sender, e);
            }
            else
            {
                MouseClickNoIntersection(sender, e);
            }
            //Rectangle region = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            pictureBox1.Refresh();
           // pictureBox1_Paint(sender, null);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (Node<Circle>? i = circles.Head; circles.Exists(i); i = i.Next)
            {
                i.Value.Draw(e);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                for (Node<Circle>? i = circles.Head; circles.Exists(i); i = i.Next)
                {
                    if (i.Value.IsSelected)
                    {
                        circles.Remove(i.Value);
                        
                    }
                }
            }
            pictureBox1.Refresh();
        }
    }
}