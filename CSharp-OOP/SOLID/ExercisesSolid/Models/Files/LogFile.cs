using System;
using System.IO;
using System.Linq;

using ExercisesSolid.Models.Contracts;
using ExercisesSolid.Models.IOManagement;
using ExercisesSolid.Models.Contracts.Enumerations;
using System.Globalization;
using ExercisesSolid.Common;

namespace ExercisesSolid.Models
{
    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoyAndFileExist();
        }

        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format,
                dateTime.ToString(GlobalConstants.DATE_FORMAT,
                CultureInfo.InvariantCulture),
                message,
                level.ToString());

            return formattedMessage.ToString().TrimEnd();
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text.Where(char.IsLetter).Sum(x => x);

            return size;
        }
    }
}
