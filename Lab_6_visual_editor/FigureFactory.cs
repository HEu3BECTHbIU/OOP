using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor
{
    internal abstract class FigureFactory
    {
        public abstract Figure CreateFigure(string name, Color color, bool select, int x, int y, int big = 40, int small = 25);
       // public abstract Figure CreatePolygon(string name, Color color, bool select, int x, int y, int num_of_vertices);
    }

    internal class MyFactory: FigureFactory
    {
        public override Figure CreateFigure(string name, Color color, bool select, int x, int y, int big = 40, int small = 25)
        {
            Figure fig;
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

       /* public override Figure CreatePolygon(string name, Color color, bool select, int x, int y, int num_of_vertices)
        {
            Figure fig = null;
            if (name == "Square")
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
            return fig;
        }
       */

    }
}
