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
                m.A = result;
            }
            else if (tag == "B")
            {
                if (result == -1) { result = m.B; }
                m.B = result;
            }
            else if (tag == "C")
            {
                if (result == -1) { result = m.C; }
                m.C = result;
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
            NumericUpDown tmp = (NumericUpDown)sender;
            s = tmp.Tag.ToString();
            if (tmp.Text.ToString() == string.Empty)
            {
                res = -1;
            }
            else
            {
                res = Convert.ToInt32(tmp.Value);
            }
        }
    }
    class TempTrack : Template
    {
        public override void DoSpecific(object sender, out string s, out int res)
        {
            TrackBar tmp = (TrackBar)sender;
            s = tmp.Tag.ToString();
            res = Convert.ToInt32(tmp.Value);
            if (res == decimal.Zero)
            {
                res = -1;
            }
        }
    }
}
   