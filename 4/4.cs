using System;
using System.Linq;

namespace _4
{
    class Date
    {
        private DateTime date;

        public int SetDate(int y, int m, int d)
        {
            if ((1 <= m && m <= 12) && (1 <= d && d <= 31))
            {
                this.date = new DateTime(y, m, d);
                return 1;
            }
            else
            {
                Console.WriteLine("Неверная дата.");
                return -1;
            }
        }

        public DateTime GetDate()
        {
            return date;
        }

        public string SubDate(DateTime dateValue1, DateTime dateValue2)
        {
            int[] res = this.toDateDifference(dateValue1.Subtract(dateValue2).TotalDays);
            return $"{res[0]} year {res[1]} month {res[2]} day";
        }

        private int[] toDateDifference(double days)
        {
            double rem = (int)days;
            int year = (int)((days - 30.417) / 365);
            rem -= year * 365;
            int month = (int)(rem / 30.417);
            rem -= month * 30.417;
            int day = (int)(rem + 1);
            return new int[] { year, month, day };
        }

        public double toDays(DateTime dateValue) => dateValue.Day + 30.417 * dateValue.Month + 365 * dateValue.Year;
        public string toDate(double days)
        {
            int[] res = this.toDateDifference(days);
            return new DateTime(res[0], res[1], res[2]).ToShortDateString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую дату в формате yyyy/MM/dd:");
            int[] arr1 = Console.ReadLine().Split('/').Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("Введите вторую дату в формате yyyy/MM/dd:");
            int[] arr2 = Console.ReadLine().Split('/').Select(x => int.Parse(x)).ToArray();

            Date dateClass = new Date();
            Date dateClass2 = new Date();

            int d1 = dateClass.SetDate(arr1[0], arr1[1], arr1[2]);
            int d2 = dateClass2.SetDate(arr2[0], arr2[1], arr2[2]);
            if (d1 == -1 || d2 == -1)
            {
                return;
            }

            DateTime getDate1 = dateClass.GetDate();
            DateTime getDate2 = dateClass2.GetDate();

            double getDateToDays1 = dateClass.toDays(getDate1);
            double getDateToDays2 = dateClass2.toDays(getDate2);

            Console.WriteLine($"Первая дата: {getDate1.ToShortDateString()}");
            Console.WriteLine($"Вторая дата: {getDate2.ToShortDateString()}");

            Console.WriteLine($"Разница двух дат: {dateClass.SubDate(getDate1, getDate2)}");
            Console.WriteLine($"Конвертация первой даты в дни: {(int)getDateToDays1} дней");
            Console.WriteLine($"Конвертация обратно в дату: {dateClass.toDate(getDateToDays1)}");
            Console.WriteLine($"Конвертация второй даты в дни: {(int)getDateToDays2} дней");
            Console.WriteLine($"Конвертация обратно в дату: {dateClass2.toDate(getDateToDays2)}");
        }
    }
}
