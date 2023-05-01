using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2_MVC
{
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
            set
            {
                a = value;
                if (a < 0)
                {
                    a = 0;
                }
                if (a > 100)
                {
                    a = 100;
                }
                if (a > b)
                {
                    b = a;
                }
                if (b > c)
                {
                    c = b;
                }
                observers.Invoke(null, EventArgs.Empty);
            }
        }
        public int B
        {
            get { return b; }
            set
            {
                if (value >= a && value <= c)
                {
                    b = value;
                }
                observers.Invoke(null, EventArgs.Empty);
            }
        }
        public int C
        {
            get { return c; }
            set
            {
                c = value;
                if (c < 0)
                {
                    c = 0;
                }
                if (c > 100)
                {
                    c = 100;
                }
                if (c < b)
                {
                    b = c;
                }
                if (b < a)
                {
                    a = b;
                }
                observers.Invoke(null, EventArgs.Empty);
            }
        }
        public void LoadFromFile() 
        {
            FileStream fs = new FileStream("1.txt", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            A = bw.ReadInt32();
            B = bw.ReadInt32();
            C = bw.ReadInt32();
            bw.Close();
            observers.Invoke(null, EventArgs.Empty);
        }
        public void WriteToFile()
        {
            FileStream fs = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(A);
            bw.Write(B);
            bw.Write(C);
            bw.Close();
           // bw.Close();
        }
    }
}
