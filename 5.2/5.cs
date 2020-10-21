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
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
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
            string pathX = @"..\..\..\src\x.txt";
            string pathY = @"..\..\..\src\y.txt";

            double[] x = ReadFileAndGetIntArray(pathX);
            double[] y = ReadFileAndGetIntArray(pathY);
            double[] z = new double[x.Length];
            NegativeToSquare(ref x);
            Transformation(x, y, ref z);

            Console.WriteLine(string.Join(' ', z));
        }
    }
}
