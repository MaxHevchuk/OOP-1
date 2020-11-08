/*
        Використовуючи  enum  та  масиви  вирішіть  задачу  про  стан  погоди  в минулому році. Тип погоди за день
    повинен мати наступні можливі значення (enum): 
 * не визначено (не було внесена інформація) = 1;
 * дощ = 2;
 * короткочасний дощ = 3;
 * гроза = 4;
 * сніг = 5;
 * туман = 6;
 * похмуро = 7;
 * сонячно = 8;
        Інформація про погоду за день повинна зберігатися  в  об’єкті  класа  WeatherParametersDay
 та  містить  наступну інформацію:
 * середня температура вдень;
 * середня температура вночі;
 * середній атмосферний тиск;
 * кількість опадів (мм/день);
 * тип погоди за день.
        Інформація про погоду за період повинна зберігатися в об’єкті класа WeatherDays та повинна містити масив об’єктів
    класа WeatherParametersDay в кількості (кількість днів в відповідному місяці), що відповідає варіанту. Дані повинні
    зчитуватися  з  файлу  або  вводитися  з  клавіатури.  Інформацію  яку необхідно додатково знайти вказано в 
    індивідуальному варіанті.  
 
    3) Розглядати квітень місяць, розрахувати:
 * кількість туманних днів у місяці;
 * загальну кількість днів коли був дощ або гроза;
 * середній атмосферний тиск за місяць

 */

using System;
using System.Collections.Generic;
using System.IO;

namespace _7
{
    class Variables
    {
        public static int DaysInMonth = 2;
    }

    enum TypeOfWeather
    {
        NotDefined = 1,
        Rain = 2, // **
        ShortTermRain = 3,
        Thunderstorm = 4, // **
        Snow = 5,
        Fog = 6, // *
        Gloomy = 7,
        Sunny = 8
    }

    class WeatherDays
    {
        private double[][] dataWeatherArray = new double[Variables.DaysInMonth][];
    }

    class WeatherParametersDay
    {
        private double
            averageTemperatureDay,
            averageTemperatureNight,
            averageAtmosphericPressure,
            precipitation;

        private int typeOfWeather;
    }

    class Program
    {
        private static Dictionary<string, double>[] Data(string path)
        {
            double[][] dataDays = new double[Variables.DaysInMonth][];
            string[] lines = { };

            bool exit = false;
            while (!exit)
            {
                switch (UserChoice())
                {
                    case ConsoleKey.F:
                        lines = ReadFile(path);
                        exit = true;
                        break;
                    case ConsoleKey.C:
                        ReadConsole(out lines);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nНеизвестная кнопка");
                        break;
                }
            }

            Dictionary<string, double>[] dictArray = DictArray(lines);


            // for (int line = 0; line < lines.Length; line++)
            // {
            //     string[] lineSplit = lines[line].Split();
            //     dataDays[line] = new double[lines[line].Length];
            //
            //     for (int index = 0; index < lineSplit.Length; index++)
            //     {
            //         try
            //         {
            //             dataDays[line][index] = Convert.ToDouble(lineSplit[index]);
            //         }
            //         catch (Exception ex) when (ex is InvalidCastException || ex is FormatException)
            //         {
            //             Console.WriteLine(ex.Message);
            //             System.Diagnostics.Process.GetCurrentProcess().Kill();
            //         }
            //     }
            // }

            return dictArray;
        }

        private static string[] ReadFile(string path) => File.ReadAllLines(path);

        private static void ReadConsole(out string[] lines)
        {
            Console.WriteLine("\nВведите данные для каждого дня в отдельной строке через пробел");
            lines = new string[Variables.DaysInMonth];

            for (int j = 0; j < Variables.DaysInMonth; j++)
            {
                while (true)
                {
                    try
                    {
                        lines[j] = Console.ReadLine();
                        break;
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static ConsoleKey UserChoice()
        {
            Console.WriteLine("F - читать данные из файла\n" +
                              "C - ввести данные из консоли");
            return Console.ReadKey().Key;
        }

        private static Dictionary<string, double>[] DictArray(string[] lines)
        {
            // string [] {"1", "2", "3"} -> Dictionary<string, double> {"abc":1, "def":2, "ghk":3}
            Dictionary<string, double>[] dictArray = new Dictionary<string, double>[Variables.DaysInMonth]; 
            string[] stringKeys =
            {
                "averageTemperatureDay",
                "averageTemperatureNight",
                "averageAtmosphericPressure",
                "precipitation"
            };
            for (int i = 0; i < lines.Length; i++)
            {
                string[] linesSplit = lines[i].Split();
                dictArray[i] = new Dictionary<string, double>();
                for (int j = 0; j < linesSplit.Length; j++)
                {
                    double num = 0;
                    try
                    {
                        num = Convert.ToDouble(linesSplit[j]);
                    }
                    catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
                    {
                        Console.WriteLine(ex.Message);
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                    dictArray[i].Add(stringKeys[j], num);
                }   
            }

            return dictArray;
        }

        static void Main()
        {
            string path = @"..\..\..\src\data.txt";
            Dictionary<string, double>[] data = Data(path);
            Console.WriteLine(data);
        }
    }
}