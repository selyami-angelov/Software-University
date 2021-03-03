

namespace ExercisesSolid.Models.Contracts
{
    public interface IIOManager
    {
        public string CurrentFilePath { get;}
        public string CurrentDirectoryPath { get; }

        public string GetCurrentDirectoryPath();
        public void EnsureDirectoyAndFileExist();
    }
}
