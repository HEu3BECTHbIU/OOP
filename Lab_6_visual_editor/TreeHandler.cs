using Lab_6_visual_editor.Figures;
using Lab_6_visual_editor.Observer;
using Lab_6_visual_editor.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor
{
    public class TreeHandler : IObserver, IObservable
    {
        internal TreeView treeView;
        List<IObserver> observers;
        public TreeHandler(TreeView tree)
        {
            observers = new List<IObserver>();
            treeView = tree;
        }

        public void AddObserver(IObserver obj)
        {
            observers.Add(obj);
        }
        public void Notify()
        {
            foreach (IObserver obs in observers)
            {
                obs.OnObjectChanged(this);
            }
        }

        public void OnObjectChanged(IObservable o)
        {
            treeView.Nodes.Clear();
            ShapeStorage tmp = (ShapeStorage)o;
            CIterator<Element> i = tmp.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                TreeNode new_node = new TreeNode(i.GetCurrent().GetName());
                if(i.GetCurrent().IsSelected)
                {
                    new_node.BackColor = Color.Gray;
                    new_node.Expand();
                }
                else
                {
                   new_node.Collapse();
                }
                if (i.GetCurrent() is CGroup)
                {
                    ProcessNode(new_node, i.GetCurrent());
                }
                treeView.Nodes.Add(new_node);
            }
           // treeView.Refresh();
        }
        public void ProcessNode(TreeNode tr, Element elem)
        {
            if (elem is CGroup)
            {
                ShapeStorage tmp = (elem as CGroup).group;
                CIterator<Element> i = tmp.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    TreeNode new_node = new TreeNode(i.GetCurrent().GetName());
                    if (i.GetCurrent().IsSelected)
                    {
                        new_node.BackColor = Color.Gray;
                        new_node.Expand();
                    }
                    else
                    { 
                        new_node.Collapse(); 
                    }
                    ProcessNode(new_node, i.GetCurrent());
                    tr.Nodes.Add(new_node);
                }
            }
        }
    }
}
