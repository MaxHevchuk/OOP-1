using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int age = 0;
            float weight =0.0f;
            double height = 0.0;
            bool isStudent = true;
            object obj = "";

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();            
                 
            Console.Write("Введите возраст: ");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели неправильный тип.");
            }
            

            Console.Write("Введите вес: ");
            try
            {
                weight = Convert.ToSingle(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели неправильный тип.");
            }
            

            Console.Write("Введите рост: ");
            try
            {
                height = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели неправильный тип.");
            }
            

            Console.Write("Вы студент? true or false: ");
            try
            {
                isStudent = Convert.ToBoolean(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели неправильный тип.");
            }
            

            Console.Write("Введите дату: ");
            try
            {
                obj = Convert.ToDateTime(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели неправильный тип.");
            }
            

            Console.WriteLine($"Имя: {name}\n" +
                $"Возраст: {age}\n" +
                $"Вес: {weight}\n" +
                $"Рост: {height}\n" +
                $"Женаты: {isStudent}\n" +
                $"Дата: {obj}");
        }
    }
}
