using System.IO;
using System.Linq;
namespace MiniDot
{
    public class CreateWorker
    {
        public int GetNumberOfTemplates(string templateDirectory)
        {
            try
            {
                // TODO: improve this to check if they are actually templates
                return new DirectoryInfo(templateDirectory).GetDirectories().Count();
            }
            catch
            {
                return 0;
            }
        }
    }
}