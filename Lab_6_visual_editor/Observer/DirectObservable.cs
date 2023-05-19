using Lab_6_visual_editor.Figures;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Observer
{
    public class DirectObservable
    {
        public List<Element> observers { get; }
        public List<bool> visited { get; }
        List<Element> lines;

        public DirectObservable()
        {
            observers = new List<Element>();
            lines = new List<Element>();
            visited = new List<bool>();
        }

        public void NotifyObservers(int dx, int dy)
        {
            for (int i = 0; i < observers.Count;i++)
            {
                if (visited[i] == false)
                {
                    visited[i] = true;
                    observers[i].Move(dx, dy);
                    if (observers[i].IsOnEdge())
                    {
                        observers[i].Move(-dx, -dy);
                    }
                   // visited[i] = true;
                }
            }
        }
        public void AddObserver(Element e)
        {
            observers.Add(e);
            visited.Add(false);
        }
        public void RemoveObserver(Element e)
        {
            observers.Remove(e);
        }
        public void Clear()
        {
            observers.Clear();
            visited.Clear();
        }
        public bool IsObserver(Element e)
        {
            return observers.Contains(e);
        }

        public void ShowLines(float start_x, float start_y, PaintEventArgs pict)
        {
            foreach (Element e in observers)
            {
                Pen pen = new Pen(Color.Black, 1.0f);
                pen.CustomEndCap = new AdjustableArrowCap(6,6, true);
                pict.Graphics.DrawLine(pen, start_x, start_y, e.GetCenter().X, e.GetCenter().Y);
            }
        }
        internal void ToDefault()
        {
            for (int i = 0; i < visited.Count; i++)
            {
                visited[i] = false;
            }
        }
    }
}
