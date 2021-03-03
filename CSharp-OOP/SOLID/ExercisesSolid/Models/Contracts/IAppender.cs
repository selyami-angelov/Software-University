

using ExercisesSolid.Models.Contracts.Enumerations;

namespace ExercisesSolid.Models.Contracts
{
    public interface IAppender
    {
        public long MessagesAppended { get; }
        public ILayout Layout { get; }
        public Level Level { get; }
        public void Append(IError error);
    }
}
