﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string num)
        {
            Console.WriteLine($"Dialing... {num}");
        }
    }
}
