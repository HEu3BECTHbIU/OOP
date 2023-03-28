using System;
using System.Windows.Forms;

namespace Lab4_2_MVC
{
    public partial class Form1 : Form
    {
        public Model m;
        public Form1()
        {
            m = new Model();
            InitializeComponent();
            m.observers += Update;
        }
        private void Update(object sender, EventArgs e)
        {
            A_TextBox.Text = m.A.ToString();
            //A_numericUpDown.Value = m.A;
            A_trackBar.Value = m.A;
            A_numericUpDown.Text = m.A.ToString();

            B_TextBox.Text = m.B.ToString();
            //B_numericUpDown.Value = m.B;
            B_trackBar.Value = m.B;
            B_numericUpDown.Text = m.B.ToString();

            C_TextBox.Text = m.C.ToString();
            C_numericUpDown.Text = m.C.ToString();
            C_trackBar.Value = m.C;
            
        }
        /*private void ChooseFunc(string tag, int result)
        {
            if (tag == "A")
            {

                if (result == -1) { result = m.A; }
                m.SetValueA(result);
            }
            else if (tag == "B")
            {
                if (result == -1) { result = m.B; }
                m.SetValueB(result);
            }
            else if (tag == "C")
            {
                if (result == -1) { result= m.C; }
                m.SetValueC(result);
            }
        }*/
        private void A_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //string tag = (sender as TextBox).Tag.ToString();
               // int res;
               // if (!Int32.TryParse((sender as TextBox).Text, out res) || (sender as TextBox).Text == string.Empty)
                //{
                //    res = -1;
                //}
                //ChooseFunc(tag, res);
                TempTextBox t = new TempTextBox();
                t.TemplateMethod(sender, m);
            }
        }
        private void A_trackBar_Scroll(object sender, EventArgs e)
        {
            TempTrack t = new TempTrack();
            t.TemplateMethod(sender, m);
        }

        private void A_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            TempNumeric t = new TempNumeric();
            t.TemplateMethod(sender, m);
        }
        private void A_TextBox_Leave(object sender, EventArgs e)
        {
            TempTextBox t = new TempTextBox();
            t.TemplateMethod(sender, m);
        }
        private void A_numericUpDown_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show(C_numericUpDown.Value.ToString());
            TempNumeric t = new TempNumeric();
            t.TemplateMethod(sender, m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m.WriteToFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m.LoadFromFile();
        }
    }

    public class Model
    {
        private int a;
        private int b;
        private int c;

        public delegate void Changed(object sender, EventArgs e);
        public Changed? observers;
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        public int C
        {
            get { return c; }
            set { c = value; }
        }
        public void SetValueA(int value)
        {
            A = value;
            if (A < 0)
            {
                A = 0;
            }
            if (A > 100)
            {
                A = 100;
            }
            if (A > B)
            {
                B = A;
            }
            if (B > C)
            {
                C = B;
            }
            observers.Invoke(null, EventArgs.Empty);
        }
        public void SetValueB(int value)
        {
            if (value >= A && value <= C)
            {
                B = value;
            }
            observers.Invoke(null, EventArgs.Empty);
        }
        public void SetValueC(int value)
        {
            C = value;
            if (C < 0)
            {
                C = 0;
            }
            if (C > 100)
            {
                C = 100;
            }
            if (C < B)
            {
                B = C;
            }
            if (B < A)
            {
                A = B;
            }
            //MessageBox.Show("I was at C func");
            observers.Invoke(null, EventArgs.Empty);
        }
        public void LoadFromFile()
        {
            FileStream fs = new FileStream("1.txt", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            A = bw.ReadInt32();
            B = bw.ReadInt32();
            C = bw.ReadInt32();
            fs.Close();
            observers.Invoke(null, EventArgs.Empty);
        }
        public void WriteToFile()
        {
            FileStream fs = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(A);
            bw.Write(B);
            bw.Write(C);
            fs.Close();
        }
    }
    abstract class Template
    {
        public virtual void DoSpecific(object sender, out string s, out int res)
        {
            s = string.Empty;
            res = 0;
        }
        public void TemplateMethod(object sender, Model m)
        {
            DoSpecific(sender, out string tag, out int result);
            if (tag == "A")
            { 
                if (result == -1) { result = m.A; }
                m.SetValueA(result);
            }
            else if (tag == "B")
            {
                if (result == -1) { result = m.B; }
                m.SetValueB(result);
            }
            else if (tag == "C")
            {
                if (result == -1) { result = m.C; }
                m.SetValueC(result);
            }
            m.observers.Invoke(null, EventArgs.Empty);
        }
    }
    class TempTextBox : Template
    {
        public override void DoSpecific(object sender, out string s, out int res)
        {
            TextBox tmp = (TextBox)sender;
             s = tmp.Tag.ToString();
             if (!Int32.TryParse(tmp.Text, out res) || tmp.Text == string.Empty)
             {
                res = -1;
             }
        }
    }
    class TempNumeric : Template
    {
        public override void DoSpecific(object sender, out string s, out int res)
        {
            s = (sender as NumericUpDown).Tag.ToString();
            if((sender as NumericUpDown).Text.ToString() == string.Empty)
            {
                res = -1;
                MessageBox.Show("I am here");
            }
            else
            {
                res = Convert.ToInt32((sender as NumericUpDown).Value);
            }
        }
    }
    class TempTrack : Template
    {
        public override void DoSpecific(object sender, out string s, out int res)
        {
            s = (sender as TrackBar).Tag.ToString();
            res = Convert.ToInt32((sender as TrackBar).Value);
            if (res == decimal.Zero)
            {
                res = -1;
            }
        }
    }
    /* abstract class Template
     {
         public virtual void DoSpecific(Model m, int res) { }
         public void TemplateMethod(object sender, Model m)
         {
             int result = 0;
             if (sender is TextBox)
             {
                 Int32.TryParse((sender as TextBox).Text, out result);
                 DoSpecific(m, result);
             }
             else if (sender is NumericUpDown)
             {
                 result = Convert.ToInt32((sender as NumericUpDown).Value);
                 DoSpecific(m, result);
             }
             else if (sender is TrackBar)
             {
                 result = Convert.ToInt32((sender as TrackBar).Value);
                 DoSpecific(m, result);
             }
         }
     }
     class TempA: Template
     {
         public override void DoSpecific(Model m, int res)
         {
             m.SetValueA(res);
         }
     }
 */
}
   