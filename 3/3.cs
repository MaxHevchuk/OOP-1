using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Key = ");
            bool key = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Number: ");
            uint number = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Введите пользователя: ");
            while (Console.ReadLine() == "admin" && (key || number != 0))
            {
                Console.WriteLine("Введите число: ");
                double doubleInput = Convert.ToDouble(Console.ReadLine());
                do
                {
                    Console.WriteLine("Hello World!");
                    break;
                } while (0.0 < doubleInput || doubleInput >= 10.0);
            }
        }
    }
}
