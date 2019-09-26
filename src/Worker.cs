using System;
using System.IO;
namespace MiniDot
{
    public class Worker
    {
        string CurrentDirectoryBase { get; set; }
        string CurrentWorkingDirectoryName { get; set; }
        GitHelper gitHelper { get; set; }
        ConfigModel Configuration { get; set; }
        public Worker(string projectLocation)
        {
            CurrentDirectoryBase = Path.Combine(Environment.CurrentDirectory, Constants.WORKING_DIRECTORY_NAME);

            // Create the configuration reader
            Configuration = new ConfigReader(projectLocation).Configuration;

            CreateWorkingDirectory();

            gitHelper = new GitHelper(Configuration.BaseRepoUrl, CurrentWorkingDirectoryName);
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

            string workingDirectoryTempName = Path.Combine(CurrentDirectoryBase, Configuration.ProjectName + "-" + Utilities.GenerateHash());

            if (Directory.Exists(workingDirectoryTempName))
            {
                Directory.Delete(workingDirectoryTempName);
            }

            Directory.CreateDirectory(workingDirectoryTempName);
            CurrentWorkingDirectoryName = Path.GetFullPath(workingDirectoryTempName);
        }
    }
}