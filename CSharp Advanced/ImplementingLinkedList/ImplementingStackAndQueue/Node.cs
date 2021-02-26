using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackAndQueue
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public Node NextNode { get; set; }
        public Node PreviousNode { get; set; }
        public int Value { get; set; }
    }
}
