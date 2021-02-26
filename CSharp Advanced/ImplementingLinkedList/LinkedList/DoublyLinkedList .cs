using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using System.Xml;

namespace LinkedList
{
    public class DoublyLinkedList
    {

        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            var node = new ListNode(element);
            if (Count == 0)
            {
                Tail = node;
                Head = node;
            }
            else
            {
                node.NextNode = Head;
                Head.PreviousNode = node;
                Head = node;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            var node = new ListNode(element);

            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.PreviousNode = Tail;
                Tail.NextNode = node;
                Tail = node;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            int removedElement = 0;

            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else if (Count == 1)
            {
                removedElement = Head.Value;
                Tail = null;
                Head = null;
            }
            else
            {
                removedElement = Head.Value;
                Head = Head.NextNode;
            }

            Count--;
            return removedElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int item = Tail.Value;
            Tail = Tail.PreviousNode;

            if (Tail != null)
            {
                Tail.NextNode = null;
            }
            else
            {
                Head = null;
            }

            Count--;
            return item;
        }

        public void ForEach(Action<int> action)
        {
            var node = Head;

            while (node!=null)
            {
                action(node.Value);
                node = node.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[Count]; 
            var node = Head;

            for (int i = 0; i < Count; i++)
            {
                arr[i] = node.Value;
                node = node.NextNode;
            }

            return arr;
        }
       
    }
}
