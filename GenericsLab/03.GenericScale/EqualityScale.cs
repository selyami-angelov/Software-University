using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericScale
{
    public class EqualityScale<T> where T:IComparable
    {
        public T Left { get; set; }
        public T Right { get; set; }

        public EqualityScale(T left,T right)
        {
            Left = left;
            Right = right;
        }

        public bool AreEqual()
        {
            if (Left.CompareTo(Right) == 0)
            {
                return true;
            }

            return false;
        }

    }
}
