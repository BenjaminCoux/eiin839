using System;

namespace mathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MathLibrary.IMathsOperations m = new MathLibrary.MathsOperationsClient();
            Console.WriteLine(m.Add(2, 4));
            Console.WriteLine(m.Substract(12, 5));
            Console.WriteLine(m.Multiply(4, 5));
            Console.ReadLine();

        }
    }
}
