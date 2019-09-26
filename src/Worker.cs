using System;
using System.IO;
namespace MiniDot
{
    public class Worker
    {
        string CurrentDirectoryBase { get; set; }
        string CurrentWorkingDirectoryName { get; set; }
        GitHelper gitHelper { get; set; }
        Builder builder { get; set; }
        ConfigModel Configuration { get; set; }
        public Worker(string projectLocation)
        {
            CurrentDirectoryBase = Path.GetFullPath(projectLocation);

            // Create the configuration reader
            Configuration = new ConfigReader(projectLocation).Configuration;

            // Create our working folder for this build
            CreateWorkingDirectory();

            // Create a new GitHelper class
            gitHelper = new GitHelper(Configuration.BaseRepoUrl, CurrentWorkingDirectoryName);

            // Create a new Builder class
            builder = new Builder(CurrentDirectoryBase, Configuration.SourceFile, Path.Combine(CurrentWorkingDirectoryName, "minidot-build"));
        }

        public void RunWorker()
        {
            // Clone the base repo
            gitHelper.CloneRepo();

            // Attempt to build our project ready for combining with the base
            builder.Build();
        }

        void CreateWorkingDirectory()
        {
            string workerDirectoryBase = Path.Combine(CurrentDirectoryBase, Constants.WORKING_DIRECTORY_NAME);
            if (!Directory.Exists(workerDirectoryBase))
            {
                Directory.CreateDirectory(workerDirectoryBase);
            }

            string workingDirectoryTempName = Path.Combine(workerDirectoryBase, Configuration.ProjectName + "-" + Utilities.GenerateHash());

            if (Directory.Exists(workingDirectoryTempName))
            {
                Directory.Delete(workingDirectoryTempName);
            }

            Directory.CreateDirectory(workingDirectoryTempName);
            CurrentWorkingDirectoryName = Path.GetFullPath(workingDirectoryTempName);
        }
    }
}