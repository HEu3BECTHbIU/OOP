using Lab_6_visual_editor.Interfaces;
using Lab_6_visual_editor.Storage;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_6_visual_editor.Figures
{
    public class CGroup : Element
    {
        Storage<Element>? group;

        public CGroup(bool selection)
        {
            IsSelected = selection;
            group = new Storage<Element>();
        }
        public void AddFigure(Element element) 
        { 
            group.PushBack(element);
        }
        public void Decompose(Storage<Element> group_members)
        {
            if (group != null)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    group_members.PushBack(i.GetCurrent());
                }
            }
        }
        public override void Select()
        {
            IsSelected = true;
            CIterator<Element> i = group.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                i.GetCurrent().Select();  
            }
        }
        public override void Deselect()
        {
            IsSelected = false;
            CIterator<Element> i = group.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                i.GetCurrent().Deselect();
            }
        }
        public override bool CheckSelection(int x, int y)
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().CheckSelection(x, y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override void Draw(PaintEventArgs pict)
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    i.GetCurrent().Draw(pict);
                }
            }
        }
        public override void ColorChange(Color color)
        {
            CIterator<Element> i = group.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                i.GetCurrent().ColorChange(color);
            }
        }

        public override void Move(int x, int y)
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    i.GetCurrent().Move(x, y);
                }
            }
        }

        public override bool IsOnEdge()
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    if (i.GetCurrent().IsOnEdge())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void ScaleChange(float scale)
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    i.GetCurrent().ScaleChange(scale);
                }
            }
        }
        /*
        public override void Move(char key)
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    i.GetCurrent().Move(key);
                    char edge = WhatEdge();
                    if (edge != default)
                    {
                       // i.GetCurrent().Correct(edge);
                        break;
                    }
                }
            }
        }
        */
        /*
        public override void ScaleChange(char key)
        {
            if (group.Count != 0)
            {
                CIterator<Element> i = group.CreateIterator();
                for (i.First(); !i.IsEol(); i.Next())
                {
                    i.GetCurrent().ScaleChange(key);
                }
            }
        }
        */
    }
}
