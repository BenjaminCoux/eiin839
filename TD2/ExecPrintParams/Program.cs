using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecPrintParams
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = "<HTML><BODY>";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] != null)
                {
                    start += "param" + i + ": ";
                    start += args[i];
                    start += "<br/>";
                }
            }
            start += "</BODY></HTML>";
            Console.WriteLine(start);
        }
    }
}
