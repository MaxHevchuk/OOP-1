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
            this.row = row;
            this.column = column;
            array = new int[row][];
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
            List<int[]> indexes = new List<int[]>();
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            for (int line = 0; line < row; line++)
            {
                for (int element = 0; element < column; element++)
                {
                    if (array[line][element] == key)
                    {
                        indexes.Add(new int[2] {line, element});
                    }
                }
            }

            dict.Add(key, indexes);
            return dict;
        }

        public Dictionary<int, Dictionary<int, int>> FindMinElementInLine()
        {
            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
            for (int line = 0; line < row; line++)
            {
                int minElem = array[line].Min();
                Dictionary<int, int> dictInDict = new Dictionary<int, int>()
                {
                    [minElem] = System.Array.IndexOf(array, minElem)
                };

                dict.Add(line, dictInDict);
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

                arrayOfStrings[line] = String.Join(" ", result[line]);
            }

            return String.Join("\n", arrayOfStrings);
        }
    }

    class Program
    {
        static void Main()
        {
            Arrays array = new Arrays(3, 3);
            array.GenerateArray();
            Console.WriteLine(array.ToString());
        }
    }
}