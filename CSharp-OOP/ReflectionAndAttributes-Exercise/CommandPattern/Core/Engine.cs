﻿
using CommandPattern.Core.Contracts;

using System;

namespace CommandPattern.Core.NewFolder
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(this.commandInterpreter.Read(input));

            }

        }
    }
}
