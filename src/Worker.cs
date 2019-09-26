using System;
using System.IO;
namespace MiniDot
{
    public class Worker
    {
        string CurrentDirectoryBase = "";
        string CurrentWorkingDirectoryName = "";
        public Worker()
        {
            CurrentDirectoryBase = Path.Combine(Environment.CurrentDirectory, Constants.WORKING_DIRECTORY_NAME);
        }

        public void CreateWorkingDirectory(string projectName)
        {
            if (!Directory.Exists(CurrentDirectoryBase))
            {
                Directory.CreateDirectory(CurrentDirectoryBase);
            }

            string workingDirectoryTempName = Path.Combine(CurrentDirectoryBase, projectName + "-" + Utilities.GenerateHash());

            if (Directory.Exists(workingDirectoryTempName))
            {
                Directory.Delete(workingDirectoryTempName);
            }

            Directory.CreateDirectory(workingDirectoryTempName);
            CurrentWorkingDirectoryName = workingDirectoryTempName;
        }
    }
}