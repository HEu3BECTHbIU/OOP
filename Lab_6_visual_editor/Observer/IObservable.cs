using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Observer
{
    public interface IObservable
    {
        void Notify();
        void AddObserver(IObserver obj);

    }
}
