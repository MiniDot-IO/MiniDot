namespace MiniDot
{
    public static class Constants
    {
        // Working Directory
        public const string WORKING_DIRECTORY_NAME = "_worker";

        // Git Commands
        public const string GIT_BASE = "git";
        public const string GIT_CLONE_COMMAND = "clone {0} {1}";

        // MSBuild Commands
        public const string MSBUILD_BASE = "msbuild";
        public const string MSBUILD_BUILD_NAMED_PROJECT = "{0} -property:OutDir={1};AssemblyName={2}";
    }
}