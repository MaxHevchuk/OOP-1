using System;

namespace _3
{
    class Program
    {
        /*
        private static void tryCatch(r)
        {
            
        }
        */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            int numberInt = 0;
            double numberDouble = 0;
            long numberLong = 0;

            while (true)
            {
                try
                {
                    Console.Write("Введите число int: ");
                    numberInt = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не верный тип данных.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Введите число double: ");
                    numberDouble = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не верный тип данных.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Введите число long: ");
                    numberLong = Convert.ToInt64(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не верный тип данных.");
                }
            }

            Console.WriteLine($"Первое число: {numberInt}\n" +
                              $"Второе число {numberDouble}\n" +
                              $"Третье число: {numberLong}");

        }
    }
}
