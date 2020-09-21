using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вес: ");
            float weight = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите рост: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Вы женаты? true or false: ");
            bool isMarried = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Введите дату: ");
            object obj = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine($"Имя: {name}\n" +
                $"Возраст: {age}\n" +
                $"Вес: {weight}\n" +
                $"Рост: {height}\n" +
                $"Женаты: {isMarried}\n" +
                $"Дата: {obj}");




        }
    }
}
