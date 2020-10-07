using System;
using System.IO;
using System.Linq;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathX = @"C:\Users\maxhe\source\repos\OOP\5.2\src\x.txt";
            string pathY = @"C:\Users\maxhe\source\repos\OOP\5.2\src\y.txt";
            string pathZ = @"C:\Users\maxhe\source\repos\OOP\5.2\src\z.txt";


            Console.Write("Введите количество элементов массива: ");
            int n = 0;
            try { n = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine(e.Message); }

            int[] X = new int[n];
            int[] Y = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                X[i] = rand.Next(-50, 50);
                Y[i] = rand.Next(-50, 50);
            }
            File.WriteAllText(pathX, string.Empty);
            File.WriteAllText(pathX, string.Join(" ", X));
            File.WriteAllText(pathY, string.Empty);
            File.WriteAllText(pathY, string.Join(" ", Y));


            int[] x = new int[n];
            int[] y = new int[n];
            int[] z = new int[n];
            try
            {
                x = File.ReadAllText(pathX).ToString().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                y = File.ReadAllText(pathY).ToString().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            for (int i = 0; i < n; i++)
            {
                x[i] = (x[i] < 0) ? x[i] * x[i] : x[i];

                z[i] = x[i] + y[i];
            }
            File.WriteAllText(pathZ, string.Empty);
            File.WriteAllText(pathZ, string.Join(" ", z));
        }
    }
}
