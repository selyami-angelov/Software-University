using Microsoft.VisualBasic;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>: IEnumerable
    {
        private List<T> elements = new List<T>();
        private int index = 0;

        public ListyIterator(params T[] elements)
        {
            this.elements = elements.ToList();
        }   

        public bool Move()
        {
            if (index+1 < elements.Count)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index + 1 < elements.Count)
            {
                return true;
            }
            return false;
        }

        public T Print()
        {
            if (!elements.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return elements[index];
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
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
