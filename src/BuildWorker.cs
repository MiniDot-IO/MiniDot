using System;
using System.IO;
namespace MiniDot
{
    public class BuildWorker
    {
        string SourceDirectory { get; set; }
        string WorkingDirectory { get; set; }
        GitHelper gitHelper { get; set; }
        Builder builder { get; set; }
        SourceConfigModel SourceConfiguration { get; set; }
        BaseConfigModel BaseConfiguration { get; set; }
        public Worker(string projectLocation)
        {
            SourceDirectory = Path.GetFullPath(projectLocation);

            // Create the configuration reader
            SourceConfiguration = new ConfigReader().ReadSourceConfig(projectLocation);

            // Create our working folder for this build
            CreateWorkingDirectory();

            // Create a new GitHelper class
            gitHelper = new GitHelper(SourceConfiguration.BaseRepoUrl, WorkingDirectory);
        }

        public void RunWorker()
        {
            // Clone the base repo
            gitHelper.CloneRepo();

            // Read our base config
            BaseConfiguration = new ConfigReader().ReadBaseConfig(WorkingDirectory);

            // Create a new Builder class
            builder = new Builder(SourceDirectory, WorkingDirectory, BaseConfiguration.BaseSourceFile, SourceConfiguration.SourceFile, Path.Combine(WorkingDirectory, Constants.OUTPUT_BUILD_DIRECTORY));

            // Attempt to build our source ready for combining with the base
            builder.BuildSource();

            // Attempt to build our base
            builder.BuildBase(SourceConfiguration.ProjectName);
        }

        void CreateWorkingDirectory()
        {
            string workerDirectoryBase = Path.Combine(SourceDirectory, Constants.WORKING_DIRECTORY_NAME);
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
            WorkingDirectory = Path.GetFullPath(workingDirectoryTempName);
        }
    }
}