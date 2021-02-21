using System;
using System.Security.Cryptography.X509Certificates;

namespace ImplementingStackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            CustomStack stack = new CustomStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Console.WriteLine(stack .Peck());
            stack.ForEach(x => Console.WriteLine(x));
            
        }
    }
}
