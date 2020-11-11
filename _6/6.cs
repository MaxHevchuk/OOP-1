using System;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    class Array
    {
        private int row, column;
        private int[][] array;

        public Array(int row, int column)
        {
            this.row = row;
            this.column = column;
            array = new int[row][];
        }

        public int[][] GenerateArray()
        {
            Random random = new Random();
            for (int line = 0; line < row; line++)
            {
                array[line] = new int[column];
                for (int element = 0; element < column; element++)
                    array[line][element] = random.Next(1, 41);
            }

            return array;
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
                        indexes.Add(new int[2]{line, element});
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
                Dictionary<int, int> dictInDict =
                        new Dictionary<int, int>()
                        {
                            [minElem] = System.Array.IndexOf(array, minElem)
                        }
                    ;

                dict.Add(line, dictInDict);
            }

            return dict;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("");
        }
    }
}