// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        Storage<Point> q = new Storage<Point>();
        LinkedList<Point> list = new LinkedList<Point>();
        Random rnd = new Random();
        int i = 100000;
        for (i = 100000; i >= 0; i--)
        {
            int rand = rnd.Next(0, 40);
            int j = rnd.Next(1, 3);
            if (j == 1)
            {
                q.PushBack(new Point(rand, rand));
                //list.AddLast(new Point(i, i));
            }
            else if (j == 2)
            { 
                q.PushFront(new Point(rand, rand));
               // list.AddFirst(new Point(i, i));
            }
        }
        i = 200000;
        for (i = 200000; i >= 0; i--)
        {
            int j = rnd.Next(0, 40);
            Point tmp = new Point(j, j);
            int rand = rnd.Next(1, 4);
            if (rand == 1)
            {
                if (q.Remove(tmp))
                {
                    //Console.WriteLine($"Deleting node with coord {tmp.X}, {tmp.Y}");
                }   
            }
            if (rand == 2)
            {
                Node <Point>? nd = q.FindFirst(tmp);
                //LinkedListNode<Point>? nd2 = list.Find(tmp);
                if (nd != null)
                {
                    q.InsertAfter(tmp, nd);
                    //Console.WriteLine($"Inserting node with coord {tmp.X}, {tmp.Y}");
                }
                //if (nd2 != null)
                //{
                //    list.AddAfter(nd2, tmp);
                //}
            }
            if (rand == 3)
            {
                Node<Point>? nd = q.FindFirst(tmp);
                if (nd != null)
                {
                    //nd.Value.Print();
                }
            }
        }
        Console.WriteLine($"\nList of All remaining nodes: {q.Count}\n");
        //for (Node<Point>? ob = q.Head; q.Exists(ob); ob = ob.Next)
       // {
        //    ob.Value.Print();
        //}
        //Console.WriteLine("\n FOR LIST \n");
        //for (LinkedListNode<Point>? ob = list.First; ob != null; ob = ob.Next)
       // {
        //    ob.Value.Print();
       // }
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine($"RunTime {elapsedTime}");
    }
}
class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }
    public override bool Equals(object? obj)
    {
        Point p = obj as Point;
        return X == p.X && Y == p.Y;
    }
    public void Print()
    {
        Console.WriteLine($"point with coords {X}, {Y}");
    }
}