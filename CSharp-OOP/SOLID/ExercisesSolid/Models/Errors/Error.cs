

using ExercisesSolid.Models.Contracts;
using ExercisesSolid.Models.Contracts.Enumerations;

using System;

namespace ExercisesSolid.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime,string message,Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }
        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public Level Level { get; private set; }
    }
}
