using System;

namespace Scarecrow.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new Host(new Uri("localhost:10010"));
            host.Start();
            Console.WriteLine("Hello World!");
        }
    }
}
