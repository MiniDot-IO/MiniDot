using System.Diagnostics;
namespace MiniDot
{
    public class Builder
    {
        string SourceWorkingDirectory { get; set; }
        string SourceFile { get; set; }
        string BaseWorkingDirectory { get; set; }
        string BaseSourceFile { get; set; }
        string OutputDirectory { get; set; }
        public Builder(string sourceWorkingDirectory, string baseWorkingDirectory, string baseSourceFile, string sourceFile, string outputDirectory)
        {
            SourceWorkingDirectory = sourceWorkingDirectory;
            BaseWorkingDirectory = baseWorkingDirectory;
            BaseSourceFile = baseSourceFile;
            SourceFile = sourceFile;
            OutputDirectory = outputDirectory;
        }

        public void BuildSource(string outputAssemblyName = "MiniDotBootstrap")
        {
            // TODO: refactor this logic
            string buildCommand = string.Format(Constants.MSBUILD_BUILD_NAMED_PROJECT, System.IO.Path.Combine(SourceWorkingDirectory, SourceFile), OutputDirectory, outputAssemblyName);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Constants.MSBUILD_BASE, buildCommand)
            {
                UseShellExecute = false
            };
            process.Start();
            process.WaitForExit();
        }

        public void BuildBase()
        {
            // TODO: refactor this logic
            string buildCommand = string.Format(Constants.MSBUILD_BUILD_PROJECT, System.IO.Path.Combine(BaseWorkingDirectory, BaseSourceFile), OutputDirectory);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Constants.MSBUILD_BASE, buildCommand)
            {
                UseShellExecute = false
            };
            process.Start();
            process.WaitForExit();
        }
    }
}