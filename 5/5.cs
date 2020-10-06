using System;
using System.IO;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathX = @"C:\Users\maxhe\source\repos\OOP\5\src\x.txt";
            //string pathY = @".\src\y.txt";
            //string pathZ = @".\src\z.txt";

            var x = File.ReadAllLines(pathX);
            Console.WriteLine(x.GetType());
            Console.WriteLine();
            //List<int> x = new List<int>[];
            //List<int> y = new List<int>[];
            //List<int> z = new List<int>[];
        }
    }
}
