using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_visual_editor.Storage
{
       public abstract class CIterator<T>
    {
            public abstract void First();
            public abstract void Next();
            public abstract T? GetCurrent();
            public abstract void SetCurrent(T value);
            public abstract bool IsEol();
    }

        public class StorageIterator<T> : CIterator<T>
        {
            private readonly Storage<T>? stor;
            private Node<T>? CurrentNode;

        public StorageIterator(Storage<T> stor)
        {
            this.stor = stor;
            if (!IsEol())
            {
                CurrentNode = stor.Head;
            }
            else
            {
                CurrentNode = null;
            }
        }

            public override void First()
            {
                if (stor.Head != null)
                {
                    CurrentNode = stor.Head;
                }
            }
            public override T? GetCurrent()
            {
                if (CurrentNode != null)
                {
                    return CurrentNode.Value;
                }
                return default;
            }
            public override void SetCurrent(T value)
            {
                if (CurrentNode != null)
                {
                    CurrentNode.value = value;
                }
            }
        public override bool IsEol()
        {
            return CurrentNode == null;
        }
        public override void Next()
        {
            CurrentNode = CurrentNode.Next;
        }
    }
}
