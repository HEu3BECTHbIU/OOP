using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Interfaces
{
    internal interface IChangeable
    {
        public void ColorChange(Color color);
        public void ScaleChange(char key);
        public void Move(char key);
    }
}
