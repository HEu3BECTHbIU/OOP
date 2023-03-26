using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circles
{
    internal class Circle
    {
        public int X { get; private set; }
        public int Y {get; private set; }
        public int Radius { get; } = 30;
        public bool IsSelected { get; internal set; }
        public Circle(int x, int y)
        {
            X = x;
            Y = y;
            IsSelected = false;
        }
        public void Draw(PaintEventArgs pict)
        {
            //Graphics g = pict.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.Black, 2);
            if (IsSelected == false) 
            {
                brush.Color = Color.Blue;
            }
            //g.DrawEllipse(p, (float)(X - Radius), (float)(Y - Radius), Radius * 2, Radius * 2);
            pict.Graphics.FillEllipse(brush, (X - Radius),(Y - Radius), Radius * 2, Radius * 2);
            pict.Graphics.DrawEllipse(pen, (X - Radius), (Y - Radius), Radius * 2, Radius * 2);
            //pict.Graphics.Dispose();
        }
        public bool CheckSelection(int x, int y)
        {
            if (((x - X)*(x - X) + (y - Y)*(y - Y)) <= Radius * Radius )
            {
                IsSelected = true;
                return true;
            }
            return false;
        }
    }
}
