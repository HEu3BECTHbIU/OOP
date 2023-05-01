using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Lab_6_visual_editor
{
    internal class Polygon: Figure
    {
        PointF[] vertices;
        protected float Radius = 50.0f;
        protected float angle;
        // GraphicsPath path;
        public int VertCount { get; protected set; }
        public Polygon (Color color, bool select, float x, float y, int num_of_vertices) :base(color, select, x, y)
        {
            VertCount = num_of_vertices;
            angle = 360.0f / VertCount;
            Correct(0);
            Correct(0);
            vertices = new PointF[num_of_vertices];
            VertCount = num_of_vertices;

            Recalc(X, Y);
        }
        protected void Recalc(float x, float y)
        {
            float tmp_x = 0, tmp_y = 0;
            float tmp_angle = 0.0f;
            for (int i = 0; i < VertCount; i++)
            {
                tmp_x = x + Radius * MathF.Cos(tmp_angle / 180.0f * MathF.PI);
                tmp_y = y - Radius * MathF.Sin(tmp_angle / 180.0f * MathF.PI);
                vertices[i] = new PointF(tmp_x, tmp_y);
                tmp_angle += angle;
            }
        }
        public override void Draw(PaintEventArgs pict)
        {
            Brush brush = new SolidBrush(Fcolor);
            Pen pen = new Pen(Color.Black, 2.5f);
            if (IsSelected == true)
            {
                pen.Color = Color.Red;
            }
             pict.Graphics.FillPolygon(brush, vertices);
             pict.Graphics.DrawPolygon(pen, vertices);
        }
        public override bool CheckSelection(int x, int y)
        {
            bool result = false;
            int j = VertCount - 1;
            for (int i = 0; i < VertCount; i++)
            {
                float res1 = vertices[i].X + (y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) * (vertices[j].X - vertices[i].X);
                if ((vertices[i].Y < y && vertices[j].Y >= y || vertices[j].Y < y && vertices[i].Y >= y) &&
                     (res1 < x))
                    result = !result;
                j = i;
            }
            return result;
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
            Recalc(X, Y);
        }
        public override void ScaleChange(char key)
        {
            if (key ==  '-')
            {
                Radius -= RadiusMargin;
                return;
            }
            else if (key == '+')
            {
                Radius += RadiusMargin;
                Correct(RadiusMargin);
            }
            Recalc(X, Y);
        }
        public override void Correct(int margin)
        {
            char? edge = WhatEdge(margin);
            if (edge == 'l')
            {
                X = Radius + margin;
            }
            if (edge == 'u')
            {
                Y = Radius + margin;
            }
            if (edge == 'r')
            {
                X = border_x - Radius - margin;
            }
            if (edge == 'b')
            {
                Y = border_y - Radius - margin;
            }
        }
        public override char? WhatEdge(int margin)
        {
            if (X - Radius - margin < 0)
            {
                return 'l';
            }
            else if (X + Radius + margin > border_x)
            {
                return 'r';
            }
            else if (Y - Radius - RadiusMargin < 0)
            {
                return 'u';
            }
            else if (Y + Radius + margin > border_y)
            {
                return 'b';
            }
            return null;
        }
    }
}
