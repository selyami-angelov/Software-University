

using ExercisesSolid.Models.Contracts.Enumerations;

using System;

namespace ExercisesSolid.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }
    }
}
