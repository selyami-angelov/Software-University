using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            Console.WriteLine(string.Join(Environment.NewLine,list.ToArray()));

            //list.AddFirst(1);
            //list.AddFirst(2);
            //list.AddFirst(3);
            //list.AddFirst(4);
            //list.AddFirst(5);

            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.Head.Value);
            //Console.WriteLine(list.Head.NextNode.Value);
        }
    }
}
