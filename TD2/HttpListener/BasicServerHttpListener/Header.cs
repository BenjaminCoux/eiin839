using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    class Header
    {  
        private System.Collections.Specialized.NameValueCollection response;


        public Header(System.Collections.Specialized.NameValueCollection response)
        {
            this.response = response;
        }
        public Header()
        {

        }

        public void setResponce(System.Collections.Specialized.NameValueCollection resp)
        {
            this.response = resp;
        }

        public void printHeader()
        {
            Console.WriteLine("****** VOICI LE HEADER *******");
            Console.WriteLine(this.response);
            Console.WriteLine("****** FIN DU HEADER *******");
        }
       
    }
}
