using Lab_6_visual_editor.Interfaces;
using Lab_6_visual_editor.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Figures
{
    public abstract class Element: ISavable
    {
        public DirectObservable observable { get; protected set; }
        public DirectObserver observer { get; protected set; }
        public Element()
        { 
            observable = new DirectObservable();
            observer = new DirectObserver();
        }
        protected readonly static int RadiusMargin = 2;

        protected readonly static int MoveMargin = 10;

        public static int border_x { get; protected set; }
        public static int border_y { get; protected set; }
        public static void UpdateBorder(int right_x, int bottom_y)
        {
            border_x = right_x;
            border_y = bottom_y;
        }
        public bool IsSelected { get; protected set; }
        abstract public void Select(); // выбор элемента
        abstract public void Deselect(); // снятие выбора
        abstract public void ColorChange(Color color); // изменение цвета
        abstract public bool CheckSelection(int x, int y); // проверка на попадание
        abstract public void Move(int x, int y); // перемещение 
        abstract public void ScaleChange(float scale); // изменение размера
        abstract public void Draw(PaintEventArgs pict); // отрисовка
        public abstract bool IsOnEdge(); // проверка, находится ли на границе
        public abstract void Save(StreamWriter reader);
        public abstract void Load(StreamReader reader, FigureFactory factory);

        public abstract PointF GetCenter();

        public abstract string GetName();
        // abstract public char WhatEdge(); // на какой границе 
        // abstract public void Correct(char label); // коррекция положения
    }
}
