using System;
using System.IO;
using System.Linq;

namespace _10
{
    public interface IMyComplexIndex
    {
        double this[string index] { get; }
    }

    public interface IInputable
    {
        public void InputFromTerminal();
        public void InputFromFile(string pathToFile);
    }

    static class Variables
    {
        public static int CURRENT_LINE = 0;
        public readonly static string PATH = @"..\..\..\res\data\input.txt";
    }

    class MyComplexBase
    {
        private double re, im;

        private SpecialOutput mySetFuncOutput;

        public delegate void SpecialOutput(string message, MyComplexBase myObj);

        public double Re
        {
            get { return re; }
            set { re = value; }
        }

        public double Im
        {
            get { return im; }
            set { im = value; }
        }

        public SpecialOutput MySetFuncOutput
        {
            get { return mySetFuncOutput; }
            set { mySetFuncOutput = value; }
        }

        public MyComplexBase(double initRe = 0, double initIm = 0)
        {
            Re = initRe;
            Im = initIm;
        }

        public MyComplexBase(double initRe, double initIm, SpecialOutput mySetFuncOutputInit)
            : this(initRe, initIm)
        {
            MySetFuncOutput = mySetFuncOutputInit;
        }

        public void AddFunc(SpecialOutput func)
        {
            if (MySetFuncOutput != null)
                MySetFuncOutput += func;
            else
                MySetFuncOutput = func;
        }

        public void SubtractFunc(SpecialOutput func)
        {
            if (MySetFuncOutput.GetInvocationList().Contains(func))
            {
                MySetFuncOutput -= func;
                // MySetFuncOutput = (SpecialOutput) Delegate.Remove(MySetFuncOutput, func);
            }
        }

        public static MyComplexChild operator +(MyComplexBase a, MyComplexBase b)
        {
            return new MyComplexChild(a.Re + b.Re, a.Im + b.Im, a.MySetFuncOutput);
        }

        public static MyComplexChild operator +(MyComplexBase a, double b)
        {
            return new MyComplexChild(a.Re + b, a.Im, a.mySetFuncOutput);
        }

        public static MyComplexChild operator +(double a, MyComplexBase b)
        {
            return b + a;
        }

        public static MyComplexChild operator -(MyComplexBase a)
        {
            return new MyComplexChild(-a.Re, -a.Im, a.MySetFuncOutput);
        }

        public static MyComplexChild operator *(MyComplexBase a, MyComplexBase b)
        {
            return new MyComplexChild(a.Re + b.Re, a.Im + b.Im, a.MySetFuncOutput);
        }

        public override string ToString()
        {
            MySetFuncOutput.Invoke("3 вариант", this);
            if (Im > 0)
            {
                return $"{Re}+{Im}i";
            }

            return $"{Re}{Im}i";
        }
    }

    class MyComplexChild : MyComplexBase, IMyComplexIndex, IInputable
    {
        public MyComplexChild() : base()
        {
            Re = 0;
            Im = 10;
        }

        public MyComplexChild(double initRe = 0, double initIm = 10) : base(initRe, initIm)
        {
            // initRe in [0; 500] && [800; 1200)
            if (0 >= initRe && initRe <= 500 || 800 >= initRe && initRe < 1200)
                Re = initRe;
            else
                Re = 0;
            // initIm in [10; 80) && >= 900
            if (10 <= initIm && initIm < 80 || 900 <= initIm)
                Im = initIm;
            else
                Im = 10;
        }

        public MyComplexChild(double initRe, double initIm, SpecialOutput mySetFuncOutput)
            : base(initRe, initIm)
        {
            MySetFuncOutput = mySetFuncOutput;
        }


        public double this[string index]
        {
            get
            {
                switch (index)
                {
                    case "realValue":
                        return Re;
                    case "imaginaryValue":
                        return Im;
                    default:
                        return 0;
                }
            }
        }

        public void InputFromFile(string pathToFile)
        {
            string line;
            if (Variables.CURRENT_LINE == 0)
                line = File.ReadLines(pathToFile).First();
            else
            {
                line = File.ReadLines(pathToFile).Skip(Variables.CURRENT_LINE).First();
                Variables.CURRENT_LINE++;
            }

            ConvertStringToClassVar(line);
        }

        private void ConvertStringToClassVar(string line)
        {
            string[] lineSplit = line.Split();
            try
            {
                Re = Convert.ToDouble(lineSplit[0]);
                Im = Convert.ToDouble(lineSplit[1]);
            }
            catch (InvalidCastException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void InputFromTerminal()
        {
            Re = TryCatch("реальное");
            Im = TryCatch("мнимое");
        }

        private double TryCatch(string text)
        {
            while (true)
            {
                Console.Write($"Введите {text} число: ");
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    class Program
    {
        static void SpecialFunction1(string message, MyComplexBase myObj)
        {
            Console.WriteLine($"1. {message}: {myObj.Re} + {myObj.Im}*i");
        }

        static void SpecialFunction2(string message, MyComplexBase myObj)
        {
            Console.WriteLine($"2. {message}: {myObj.Re} + {myObj.Im}*i ");
        }

        static void Main()
        {
            MyComplexChild A = new MyComplexChild(1, 1);
            A.AddFunc(SpecialFunction1);
            A.AddFunc(SpecialFunction2);

            MyComplexChild B = new MyComplexChild();
            B.AddFunc(SpecialFunction1);
            B.AddFunc(SpecialFunction2);

            MyComplexChild C = new MyComplexChild();
            C.InputFromFile(Variables.PATH);
            C.AddFunc(SpecialFunction1);
            C.AddFunc(SpecialFunction2);

            MyComplexChild D = new MyComplexChild();
            D.InputFromTerminal();
            D.AddFunc(SpecialFunction1);
            D.AddFunc(SpecialFunction2);

            C = A + B;
            C = A + 10.5;
            C = 10.5 + A;
            D = -C;
            C = A + B + C + D;
            C = A = B = D;

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");

            MyComplexChild aChild = new MyComplexChild(A.Re, A.Im);
            MyComplexChild bChild = new MyComplexChild(B.Re, B.Im);
            MyComplexChild cChild = new MyComplexChild(C.Re, C.Im);
            MyComplexChild dChild = new MyComplexChild(D.Re, D.Im);
            Console.WriteLine($"Re(A) = {aChild["realValue"]}, Im(A) = {aChild["imaginaryValue"]}");
            Console.WriteLine($"Re(B) = {bChild["realValue"]}, Im(B) = {bChild["imaginaryValue"]}");
            Console.WriteLine($"Re(C) = {cChild["realValue"]}, Im(C) = {cChild["imaginaryValue"]}");
            Console.WriteLine($"Re(D) = {dChild["realValue"]}, Im(D) = {dChild["imaginaryValue"]}");
        }
    }
}