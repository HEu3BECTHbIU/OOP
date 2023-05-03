using Lab_6_visual_editor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Figures
{
    internal class Ellipse : Figure
    {
        public float Big_axis { get; set; }
        public float Small_axis { get; set; }
        public Ellipse(Color color, bool select, float x, float y, int big, int small) : base(color, select, x, y)
        {
            Big_axis = big;
            Small_axis = small;
            char edge = WhatEdge();
            Correct(edge);
            edge = WhatEdge();
            Correct(edge);
        }
        public override bool IsOnEdge()
        {
            char edge = WhatEdge();
            if (edge != default)
            {
                return true;
            }
            return false;
        }
        public override char WhatEdge()
        {
            if (X - Big_axis < 0)
                return 'l';

            else if (X + Big_axis > border_x)
                return 'r';

            else if (Y - Small_axis < 0)
                return 'u';

            else if (Y + Small_axis > border_y)
                return 'b';

            return default;
        }
        public override void Draw(PaintEventArgs pict)
        {
            Brush brush = new SolidBrush(Fcolor);
            Pen pen = new Pen(Color.Black, 2.5f);
            if (IsSelected == true)
            {
                pen.Color = Color.Red;
            }
            pict.Graphics.FillEllipse(brush, X - Big_axis, Y - Small_axis, Big_axis * 2, Small_axis * 2);
            pict.Graphics.DrawEllipse(pen, X - Big_axis, Y - Small_axis, Big_axis * 2, Small_axis * 2);
        }
        public override bool CheckSelection(int x, int y)
        {
            if ((x - X) * (x - X) + (y - Y) * (y - Y) <= Big_axis * Small_axis)
            {
                return true;
            }
            return false;
        }
        
        // коррекция положения в конструкторе
        public override void Correct(char edge)
        {
            
            if (edge == 'l')
                 X = Big_axis;

            else if (edge == 'u')
                Y = Small_axis;

            else if (edge == 'r')
                 X = border_x - Big_axis;

            else if (edge == 'b')
                  Y = border_y - Small_axis;
        }

        public override void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public override void ScaleChange(float scale)
        {
            Small_axis *= scale;
            Big_axis *= scale;
        }
    }
}
