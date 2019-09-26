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
        SourceConfigModel SourceConfiguration { get; set; }
        BaseConfigModel BaseConfiguration { get; set; }
        public Worker(string projectLocation)
        {
            CurrentDirectoryBase = Path.GetFullPath(projectLocation);

            // Create the configuration reader
            SourceConfiguration = new ConfigReader().ReadSourceConfig(projectLocation);

            // Create our working folder for this build
            CreateWorkingDirectory();

            // Create a new GitHelper class
            gitHelper = new GitHelper(SourceConfiguration.BaseRepoUrl, CurrentWorkingDirectoryName);
        }

        public void RunWorker()
        {
            // Clone the base repo
            gitHelper.CloneRepo();

            // Read our base config
            BaseConfiguration = new ConfigReader().ReadBaseConfig(CurrentWorkingDirectoryName);

            // Create a new Builder class
            builder = new Builder(CurrentDirectoryBase, CurrentWorkingDirectoryName, BaseConfiguration.BaseSourceFile, SourceConfiguration.SourceFile, Path.Combine(CurrentWorkingDirectoryName, "minidot-build"));

            // Attempt to build our source ready for combining with the base
            builder.BuildSource();

            // Attempt to build our base
            builder.BuildBase();
        }

        void CreateWorkingDirectory()
        {
            string workerDirectoryBase = Path.Combine(CurrentDirectoryBase, Constants.WORKING_DIRECTORY_NAME);
            if (!Directory.Exists(workerDirectoryBase))
            {
                Directory.CreateDirectory(workerDirectoryBase);
            }

            string workingDirectoryTempName = Path.Combine(workerDirectoryBase, SourceConfiguration.ProjectName + "-" + Utilities.GenerateHash());

            if (Directory.Exists(workingDirectoryTempName))
            {
                Directory.Delete(workingDirectoryTempName);
            }

            Directory.CreateDirectory(workingDirectoryTempName);
            CurrentWorkingDirectoryName = Path.GetFullPath(workingDirectoryTempName);
        }
    }
}