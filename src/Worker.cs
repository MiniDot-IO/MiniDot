using System;
using System.IO;
namespace MiniDot
{
    public class Worker
    {
        string CurrentDirectoryBase { get; set; }
        string CurrentWorkingDirectoryName { get; set; }
        string BaseRepoUrl { get; set; }
        string ProjectName { get; set; }
        GitHelper gitHelper { get; set; }
        public Worker(string baseUrl, string projectName)
        {
            CurrentDirectoryBase = Path.Combine(Environment.CurrentDirectory, Constants.WORKING_DIRECTORY_NAME);
            BaseRepoUrl = baseUrl;
            ProjectName = projectName;

            CreateWorkingDirectory();

            gitHelper = new GitHelper(BaseRepoUrl, CurrentWorkingDirectoryName);
        }

        public void RunWorker()
        {
            // Clone the base repo
            gitHelper.CloneRepo();
        }

        void CreateWorkingDirectory()
        {
            if (!Directory.Exists(CurrentDirectoryBase))
            {
                Directory.CreateDirectory(CurrentDirectoryBase);
            }

            string workingDirectoryTempName = Path.Combine(CurrentDirectoryBase, ProjectName + "-" + Utilities.GenerateHash());

            if (Directory.Exists(workingDirectoryTempName))
            {
                Directory.Delete(workingDirectoryTempName);
            }

            Directory.CreateDirectory(workingDirectoryTempName);
            CurrentWorkingDirectoryName = Path.GetFullPath(workingDirectoryTempName);
        }
    }
}