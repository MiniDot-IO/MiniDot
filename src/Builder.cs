using System.Diagnostics;
namespace MiniDot
{
    public class Builder
    {
        string WorkingDirectory { get; set; }
        string SourceFile { get; set; }
        string OutputDirectory { get; set; }
        string OutputAssemblyName { get; set; }
        public Builder(string workingDirectory, string sourceFile, string outputDirectory, string outputAssemblyName = "MiniDotBootstrap")
        {
            WorkingDirectory = workingDirectory;
            SourceFile = sourceFile;
            OutputDirectory = outputDirectory;
            OutputAssemblyName = outputAssemblyName;
        }

        public void Build()
        {
            // TODO: refactor this logic
            string buildCommand = string.Format(Constants.MSBUILD_BUILD_NAMED_PROJECT, System.IO.Path.Combine(WorkingDirectory, SourceFile), OutputDirectory, OutputAssemblyName);
            System.Console.WriteLine(buildCommand);
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