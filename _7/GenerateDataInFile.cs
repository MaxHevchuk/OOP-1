using System;
using System.IO;
using System.Linq;

namespace _7
{
    public class GenerateDataInFile
    {
        public static void Run()
        {
            string path = @"..\..\..\src\data.txt";
            Random rand = new Random();
            string[] data = new string[Variables.DaysInMonth];
            for (int i = 0; i < Variables.DaysInMonth; i++)
            {
                int[] random = new int[5];
                for (int j = 0; j < 4; j++)
                {
                    random[j] = rand.Next(1, 21);
                }

                random[4] = rand.Next(1, 9);
                data[i] = String.Join(" ", random.Select(x => Convert.ToString(x)));
            }

            File.WriteAllLines(path, data);
        }
    }
}