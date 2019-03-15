using System;

namespace Scarecrow.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ScarecrowHost();
            host.Start();
            Console.WriteLine("Hello World!");
        }
    }
}
