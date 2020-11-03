using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace _4._4
{
    class Money
    {
        int hryvni;
        int kopiyky;

        public int Hryvni
        {
            get { return hryvni; }
        }

        public int Kopiyky
        {
            get { return kopiyky; }
        }

        public Money(double h)
        {
            if (h >= 0)
            {
                hryvni = Convert.ToInt32(h);
                kopiyky = Convert.ToInt32(h - hryvni);
            }
            else
            {
                throw new Exception("Значение меньше нуля");
            }
        }

        public Money(int h, int k)
        {
            if (h >= 0)
            {
                hryvni = h;
                kopiyky = k;
            }
        }

        public static int operator +(Money uah1, Money uah2)
        {
            return toKopiyky(uah1.Hryvni) + uah1.Kopiyky + toKopiyky(uah2.Hryvni) + uah2.Kopiyky;
        }

        public static int operator -(Money uah1, Money uah2)
        {
            return toKopiyky(uah1.Hryvni) + uah1.Kopiyky - toKopiyky(uah2.Hryvni) + uah2.Kopiyky;
        }

        public static int toKopiyky(double h)
        {
            return Convert.ToInt32(h * 100);
        }

        public static double toHryvni(int k)
        {
            return (double) k / 100;
        }
    }


    class Program
    {
        private int[] readFile(string path)
        {
            string[] text = File.ReadAllText(path).Split(' ');
            int[] array = new int[2];
            for (int i = 0; i < text.Length; i++)
            {
                array[i] = int.Parse(text[i]);
            }

            return array;
        }

        static void inputData()
        {
            Console.WriteLine("Где брать данные:\n" +
                              "0 -> ввод с клавиатуры\n" +
                              "1 -> читать из файла");
            int flag = Console.Read();
            switch (flag)
            {
                case 0:
                    console();
                    break;
                case 1:
                    file();
                    break;
            }
        }

        static void console()
        {
            int hrn1, hrn2;
            int coin1, coin2;

            Console.Write("Введите первую денежную суму в гривнях: ");
            hrn1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите первую денежную суму в копейках: ");
            coin1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите вторую денежную суму в гривнях: ");
            hrn2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите вторую денежную суму в копейках: ");
            coin2 = Convert.ToInt32(Console.ReadLine());
        }

        static void file()
        {
            string path = "./";
            string[] text = File.ReadAllText(path).Split(' ');
            int[] array = new int[4];
            for (int i = 0; i < text.Length; i++)
            {
                array[i] = int.Parse(text[i]);
            }

            int hrn1 = array[0];
            int coin1 = array[1];
            int hrn2 = array[2];
            int coin2 = array[3];
        }

        static void writeData()
        {
        }

        static void Main(string[] args)
        {
        }
    }
}