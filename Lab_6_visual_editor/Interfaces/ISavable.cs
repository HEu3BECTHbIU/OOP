using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Interfaces
{
    internal interface ISavable
    {
        public void Save(StreamWriter reader);
        public void Load(StreamReader reader, FigureFactory factory);
    }
}
