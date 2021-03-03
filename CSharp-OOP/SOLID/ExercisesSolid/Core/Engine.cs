using ExercisesSolid.Core.Contracts;
using ExercisesSolid.Factories;
using ExercisesSolid.Models.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercisesSolid.Core
{
    public class Engine : IEngine
    {
        ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string level = inputArg[0];
                string dateTime = inputArg[1];
                string message = inputArg[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTime, message, level);
                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
