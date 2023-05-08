using Lab_6_visual_editor.Figures;
using Lab_6_visual_editor.Interfaces;

namespace Lab_6_visual_editor
{
    public abstract class Figure: Element
    {
        public Color Fcolor { get; protected set; }
       // public bool IsSelected { get; protected set; }
        public float X { get; protected set; }
        public float Y { get; protected set; }
       // public static int border_x { get; protected set; }
       // public static int border_y { get; protected set; }

        public Figure(Color color, bool select, float x, float y)
        {
            Fcolor = color;
            IsSelected = select;
            X = x;
            Y = y;
        }
        abstract public char WhatEdge(); // на какой границе 
        abstract public void Correct(char label); // коррекция положения
        public override void Select()
        {
            IsSelected = true;
        }
        public override void Deselect()
        {
            IsSelected = false;
        }
        public override void ColorChange(Color color)
        {
            Fcolor = color;
        }

        // public abstract void Save();
        // public abstract void Load();
    }
}

