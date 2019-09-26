using System.Diagnostics;
namespace MiniDot
{
    public class GitHelper
    {
        string BaseRepoUrl { get; set; }
        string WorkingDirectory { get; set; }
        public GitHelper(string baseRepoUrl, string workingDirectory)
        {
            BaseRepoUrl = baseRepoUrl;
            WorkingDirectory = workingDirectory;
        }

        public void CloneRepo()
        {
            string cloneCommand = string.Format(Constants.GIT_CLONE_COMMAND, BaseRepoUrl, WorkingDirectory);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Constants.GIT_BASE, cloneCommand)
            {
                UseShellExecute = false
            };
            process.Start();
            process.WaitForExit();
        }
    }
}