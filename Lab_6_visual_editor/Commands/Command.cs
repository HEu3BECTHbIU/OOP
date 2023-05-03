using Lab_6_visual_editor.Figures;
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
    }

    public class MoveCommand: Command
    {
        protected Element? selection;
        protected int x;
        protected int y;

        public MoveCommand(int x, int y)
        {
            this.selection = null;
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
    }

}
