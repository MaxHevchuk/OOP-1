using System;
using System.Linq;

namespace _4
{
    class Dates
    {
        private DateTime date;  //variable
        public DateTime Date    //property
        {
            get
            {
                return date;
            }
            private set
            {
                date = value;
            }
        }
        public Dates(int y, int m, int d)   //constructor
        {
            int[] month30 = new int[] { 4, 6, 9, 11 };
            int[] month31 = new int[] { 1, 3, 5, 6, 7, 10, 12 };
            if ((1 <= d && d <= 30 && month30.Contains(m)) ||
                (1 <= d && d <= 31 && month31.Contains(m)) ||
                (1 <= d && d <= 29 && m == 2 && (y % 4 == 0 && y % 100 == 0 && y % 400 == 0)) || //проверка на высокосный год
                (1 <= d && d <= 28 && m == 2 && (y % 4 != 0 && y % 100 != 0 && y % 400 != 0))) //проверка на невысокосный год

                Date = new DateTime(y, m, d);
            else
            {
                Console.WriteLine("Не верная дата");
                Variable.key = false;
            }
        }

        public string SubDate(DateTime value1, DateTime value2)
        {
            int[] res = this.DateDifference(value1.Subtract(value2).TotalDays);
            return $"{res[0]} year {res[1]} month {res[2]} day";
        }

        private int[] DateDifference(double days)
        {
            double rem = (int)days;
            int year = (int)((days - 30.417) / 365);
            rem -= year * 365;
            int month = (int)(rem / 30.417);
            rem -= month * 30.417;
            int day = (int)(rem + 1);
            return new int[] { year, month, day };
        }

        public double toDays(DateTime dateValue)
        {
            return dateValue.Day + 30.417 * dateValue.Month + 365 * dateValue.Year;
        }

        public string toDate(double days)
        {
            int[] res = this.DateDifference(days);
            return new DateTime(res[0], res[1], res[2]).ToShortDateString();
        }
    }
    public static class Variable
    {
        public static Boolean key = true;
    }

    class Program
    {
        private static int[] DateTransformation(string text)
        {
            int[] res = new int[3];
            string[] textSplit = text.Split('/');
            for (int i = 0; i < textSplit.Length; i++)
                try
                {
                    res[i] = Convert.ToInt32(textSplit[i]);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
            return res;
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите первую дату в формате yyyy/MM/dd:");
            int[] arr1 = DateTransformation(Console.ReadLine());
            Console.WriteLine("Введите вторую дату в формате yyyy/MM/dd:");
            int[] arr2 = DateTransformation(Console.ReadLine());

            Dates dateClass = new Dates(arr1[0], arr1[1], arr1[2]);
            Dates dateClass2 = new Dates(arr2[0], arr2[1], arr2[2]);
            if (!Variable.key)
                return;

            DateTime getDate1 = dateClass.Date;
            DateTime getDate2 = dateClass2.Date;


            double getDateToDays1 = dateClass.toDays(getDate1);
            double getDateToDays2 = dateClass2.toDays(getDate2);

            Console.WriteLine($"Первая дата: {getDate1.ToShortDateString()}");
            Console.WriteLine($"Вторая дата: {getDate2.ToShortDateString()}");

            Console.WriteLine($"Разница двух дат: {dateClass.SubDate(getDate1, getDate2)}");
            Console.WriteLine($"Конвертация первой даты в дни: {getDateToDays1:f0} дней");
            Console.WriteLine($"Конвертация обратно в дату: {dateClass.toDate(getDateToDays1)}");
            Console.WriteLine($"Конвертация второй даты в дни: {getDateToDays2:f0} дней");
            Console.WriteLine($"Конвертация обратно в дату: {dateClass2.toDate(getDateToDays2)}");
        }
    }
}
