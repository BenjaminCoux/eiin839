using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoletd4
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CalculatorSoap calculator= new ServiceReference1.CalculatorSoapClient();
            Console.WriteLine("2*2 : " + calculator.Multiply(2, 2));
            Console.ReadLine();
        }
    }
}
