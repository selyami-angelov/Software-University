using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    class GenericList<T> where T:IComparable
    {
        public List<T> Elements { get; set; } = new List<T>();
        public GenericList(List<T> elements)
        {
            Elements = elements;
        }

        public void Swap(int firsIndex, int secIndex)
        {
            T element = Elements[firsIndex];
            Elements[firsIndex] = Elements[secIndex];
            Elements[secIndex] = element;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var elem in Elements)
            {
                stringBuilder.AppendLine($"{elem.GetType()}: {elem}");
            }
            return stringBuilder.ToString().Trim();
        }

        public int Compare(List<T> list,T element)
        {
            int count = 0;

            foreach (var elem in list)
            {
                if (elem.CompareTo(element)>0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
