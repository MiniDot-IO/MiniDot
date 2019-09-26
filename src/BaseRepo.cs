namespace MiniDot
{
    public class BaseRepo
    {
        string BaseRepoUrl { get; set; }
        public BaseRepo(string baseRepoUrl)
        {
            BaseRepoUrl = baseRepoUrl;
        }
    }
}