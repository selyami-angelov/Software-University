
using System.Collections.Generic;

namespace ExercisesSolid.Models.Contracts
{
    public interface ILogger
    {
        public IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);

    }
}
