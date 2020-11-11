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
using System.Linq;

namespace _7
{
    class Variables
    {
        public static int DaysInMonth = 30;
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
        private WeatherParametersDay[] dataWeatherArray;

        public WeatherParametersDay[] DataWeatherArray { get; }

        public WeatherDays(WeatherParametersDay[] dataWeatherArray)
        {
            this.dataWeatherArray = dataWeatherArray;
        }

        public int CountRainOrThunderstormDays()
        {
            return CountDays(TypeOfWeather.Rain, TypeOfWeather.Thunderstorm);
        }

        public int CountFogDays()
        {
            return CountDays(TypeOfWeather.Fog);
        }

        private int CountDays(params TypeOfWeather[] typeOfWeather)
        {
            int counter = 0;
            foreach (WeatherParametersDay day in dataWeatherArray)
            {
                TypeOfWeather weather = (TypeOfWeather) (int) day.InfoForTheDay["typeOfWeather"];
                counter += (typeOfWeather.Contains(weather)) ? 1 : 0;
            }

            return counter;
        }

        public double AveragePressure()
        {
            double sumPressure = 0;
            foreach (WeatherParametersDay day in dataWeatherArray)
            {
                sumPressure += day.InfoForTheDay["averageAtmosphericPressure"];
            }

            return sumPressure / dataWeatherArray.Length;
        }
    }

    class WeatherParametersDay
    {
        private double
            averageTemperatureDay,
            averageTemperatureNight,
            averageAtmosphericPressure,
            precipitation;

        private double typeOfWeather;
        private Dictionary<string, double> infoForTheDay;
        public Dictionary<string, double> InfoForTheDay { get; private set; }

        public WeatherParametersDay(double averageTemperatureDay, double averageTemperatureNight,
            double averageAtmosphericPressure, double precipitation, double typeOfWeather)
        {
            if (precipitation >= 0 &&
                averageAtmosphericPressure >= 0 &&
                Enumerable.Range(1, 8).Contains((int) typeOfWeather))
            {
                this.averageTemperatureDay = averageTemperatureDay;
                this.averageTemperatureNight = averageTemperatureNight;
                this.averageAtmosphericPressure = averageAtmosphericPressure;
                this.precipitation = precipitation;
                this.typeOfWeather = typeOfWeather;

                InfoForTheDay = new Dictionary<string, double>()
                {
                    ["averageTemperatureDay"] = this.averageTemperatureDay,
                    ["averageTemperatureNight"] = this.averageTemperatureNight,
                    ["averageAtmosphericPressure"] = this.averageAtmosphericPressure,
                    ["precipitation"] = this.precipitation,
                    ["typeOfWeather"] = this.typeOfWeather
                };
            }
        }
    }

    class Program
    {
        private static double[][] DataInput(string path)
        {
            string[] lines = new string[Variables.DaysInMonth];

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

            return StringToDoubleArray(lines);
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

        private static double[][] StringToDoubleArray(string[] lines)
        {
            // string [] {"1", "2", "3"} -> Dictionary<string, double>[] {"abc":1, "def":2, "ghk":3}
            double[][] data = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] linesSplit = lines[i].Split();
                data[i] = new double[linesSplit.Length];
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

                    data[i][j] = num;
                }
            }

            return data;
        }

        static void Main()
        {
            string path = @"..\..\..\src\data.txt";
            //сгенерировать рандомные данные в файле
            //GenerateDataInFile.Run();
            double[][] data = DataInput(path);

            WeatherParametersDay[] weatherParametersDays = new WeatherParametersDay[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                weatherParametersDays[i] = new WeatherParametersDay(data[i][0],
                    data[i][1],
                    data[i][2],
                    data[i][3],
                    data[i][4]);
            }

            WeatherDays weatherDays = new WeatherDays(weatherParametersDays);
            Console.WriteLine($"\nКоличество туманных дней: {weatherDays.CountFogDays()}");
            Console.WriteLine(
                $"Количество дней, когда был дождь или гроза: {weatherDays.CountRainOrThunderstormDays()}");
            Console.WriteLine($"Среднее атмосферное давление за месяц: {weatherDays.AveragePressure()}");
        }
    }
}