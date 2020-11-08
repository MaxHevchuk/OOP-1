using System;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    class Arrays
    {
        private int rows;
        private int columns;
        private int[,] array;


        public string Array => String.Join(" ", array.Cast<int>());

        public Arrays(int m, int n)
        {
            if (m >= 0 && n >= 0 && m == n)
            {
                this.rows = m;
                this.columns = n;

                GenerateArray(ref array);
            }
            else
            {
                Console.WriteLine("Числа не должны быть меньше нуля и они должны быть равными");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void GenerateArray(ref int[,] arr)
        {
            arr = new int[rows, columns];
            var random = new Random();
            for (int line = 0; line < rows; line++)
            {
                for (int element = 0; element < columns; element++)
                {
                    arr[line, element] = random.Next(1, 41);
                }
            }
        }

        public List<int> FindElement(int key)
        {
            List<int> result = new List<int>();
            for (int line = 0; line < rows; line++)
            {
                for (int element = 0; element < columns; element++)
                {
                    if (array[line, element].Equals(key))
                    {
                        result.Add(array[line, element]);
                    }
                }
            }

            return result;
        }

        public Dictionary<int, int[]> GetMinInEachLine()
        {
            Dictionary<int, int[]> result = new Dictionary<int, int[]>();
            int min = Int32.MaxValue;
            // int[] index = { };
            int line_index = 0;
            int elem_index = 0;

            for (int line = 0; line < rows; line++)
            {
                for (int element = 0; element < columns; element++)
                {
                    if (min > array[line, element])
                    {
                        min = array[line, element];
                        line_index = line;
                        elem_index = element;
                        // index = new[] {line, element};
                    }
                }

                result.Add(line_index, new[] {min, elem_index});
                min = Int32.MaxValue;
            }

            return result;
        }
    }

    class Program
    {
        private void TryCatch(ref int num)
        {
            try
            {
                num = Convert.ToInt32(Console.Read());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        static void Main()
        {
            int m = 0;
            int n = 0;
            int key = 1;

            try
            {
                Console.Write("Введите число m: ");
                m = Convert.ToInt32(Console.Read());
                Console.Write("Введите число n: ");
                n = Convert.ToInt32(Console.Read());
                Console.WriteLine("Введите ключ: ");
                key = Convert.ToInt32(Console.Read());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            Arrays arrayObj = new Arrays(3, 3);
            Console.WriteLine(arrayObj.Array);
            List<int> list_arr = arrayObj.FindElement(key);
            list_arr.ForEach(i => Console.Write("{0}\t", i));
            Dictionary<int, int[]> dict = arrayObj.GetMinInEachLine();
            dict.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
        }
    }
}