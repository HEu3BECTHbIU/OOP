namespace Lab_6_visual_editor.Figures
{
    public class Polygon : Figure
    {
        protected PointF[] vertices;
        public  float Radius { get; protected set; } = 50.0f;
        protected float angle;
        public int VertCount { get; protected set; }
        public Polygon(Color color, bool select, float x, float y, int num_of_vertices) : base(color, select, x, y)
        {
            VertCount = num_of_vertices;
            angle = 360.0f / VertCount;
            vertices = new PointF[VertCount];
            Recalc(X, Y);

            char edge = WhatEdge();
            Correct(edge);
            edge = WhatEdge();
            Correct(edge);
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
                     res1 < x)
                    result = !result;
                j = i;
            }
            return result;
        }
        public override void Correct(char edge)
        {
            if (edge == 'l')
                X = Radius;

            else if (edge == 'u')
                Y = Radius;

            else if (edge == 'r')
                X = border_x - Radius;

            else if (edge == 'b')
                Y = border_y - Radius;
        }
        public override char WhatEdge()
        {
            for (int i = 0; i < VertCount; i++)
            {
                if (vertices[i].X < 0)
                    return 'l';
                if (vertices[i].X > border_x)
                    return 'r';
                if (vertices[i].Y < 0)
                    return 'u';
                if (vertices[i].Y > border_y)
                    return 'b';
            }
            return default;
        }

        public override void Move(int x, int y)
        {
            X += x;
            Y += y;
            for (int i = 0; i < VertCount; i++)
            {
                vertices[i].X += x;
                vertices[i].Y += y;
            }
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

        public override void ScaleChange(float scale)
        {
            Radius *= scale;
            Recalc(X, Y);
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine("Polygon");
            string s = Fcolor.ToArgb() + " " + X + " " + Y + " " + IsSelected + " " + Radius + " " + VertCount;
            //reader.Write(Fcolor.Name, " ", X, " ", Y, " ", IsSelected, " ", Big_axis, " ", Small_axis, "\n");
            writer.WriteLine(s);
        }

        public override void Load(StreamReader reader, FigureFactory factory)
        {
            string[] names = (reader.ReadLine()).Split(" ");
            Fcolor = Color.FromArgb(Convert.ToInt32(names[0]));
            X = Convert.ToInt32(names[1]);
            Y = Convert.ToInt32(names[2]);
            IsSelected = Convert.ToBoolean(names[3]);
            Radius = Convert.ToInt32(names[4]);
            VertCount = Convert.ToInt32(names[5]);

            vertices = new PointF[VertCount];
            angle = 360.0f / VertCount;
            Recalc(X, Y);
        }
        public override string GetName()
        {
            if (VertCount == 3)
                return "Triangle";
            else if (VertCount == 4)
                return "Square";
            else return "Pentagon";
        }
    }
}
