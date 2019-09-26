using System;
using System.IO;
using CommandLine;
namespace MiniDot
{
    public class Options
    {
        // These are now set in minidot.json
        // [Option("baseRepo", Required = true, HelpText = "The git repo url to use as the base code for compiling.")]
        // public string BaseRepo { get; set; }
        // [Option("projectName", Required = false, HelpText = "The name of the project.", Default = "MyMiniDotProject")]
        // public string ProjectName { get; set; }
        [Option("projectLocation", Required = false, HelpText = "The location of the project files to compile.", Default = "")]
        public string ProjectLocation { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(options =>
            {
                if (options.ProjectLocation == "") options.ProjectLocation = Environment.CurrentDirectory;

                if (!File.Exists(Path.Combine(options.ProjectLocation, "minidot.json")))
                {
                    Console.WriteLine("Error! Could not find minidot.json in this directory. MiniDot cannot run.");
                    return;
                }

                Worker worker = new Worker(options.ProjectLocation);
                worker.RunWorker();
            });
        }
    }
}
