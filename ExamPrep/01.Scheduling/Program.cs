using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Peek() != taskToKill)
            {
                int task = tasks.Pop();
                int thread = threads.Dequeue();

                if (thread < task)
                {
                    tasks.Push(task);
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
