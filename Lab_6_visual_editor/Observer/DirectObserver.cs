using Lab_6_visual_editor.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Observer
{
    public class DirectObserver
    {
        public List<Element> parents { get; }
        public DirectObserver()
        {
            parents = new List<Element>();
        }

        public void AddPerent(Element element)
        {
            parents.Add(element);
        }
        public void RemovePerent(Element element)
        {
            parents.Remove(element);
        }
        public bool IsParent(Element element)
        {
            return parents.Contains(element);
        }
        public void Clear()
        {
            parents.Clear();
        }
        public void Changed(PaintEventArgs e)
        {
            foreach (Element element in parents)
            {
                element.observable.ShowLines(element.GetCenter().X, element.GetCenter().Y, e);
            }
        }
    }
}
