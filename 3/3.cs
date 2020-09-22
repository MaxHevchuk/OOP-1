using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            int numberInt = 0;
            double numberDouble = 0;
            long numberLong = 0;

            bool exit = false;
            while (!exit)
            {
                exit = true;
                try
                {
                    Console.Write("Введите число #1: ");
                    numberInt = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не верный тип данных.");
                    exit = false;
                }                
            }

            exit = false;
            while (!exit)
            {
                exit = true;
                try
                {
                    Console.Write("Введите число #2: ");
                    numberDouble = Convert.ToDouble(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не верный тип данных.");
                    exit = false;
                }
            }
            
            exit = false;
            while (!exit)
            {
                exit = true;
                try
                {
                    Console.Write("Введите число #3: ");
                    numberLong = Convert.ToInt64(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не верный тип данных.");
                    exit = false;
                }
            }

            Console.WriteLine($"Первое число: {numberInt}\n" +
                $"Второе число {numberDouble}\n" +
                $"Третье число: {numberLong}");

        }
    }
}
