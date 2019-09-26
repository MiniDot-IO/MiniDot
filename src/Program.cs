using System;
using CommandLine;
namespace MiniDot
{
    public class Options
    {
        [Option("baseRepo", Required = true, HelpText = "The git repo url to use as the base code for compiling.")]
        public string BaseRepo { get; set; }

        [Option("projectName", Required = false, HelpText = "The name of the project.", Default = "MyMiniDotProject")]
        public string ProjectName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(options =>
                  {
                      Worker worker = new Worker();
                      worker.CreateWorkingDirectory(options.ProjectName);
                  });
        }
    }
}
