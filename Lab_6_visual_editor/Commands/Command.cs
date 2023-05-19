using Lab_6_visual_editor.Figures;
using Lab_6_visual_editor.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Commands
{
    public abstract class Command
    {
        public abstract void Unexecute();
        public abstract void Execute(Element selection);

        public abstract Command Copy();
    }

    public class MoveCommand : Command
    {
        protected Element? selection;
        protected int x;
        protected int y;

        public MoveCommand(int x, int y, Element? selection = null)
        {
            this.selection = selection;
            this.x = x;
            this.y = y;
        }
        public override void Unexecute()
        {
            if (selection != null)
            {
                selection.Move(-x, -y);
            }
        }
        public override void Execute(Element selection)
        {
            this.selection = selection;
            if (selection != null)
            {
                selection.Move(x, y);
            }
        }

        public override Command Copy()
        {
            return new MoveCommand(x, y);
        }
    }
    public class ScaleCommand : Command
    {
        protected Element? selection;
        protected float scale;

        public ScaleCommand(float scale)
        {
            this.selection = null;
            this.scale = scale;
        }
        public override void Unexecute()
        {
            if (selection != null)
            {
                selection.ScaleChange(1 / scale);
            }
        }
        public override void Execute(Element selection)
        {
            this.selection = selection;
            if (selection != null)
            {
                selection.ScaleChange(scale);
            }
        }

        public override Command Copy()
        {
            return new ScaleCommand(scale);
        }
    }
    public class ColorCommand : Command
    {
        protected Element? selection;
        protected Color color;
        protected Color old_color;
        public ColorCommand(Color col, Color old_color)
        {
            selection = null;
            color = col;
            this.old_color = old_color;
        }
        public override void Unexecute()
        {
            if (selection != null)
            {
                selection.ColorChange(old_color);
            }
        }
        public override void Execute(Element selection)
        {
            this.selection = selection;
            if (selection != null)
            {
                selection.ColorChange(color);
            }
        }

        public override Command Copy()
        {
            return new ColorCommand(color, old_color);
        }
    }
    public class DeleteCommand: Command
    {
        protected ShapeStorage selection;
        protected Element to_delete;
        protected Node<Element>? before;
        public DeleteCommand(ShapeStorage selection, Element to_delete)
        {
            this.selection = selection;
            before = selection.FindFirst(to_delete);
            before = before.Prev;

            this.to_delete = to_delete;
        }

        public override Command Copy()
        {
            return new DeleteCommand(selection, to_delete);
        }

        public override void Execute(Element elem)
        {
            selection.Remove(to_delete);
        }
        public override void Unexecute()
        {

            selection.InsertAfter(to_delete, before);
        }
    }

    public class AddCommand : Command
    {
        protected ShapeStorage selection;
        protected Element added;
        public AddCommand(ShapeStorage selection, Element added)
        {
            this.selection = selection;
            this.added = added;
        }

        public override Command Copy()
        {
            return new AddCommand(selection, added);
        }

        public override void Execute(Element elem)
        {
            selection.PushBack(added);
        }
        public override void Unexecute()
        {
            selection.Remove(added);
            if (selection.Count != 0)
            {
                selection.SelectElement(selection.Tail.Value);
            }
        }
    }

    public class GroupCommand : Command
    {
        protected ShapeStorage selection;
        protected Element added;
        public GroupCommand(ShapeStorage selection, Element added = null)
        {
            this.selection = selection;
            this.added = added;
        }

        public override Command Copy()
        {
            return new GroupCommand(selection);
        }

        public override void Execute(Element elem)
        {
            if (elem == null)
                return;
            added = elem;
            (added as CGroup).group.Clear();
            CIterator <Element> i = selection.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    (added as CGroup).AddFigure(i.GetCurrent());
                }
            }
            i = selection.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    selection.Remove(i.GetCurrent());
                }
            }

            if ((added as CGroup).Count() > 0)
            {
                selection.PushBack(added);
            }
        }
        public override void Unexecute()
        {
            ShapeStorage group_elements = new ShapeStorage();

            (added as CGroup).Decompose(group_elements);

            selection.Remove(added);

            CIterator<Element> i = group_elements.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                selection.PushBack(i.GetCurrent());
            }
        }
    }

    public class DeGroupCommand : Command
    {
        protected ShapeStorage selection;
        protected Element added;
        public DeGroupCommand(ShapeStorage selection)
        {
            this.selection = selection;
        }

        public override Command Copy()
        {
            return new DeGroupCommand(selection);
        }

        public override void Execute(Element elem)
        {
            added = elem;
            if (added != null)
            {
                Command degroup = new GroupCommand(selection, added);
                degroup.Unexecute();
            }
           // Command degroup = new GroupCommand(selection, elem);
           // degroup.Unexecute();
        }
        public override void Unexecute()
        {
            Command degroup = new GroupCommand(selection);
            degroup.Execute(added);
        }
    }
}
