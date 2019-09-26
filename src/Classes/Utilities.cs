using System;
using System.IO;
namespace MiniDot
{
    public class Utilities
    {
        static string[] ALPHANUMERIC_CHARACTERS = new string[] {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        public static string GenerateHash(int length = 32)
        {
            string newHash = "";
            Random random = new Random();
            for (int index = 0; index < length; index++)
            {
                newHash += ALPHANUMERIC_CHARACTERS[random.Next(0, ALPHANUMERIC_CHARACTERS.Length - 1)];
            };
            return newHash;
        }

        public static string GetMiniDotDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".minidot");
        }
    }
}