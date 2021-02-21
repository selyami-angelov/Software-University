using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05.StackOfStrings
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> range)
        {
            while (range.Count!=0)
            {
                this.Push(range.Pop()) ;
            }
        }
    }
}
