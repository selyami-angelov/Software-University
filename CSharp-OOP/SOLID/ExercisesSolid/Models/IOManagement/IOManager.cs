

using ExercisesSolid.Models.Contracts;

using System.IO;

namespace ExercisesSolid.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string folderName;
        private string fileName;

        public IOManager()
        {
            this.currentPath = this.GetCurrentDirectoryPath();
        }

        public IOManager(string folderName,string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }
        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public void EnsureDirectoyAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectoryPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
