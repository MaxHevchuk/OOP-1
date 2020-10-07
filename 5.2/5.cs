using System;
using System.IO;

namespace _5
{
    class Program
    {
        private static double[] ReadFileAndGetIntArray(string path)
        {
            string[] text = File.ReadAllText(path).Split(", ");
            double[] array = new double[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    array[i] = Convert.ToDouble(text[i]);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return array;
        }

        private static void NegativeToSquare(ref double[] x)
        {
            for (int i = 0; i < x.Length; i++)
                x[i] = (x[i] < 0) ? x[i] * x[i] : x[i];
        }

        private static void Transformation(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < x.Length; i++)
                z[i] = x[i] + y[i];
        }
        static void Main(string[] args)
        {
            string pathX = @"C:\Users\maxhe\source\repos\OOP\5.2\src\x.txt";
            string pathY = @"C:\Users\maxhe\source\repos\OOP\5.2\src\y.txt";
            string pathZ = @"C:\Users\maxhe\source\repos\OOP\5.2\src\z.txt";

            double[] x = ReadFileAndGetIntArray(pathX);
            double[] y = ReadFileAndGetIntArray(pathY);
            double[] z = new double[x.Length];
            NegativeToSquare(ref x);
            Transformation(x, y, ref z);

            Console.WriteLine(string.Join(' ', z));
        }
    }
}
