using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    class Stack<T>: IEnumerable<T>
    {
        private List<T> elements = new List<T>();
        private int index;

        public Stack()
        {
            this.index = elements.Count - 1;
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                elements.Add(item);
                index++;
            }
        }
        public void Pop()
        {
            if (index<0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                elements.RemoveAt(index);
                index--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = index; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
