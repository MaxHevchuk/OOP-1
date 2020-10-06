using System;

namespace _4
{
    class Date
    {
        private int year;
        private int month;
        private int day;

        public Date()
        {
            this.year = DateTime.Now.Year;
            this.month = DateTime.Now.Month;
            this.day = DateTime.Now.Day;
        }
        public Date(int d, int m)
        {
            if ((1 <= m && m <= 12) && (1 <= d && d <= 30))
            {
                this.year = DateTime.Now.Year;
                this.month = m;
                this.day = d;
            }
            else { Console.WriteLine("Неверная дата."); }
        }
        public Date(int d, int m, int y)
        {
            if ((1 <= m && m <= 12) && (1 <= d && d <= 30))
            {
                this.year = y;
                this.month = m;
                this.day = d;
            }
            else { Console.WriteLine("Неверная дата."); }
        }

        public DateTime GetDate() => new DateTime(day, month, year);

        public TimeSpan SubDate(DateTime dateValue1, DateTime dateValue2) => dateValue1.Subtract(dateValue2);

        public double toDays(DateTime dateValue) => dateValue.Day + 30 * (dateValue.Month + 12 * dateValue.Year);
        public DateTime toDate(double days)
        {
            int year = Convert.ToInt32(days / 30 / 12);
            int month = Convert.ToInt32(days / 30);
            int day = Convert.ToInt32(days % 30);
            return new DateTime(day, month, year);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Date dateClass = new Date(10, 2, 2020);
            Date dateClass2 = new Date(1, 2, 2020);
            var date_1 = dateClass.GetDate();
            var date_2 = dateClass2.GetDate();
            Console.WriteLine(date_1);
            Console.WriteLine(date_2);
            Console.WriteLine(dateClass.SubDate(date_1, date_2));
            Console.WriteLine(dateClass.SubDate(date_2, date_1));
            Console.WriteLine(dateClass.toDays(date_1));
            Console.WriteLine(dateClass.toDate(dateClass.toDays(date_1)));
            Console.WriteLine(dateClass2.toDays(date_2));
            Console.WriteLine(dateClass2.toDate(dateClass2.toDays(date_2)));
            Console.WriteLine();
        }
    }
}
