using Lab_6_visual_editor.Commands;
using Lab_6_visual_editor.Interfaces;
using Lab_6_visual_editor.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Figures
{
    public class Ellipse : Figure
    {
        public float Big_axis { get; protected set; }
        public float Small_axis { get; protected set; }
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
             //observable.ShowLines(X, Y, pict);
            observer.Changed(pict);
            observable.ToDefault();
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
            observable.NotifyObservers(x, y);
        }
        public override void ScaleChange(float scale)
        {
            Small_axis *= scale;
            Big_axis *= scale;
        }

        public override void Save(StreamWriter reader)
        {
            reader.WriteLine("Ellipse");
            string s = Fcolor.ToArgb() + " " + X + " " + Y + " " + IsSelected + " " + Big_axis + " " + Small_axis;
            //reader.Write(Fcolor.Name, " ", X, " ", Y, " ", IsSelected, " ", Big_axis, " ", Small_axis, "\n");
            reader.WriteLine(s);
        }

        public override async void Load(StreamReader reader, FigureFactory factory)
        {
            string[] names = (await reader.ReadLineAsync()).Split(" ");
            Fcolor = Color.FromArgb(Convert.ToInt32(names[0]));
            X = Convert.ToInt32(names[1]);
            Y = Convert.ToInt32(names[2]);
            IsSelected = Convert.ToBoolean(names[3]);
            Big_axis = Convert.ToInt32(names[4]);
            Small_axis = Convert.ToInt32(names[5]);
            //this = await JsonSerializer.DeserializeAsync<Ellipse>(reader);
        }
        public override string GetName()
        {
            if (Small_axis == Big_axis)
                return "Circle";
            else return "Ellipse";
        }

        public override PointF GetCenter()
        {
            return new PointF(X, Y);
        }
    }
}
