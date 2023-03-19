using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


//namespace MyNamespace
//{
    public class Node<T>
    {
        internal T value;
        internal Node<T>? next;
        internal Node<T>? prev;

        public T Value
        { 
            get { return value; }
            set { this.value = value; }
        }
        public Node<T>? Next
        {
            get { return next; }
        }
        public Node<T>? Prev
        {
            get { return prev; }
        }
        public Node(T value)
        {
            Value = value;
            next = null;
            prev = null;
            //Console.WriteLine("Конструктор ноды");
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
           // Console.WriteLine("Конструктор хранилища");
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
                Tail.next = new Node<K>(value);
                Tail.Next.prev = Tail;
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
                Head.prev = new Node<K>(value);
                Head.prev.next = Head;
                Head = Head.Prev;
                Count++;
            }
        }
        public bool Exists(Node<K>? node)
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
            if(Exists(node.Next))
            {
                elem.next = node.Next;
                node.next.prev = elem;
            }
            elem.prev = node;
            node.next = elem;
            Count++;
        }
        public Node<K>? FindFirst(K value)
        {
            Node<K>? elem = Head;
            while (elem != null)
            {
                if(elem.Value.Equals(value))
                {
                    return elem;
                }
                elem = elem.next;
            }
            return null;
        }
        public Node<K>? FindLast(K value)
        {
            Node<K>? elem = Tail;
            while (elem != null)
            {
                if (elem.Value.Equals(value))
                {
                    return elem;
                }
                elem = elem.prev;
            }
            return null;
        }
        public bool Remove(K value)
        {
            Node<K>? elem = FindFirst(value);
            return Remove(elem);
        }
        public bool Remove(Node<K>? node)
        {
            if (node != null)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else if (node.prev == null)
                {
                    node.next.prev = node.prev;
                    Head = node.next;
                }
                else if (node.next == null)
                {
                    node.prev.next = node.next;
                    Tail = node.prev;
                }
                else
                {
                    node.next.prev = node.prev;
                    node.prev.next = node.next;
                }
                Count--;
                return true;
            }
            return false;
        }
    }
//}
