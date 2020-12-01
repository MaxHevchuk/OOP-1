using System;
using System.Linq;

namespace _9
{
    class MyArray
    {
        private int row;
        private int column;
        private int[][] array;
        private isEqual delegateVar;

        public delegate bool isEqual(int x);

        public int[][] Array
        {
            get => array;
            set => array = value;
        }

        public isEqual DelegateVar
        {
            get => delegateVar;
            set => delegateVar = value;
        }

        public MyArray(int m, int n)
        {
            if (m > 0 && n > 0 && m == n)
            {
                row = m;
                column = n;
                array = new int[m][];
            }

            for (int i = 0; i < n; i++)
            {
                array[i] = new int[n];
            }
        }

        public void GenerateArray()
        {
            Random random = new Random();
            for (int line = 0; line < column; line++)
            {
                for (int element = 0; element < row; element++)
                {
                    array[line][element] = random.Next(1, 41);
                }
            }
        }

        public void FindKey(int key)
        {
            bool isFound = false;
            for (int line = 0; line < column; line++)
            {
                for (int element = 0; element < row; element++)
                {
                    if (array[line][element].Equals(key))
                    {
                        isFound = true;
                        Console.WriteLine($"key = {key}, indexes = [{line}, {element}]");
                    }
                }
            }

            if (!isFound) Console.WriteLine("Key not found");
        }

        public void FindMinElementInRows()
        {
            Console.WriteLine("Without filters:");
            int minElement = Int32.MaxValue;
            for (int line = 0; line < column; line++)
            {
                minElement = array[line].Min();
                Console.WriteLine($"Minimal element: {minElement}\n" +
                                  $"Indexes: [{line}; {System.Array.IndexOf(array[line], minElement)}]");
            }
        }

        public bool ConditionCheck(int x)
        {
            return x % 6 == 0;
        }

        public static void MyCalculation(int[][] array, isEqual isInFilter)
        {
            Console.WriteLine("With Filters:");
            for (int line = 0; line < array.Length; line++)
            {
                int minElement = int.MaxValue;
                int index = 0;
                for (int element = 0; element < array[line].Length; element++)
                {
                    int number = array[line][element];
                    if (number < minElement && isInFilter(number))
                    {
                        minElement = number;
                        index = element;
                    }
                }

                if (minElement == int.MaxValue)
                    Console.WriteLine($"No minimum element in line {line}");
                else
                {
                    Console.WriteLine($"Minimum value in {line} line: {minElement}");
                }
            }
        }

        public override string ToString()
        {
            string[] joinLines = new string[array.Length];
            for (int line = 0; line < array.Length; line++)
            {
                joinLines[line] = String.Join(" ", array[line]);
            }

            return String.Join("\n", joinLines);
        }
    }

    class Program
    {
        static int ReadNum(string num)
        {
            int number = 0;
            while (true)
            {
                Console.Write($"Input {num}: ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            return number;
        }

        static void Main()
        {
            MyArray myArray = new MyArray(ReadNum("m"), ReadNum("n"));
            myArray.GenerateArray();

            Console.WriteLine();

            Console.WriteLine(myArray);
            myArray.DelegateVar = myArray.ConditionCheck;

            Console.WriteLine();

            int key = ReadNum("key");
            myArray.FindKey(key);

            Console.WriteLine();

            myArray.FindMinElementInRows();

            Console.WriteLine();

            MyArray.MyCalculation(myArray.Array, myArray.DelegateVar);

            Console.WriteLine();

            MyArray.MyCalculation(myArray.Array, x => x <= 23);
        }
    }
}
