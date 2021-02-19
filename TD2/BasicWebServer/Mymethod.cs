using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace BasicServerHTTPlistener
{
    class Mymethod
    {
    
        public Mymethod()
        {
          
        }

        public string printParamsFromEXE(string[] param)//methode qui fait appel à un exe pour afficher les paramètres
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"D:\polytech\SI4\S8\SOC\eiin839\TD2\ExecPrintParams\bin\Debug\ExecPrintParams.exe"; // Specify exe name.
            start.Arguments = param[0]+param[1]+param[2]+param[3]; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            string result = "";
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        public string printParams(string[] param)
        { 
            string start ="<HTML><BODY>";
            for (int i = 0; i < param.Length; i++)
            {
                if (param[i] != null)
                {
                    start += "param" + i + ": ";
                    start += param[i];
                    start += "<br>";
                }
            }
            start += "</BODY></HTML>";
      
            return start;

        }
    }
}
