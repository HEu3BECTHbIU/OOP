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
            for (int i = 0; i < circles.Count; i++)
            {
                if (circles[i].CheckSelection(e.X, e.Y))
                {
                    flag = true;
                }
                else if (!ctrl)
                {
                    circles[i].IsSelected = false;
                }
            }
            if (flag == false)
            {
                circles.Add(new Circle(e.X, e.Y));
                circles.Last().IsSelected = true;
            }
        }
        private void MouseClickNoIntersection(object sender, MouseEventArgs e)
        {
            bool flag = false;
            bool ctrl = ctrl_check.Checked & Control.ModifierKeys == Keys.Control;
            for (int i = 0; i < circles.Count; i++)
            {
                if (flag == false)
                {
                    if (circles[i].CheckSelection(e.X, e.Y))
                    {
                        flag = true;
                    }
                    else if (!ctrl)
                    {
                        circles[i].IsSelected = false;
                    }
                }
                else if (!ctrl)
                {
                    circles[i].IsSelected = false;
                }
            }
            if (flag == false)
            {
                circles.Add(new Circle(e.X, e.Y));
                circles.Last().IsSelected = true;
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
            for (int i = circles.Count - 1; i >= 0; i--)
            {
                circles[i].Draw(e);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8)
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].IsSelected)
                    {
                        circles.Remove(circles[i]);
                        i--;
                    }
                }
            }
            pictureBox1.Refresh();
        }
    }
}