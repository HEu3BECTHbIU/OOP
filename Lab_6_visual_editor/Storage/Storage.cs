namespace Lab_6_visual_editor.Storage
{
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
            public Node<K>? Head { get; private set; }
            public Node<K>? Tail { get; private set; }
            public int Count { get; private set; }
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
                    Console.WriteLine("Inserting After null, error");
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
            private Node<K>? FindFirst(K value)
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
        }
}
