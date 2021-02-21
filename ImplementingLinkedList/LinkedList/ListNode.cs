﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class ListNode
    {
        public ListNode(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public ListNode NextNode { get; set; }
        public ListNode PreviousNode { get; set; }

    }
}
