using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImplementingStackAndQueue
{
    public class CustomStack
    {
        private int[] items;
        private const int InitialCapacity = 2;
        private int count;
        public CustomStack()
        {
            items = new int[InitialCapacity];
            count = 0;
        }

        public void Push(int item)
        {
            if (items.Length==count)
            {
                Resize();
            }
            items[count] = item;
            count++;
        }

        public int Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int popedItem = items[count-1];
            items[count-1] = default(int);
            count--;
            Shrink();
            return popedItem;
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

        public void Shrink()
        {
            if (items.Length / count == 4)
            {
                int[] copy = new int[count * 2];

                for (int i = 0; i < count; i++)
                {
                    copy[i] = items[i];
                }

                items = copy;
            }
        }

        public int Peck()
        {
            return items[count - 1];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

    }
}
