using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab_6_visual_editor.Figures;

namespace Lab_6_visual_editor
{
    public abstract class FigureFactory
    {
        public abstract Figure CreateFigure(string name, Color color, bool select, int x, int y, int big = 40, int small = 25);
        public abstract Element? CreateFigure(string name);
       // public abstract Figure CreatePolygon(string name, Color color, bool select, int x, int y, int num_of_vertices);
    }

    internal class MyFactory: FigureFactory
    {
        public override Figure CreateFigure(string name, Color color, bool select, int x, int y, int big = 40, int small = 25)
        {
            Figure? fig = null;
            if (name == "Ellipse")
            {
                fig = new Ellipse(color, select, x, y, big, small);
            }
            else if (name == "Circle")
            {
                fig = new Ellipse(color, select, x, y, big, big);
            }
            else if (name == "Square")
            {
                fig = new Polygon(color, select, x, y, 4);
            }
            else if (name == "Pentagon")
            {
                fig = new Polygon(color, select, x, y, 5);
            }
            else if (name == "Triangle")
            {
                fig = new Polygon(color, select, x, y, 3);
            }
            else
            {
                fig = new Ellipse(color, select, x, y, big, big);
            }
            return fig;
        }

        public override Element? CreateFigure(string name)
        {
            Element? fig = null;
            if (name == "Ellipse")
            {
                fig = new Ellipse(default, default, default, default, default, default);
            }
            else if (name == "Polygon")
            {
                fig = new Polygon(default, default, default, default, default);
            }
            else if (name == "Group")
            {
                fig = new CGroup(default);
            }
            return fig;
        }
    }
}
