using System;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    class Arrays
    {
        private int row, column;
        private int[][] array;

        public Arrays(int row, int column)
        {
            if (row > 0 && column > 0)
            {
                this.row = row;
                this.column = column;
                array = new int[row][];
            }
        }

        public void GenerateArray()
        {
            Random random = new Random();
            for (int line = 0; line < row; line++)
            {
                array[line] = new int[column];
                for (int element = 0; element < column; element++)
                    array[line][element] = random.Next(1, 41);
            }
        }

        public Dictionary<int, List<int[]>> FindKey(int key)
        {
            // [[2, 1, 1]
            //  [3, 4, 5]
            //  [1, 7, 8]]
            // dict(key, list(index[])) ==> dict(1, list([0, 1], [0, 2], [2, 0]))

            List<int[]> indexes = new List<int[]>();
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            for (int line = 0; line < row; line++)
            {
                for (int element = 0; element < column; element++)
                {
                    if (array[line][element] == key)
                    {
                        indexes.Add(new[] {line, element});
                    }
                }
            }

            if (indexes.Count > 0)
            {
                dict.Add(key, indexes);
            }

            return dict;
        }

        public Dictionary<string, int>[] FindMinElementInLine()
        {
            Dictionary<string, int>[] dict = new Dictionary<string, int>[array.Length];
            for (int line = 0; line < row; line++)
            {
                int minElem = array[line].Min();
                dict[line] = new Dictionary<string, int>()
                {
                    ["minElement"] = minElem,
                    ["row"] = line,
                    ["column"] = Array.IndexOf(array[line], minElem)
                };
            }

            return dict;
        }

        public override string ToString()
        {
            string[] arrayOfStrings = new string[array.Length];
            string[][] result = new string[array.Length][];
            for (int line = 0; line < array.Length; line++)
            {
                result[line] = new string[array[line].Length];
                for (int elem = 0; elem < array[line].Length; elem++)
                {
                    result[line][elem] = Convert.ToString(array[line][elem]);
                }

                arrayOfStrings[line] = "|" + String.Join(" ", result[line]) + "|";
            }

            return String.Join("\n", arrayOfStrings);
        }
    }

    class Program
    {
        static int ReadConsole(string word)
        {
            int num;
            while (true)
            {
                try
                {
                    Console.Write($"Введите число {word}: ");
                    num = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return num;
        }

        static void WriteFuncFindKey(Dictionary<int, List<int[]>> funcFindKey)
        {
            if (funcFindKey.Count > 0)
            {
                foreach (int key in funcFindKey.Keys)
                {
                    Console.WriteLine($"\nkey = {key}");
                    Console.WriteLine("indexes = \n{");
                    for (int i = 0; i < funcFindKey[key].Count; i++)
                    {
                        Console.WriteLine(string.Join(" ", funcFindKey[key][i]));
                    }

                    Console.WriteLine("}");
                }
            }
            else
            {
                Console.WriteLine("Не найдено ни одного ключа");
            }
        }

        static void WriteFuncFindMinElemInLine(Dictionary<string, int>[] funcFindMinElemInLine)
        {
            Console.Write("\n{");
            foreach (Dictionary<string, int> dict in funcFindMinElemInLine)
            {
                foreach (string key in dict.Keys)
                {
                    Console.WriteLine($"{key} = {dict[key]}");
                }

                Console.WriteLine("\n");
            }

            Console.Write("}");
        }

        static void Main()
        {
            Arrays array = new Arrays(ReadConsole("m"), ReadConsole("n"));
            int key = ReadConsole("key");

            array.GenerateArray();
            Console.WriteLine(array.ToString());
            WriteFuncFindKey(array.FindKey(key));
            WriteFuncFindMinElemInLine(array.FindMinElementInLine());
        }
    }
}