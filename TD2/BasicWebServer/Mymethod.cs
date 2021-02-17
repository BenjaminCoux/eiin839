using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    class Mymethod
    {
    
        public Mymethod()
        {
          
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
