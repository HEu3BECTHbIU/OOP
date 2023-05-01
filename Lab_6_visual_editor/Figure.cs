using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor
{
    internal abstract class Figure
    {
        public Color Fcolor { get; set; }
        public bool IsSelected { get; protected set; }
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public static int border_x { get; protected set; }
        public static int border_y { get; protected set; }
        protected static int RadiusMargin = 2;
        protected static int MoveMargin = 10;
        public Figure(Color color, bool select, float x, float y)
        {
            Fcolor = color;
            IsSelected = select;
            X = x;
           // Correct(0);
            Y = y;
           // Correct(0);
        }
        public void Select()
        {
            IsSelected = true;
        }
        public void Deselect()
        {
            IsSelected = false;
        }
        public static void UpdateBorder(int right_x, int bottom_y)
        {
            border_x = right_x;
            border_y = bottom_y;
        }
        public void ColorChange(Color color)
        {
            Fcolor = color;
        }
        abstract public bool CheckSelection(int x, int y);
        abstract public void Move(char key);
        abstract public void Draw(PaintEventArgs pict);
        abstract public void ScaleChange(char key);

        abstract public void Correct(int margin);
        abstract public char? WhatEdge(int margin);
    }
}

