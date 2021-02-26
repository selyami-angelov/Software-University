using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace ImplementingStackAndQueue
{
    public class LinkedList
    {
        private int[] items;
        private const int InitialCapacity = 2;

        public LinkedList()
        {
            items = new int[InitialCapacity];
        }
        //public Node Head { get; set; }
        //public Node Tail { get; set; }
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index]=value;
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = items[index];
            items[index] = 0;
            Count--;

            Shift(index);
            Shrink();
            return item;
        }

        
        public void Shift(int index)
        {
            if (index < Count+1)
            {
                for (int i = index + 1; i < Count+1; i++)
                {
                    items[i - 1] = items[i];
                }

                items[Count+1] = 0;
            }
            
        }

        public void Shrink()
        {
            if (items.Length/Count == 4)
            {
                int[] copy = new int[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    copy[i] = items[i];
                }

                items = copy;
            }
        }

        public void Insert(int index,int item)
        {
            if (index >= Count || index <0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }

            ShiftToRight(index);
            items[index] = item;
            Count++;

        }

        public void ShiftToRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }

        public bool Containts(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            } 

            return false;
        }

        public void Swap(int firstIndex,int secIndex)
        {
            if (firstIndex>= Count || firstIndex < 0 || secIndex >= Count || secIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int element = items[firstIndex];
            items[firstIndex] = items[secIndex];
            items[secIndex] = element;
        }

        
    }
}
