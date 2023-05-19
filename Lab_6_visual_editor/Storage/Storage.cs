namespace Lab_6_visual_editor.Storage
{
    using Lab_6_visual_editor.Figures;
    using Lab_6_visual_editor.Observer;
    using System;

    public class Node<T>
    {
        internal T? value;
        internal Node<T>? next;
        internal Node<T>? prev;
        public T? Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public Node<T>? Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node<T>? Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public Node(T value)
        {
            Value = value;
            next = null;
            prev = null;
        }
    }
    public class Storage<K>
    {
        public Node<K>? Head { get; protected set; }
        public Node<K>? Tail { get; protected set; }
        public int Count { get; protected set; }

        public Storage()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void PushBack(K value)
        {
            if (Head == null)
            {
                Head = new Node<K>(value);
                Tail = Head;
                Count++;
            }
            else
            {
                Tail.Next = new Node<K>(value);
                Tail.Next.Prev = Tail;
                Tail = Tail.Next;
                Count++;
            }
        }
        public void PushFront(K value)
        {
            if (Head == null)
            {
                Head = new Node<K>(value);
                Tail = Head;
                Count++;
            }
            else
            {
                Head.Prev = new Node<K>(value);
                Head.Prev.Next = Head;
                Head = Head.Prev;
                Count++;
            }
        }
        internal bool Exists(Node<K>? node)
        {
            return node != null;
        }
        public void InsertAfter(K value, Node<K>? node)
        {
            Node<K> elem = new Node<K>(value);
            if (Head == null)
            {
                Head = elem;
                Tail = Head;
                Count++;
                return;
            }
            if (!Exists(node))
            {
                PushFront(value);
                return;
            }
            if (Exists(node.Next))
            {
                elem.Next = node.Next;
                node.Next.Prev = elem;
            }
            elem.Prev = node;
            node.Next = elem;
            Count++;
        }
        public Node<K>? FindFirst(K value)
        {
            Node<K>? elem = Head;
            while (elem != null)
            {
                if (elem.Value.Equals(value))
                {
                    return elem;
                }
                elem = elem.Next;
            }
            return null;
        }
        public bool Remove(K value)
        {
            Node<K>? elem = FindFirst(value);
            return Remove(elem);
        }
        private bool Remove(Node<K>? node)
        {
            if (node != null)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else if (node.Prev == null)
                {
                    node.Next.Prev = node.Prev;
                    Head = node.Next;
                }
                else if (node.Next == null)
                {
                    node.Prev.Next = node.Next;
                    Tail = node.Prev;
                }
                else
                {
                    node.Next.Prev = node.Prev;
                    node.Prev.Next = node.Next;
                }
                Count--;
                return true;
            }
            return false;
        }
        public CIterator<K> CreateIterator()
        {
            return new StorageIterator<K>(this);
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
    }
    public class ShapeStorage : Storage<Element>, IObservable, IObserver
    {
        
        List<IObserver> observers;
        public ShapeStorage():base()
        {
            observers = new List<IObserver>();
        }
        public void OnObjectChanged(IObservable obj)
        {
            
            DeselectAll();
            TreeHandler tmp = (TreeHandler)obj;
            CIterator<Element> i = this.CreateIterator();
            int j = 0;
            for (i.First(); !i.IsEol(); i.Next(), j++)
            {
                if (tmp.treeView.Nodes[j].BackColor == Color.Gray)
                {
                    i.GetCurrent().Select();
                   // SelectElement(i.GetCurrent());
                }
            }
            Notify();
        }
        public void DeselectAll()
        {
            CIterator <Element> i = this.CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().IsSelected)
                {
                    i.GetCurrent().Deselect();
                }
            }
        }
        public void AddObserver(IObserver obj)
        {
            observers.Add(obj);
        }
        public void Notify()
        {
            foreach (IObserver obj in observers)
            {
                obj.OnObjectChanged(this);
            }
        }
        public void SelectElement(Element current)
        {
            current.Select();
            Notify();
        }
        public void DeselectElement(Element current)
        {
            current.Deselect();
            Notify();
        }
        public new bool Remove(Element value)
        {
            bool IsRemoved = base.Remove(value);
            value.observable.Clear();
            value.observer.Clear();
            CIterator<Element> i = CreateIterator();
            for (i.First(); !i.IsEol(); i.Next())
            {
                if (i.GetCurrent().observable.IsObserver(value))
                {
                    i.GetCurrent().observable.RemoveObserver(value);
                }
            }
            value.observer.Clear();
            if (IsRemoved)
                Notify();
            return IsRemoved;
        }

        public new void PushBack(Element value)
        {
            base.PushBack(value);
            Notify();
        }
        public new void InsertAfter(Element value, Node<Element>? node)
        {
            base.PushBack(value);
            Notify();
        }
        public void LoadFigures(StreamReader reader, FigureFactory factory)
        {
            Element? curr = null;
            string? current_figure;
            int counter = 0;

            counter = Convert.ToInt32(reader.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                current_figure = reader.ReadLine();
                curr = factory.CreateFigure(current_figure);
                if (curr != null)
                {
                    curr.Load(reader, factory);
                    PushBack(curr);
                }
            }
            Notify();
        }

    }
}
