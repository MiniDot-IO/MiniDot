namespace MiniDot
{
    public static class Constants
    {
        // General
        public const string MINIDOT_URL = "https://minidot.io/";

        // Working Directory
        public const string WORKING_DIRECTORY_NAME = "_minidot";
        public const string OUTPUT_BUILD_DIRECTORY = "minidot-build";

        // Git Commands
        public const string GIT_BASE = "git";
        public const string GIT_CLONE_COMMAND = "clone {0} {1}";

        // MSBuild Commands
        public const string MSBUILD_BASE = "msbuild";
        public const string MSBUILD_BUILD_NAMED_PROJECT = "{0} -restore -property:OutDir={1};AssemblyName={2}";
        public const string MSBUILD_BUILD_PROJECT = "{0} -restore -property:OutDir={1}";
    }
}