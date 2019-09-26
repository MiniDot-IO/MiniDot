using System;
using System.IO;
using CommandLine;
namespace MiniDot
{
    [Verb("build", HelpText = "Builds a source project onto a base.")]
    public class BuildOptions
    {
        [Option("projectLocation", Required = false, HelpText = "The location of the project files to compile.", Default = "")]
        public string ProjectLocation { get; set; }
    }

    [Verb("install", HelpText = "Installs the MiniDot templates that can be used to create projects.")]
    public class InstallOptions
    {

    }

    class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<BuildOptions, InstallOptions>(args).MapResult(
                (BuildOptions options) => Build(options),
                (InstallOptions options) => Install(options),
                err => 1);
        }

        static int Build(BuildOptions options)
        {
            if (options.ProjectLocation == "") options.ProjectLocation = Environment.CurrentDirectory;

            if (!File.Exists(Path.Combine(options.ProjectLocation, "minidot.json")))
            {
                Console.WriteLine("Error! Could not find minidot.json in this directory. MiniDot cannot run.");
                return 1;
            }
            else
            {
                BuildWorker worker = new BuildWorker(options.ProjectLocation);
                worker.RunWorker();
                return 0;
            }
        }

        static int Install(InstallOptions options)
        {
            string miniDotDirectory = Utilities.GetMiniDotDirectory();

            return 0;
        }
    }
}
