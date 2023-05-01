using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor
{
    internal class Ellipse : Figure
    {
        public int Big_axis { get; set; }
        public int Small_axis { get; set; }
        public Ellipse(Color color, bool select, float x, float y, int big, int small) : base(color, select, x, y)
        {
            Big_axis = big;
            Small_axis = small;
            Correct(0);
            Correct(0);
        }
        public override char? WhatEdge(int margin)
        {
            if (X - Big_axis - margin < 0)
                return  'l';
            
            else if (X + Big_axis + margin > border_x)
                return 'r';

            else if (Y - Small_axis - RadiusMargin < 0)
                return 'u';

            else if (Y + Small_axis + margin > border_y)
                return 'b';
            return null;
        }
        public override void Draw(PaintEventArgs pict)
        {
            Brush brush = new SolidBrush(Fcolor);
            Pen pen = new Pen(Color.Black, 2.5f);
            if (IsSelected == true)
            {
                pen.Color = Color.Red;
            }
            pict.Graphics.FillEllipse(brush, (X - Big_axis), (Y - Small_axis), Big_axis * 2, Small_axis * 2);
            pict.Graphics.DrawEllipse(pen, (X - Big_axis), (Y - Small_axis), Big_axis * 2, Small_axis * 2);
        }
        public override bool CheckSelection(int x, int y)
        {
            if (((x - X) * (x - X) + (y - Y) * (y - Y)) <= Big_axis * Small_axis)
            {
                // Select();
                return true;
            }
            return false;
        }
        public override void ScaleChange(char key)
        {
            if (key == '-')
            {
                Big_axis -= RadiusMargin;
                Small_axis -= RadiusMargin;
                return;
            }
            else if (key == '+')
            {
                Big_axis += RadiusMargin;
                Correct(RadiusMargin);
                Small_axis += RadiusMargin;
                Correct(RadiusMargin);
            }
        }
        public override void Correct(int margin)
        {
            char? edge = WhatEdge(margin);
            if (edge == 'l')
                X = Big_axis + margin;

            else if (edge == 'u')
                Y = Small_axis + margin;

            else if (edge == 'r')
                X = border_x - Big_axis - margin;

            else if (edge == 'b')
                 Y = border_y - Small_axis - margin;
        }
        public override void Move(char key)
        {
            if (key == 'w')
                Y -= MoveMargin;
            else if (key == 's')
                Y += MoveMargin;
            else if (key == 'a')
                X -= MoveMargin;
            else if (key == 'd')
                X += MoveMargin;
            Correct(MoveMargin / 2);
        }
    }
}
