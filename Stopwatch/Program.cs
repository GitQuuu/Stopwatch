using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {

          
            Menu.PowerOff("Pres y to exit",Menu.PowerOn("Press 1 to start watch or 2 to stop", StopWatch.CreateStopwatch()));
           
            
        }
    }
}
