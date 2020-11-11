using System;

namespace _8
{
    class MyComplex
    {
        private double re, im;

        public double Re
        {
            get => re;
            set => re = value;
        }

        public MyComplex(double InitRe = 0, double InitIm = 0)
        {
            Re = InitRe;
            im = InitIm;
        }

        public static MyComplex operator +(MyComplex A, MyComplex B)
        {
            return new MyComplex(A.Re + B.Re, A.im + B.im);
        }

        public static MyComplex operator +(MyComplex A, double B)
        {
            return new MyComplex(A.Re + B, A.im);
        }

        public static MyComplex operator -(MyComplex A)
        {
            return new MyComplex(-A.Re, -A.im);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}