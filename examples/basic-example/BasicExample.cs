using System;
namespace MyMiniDotProject
{
    public class BasicExample
    {
        public void PrintNumbers()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Number is {i.ToString()}");
            }
        }
    }
}