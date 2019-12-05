using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch.PowerOn("Press 1 to start and 2 to stop the Stopwatch");
            Stopwatch.PowerOff("Continue program y/n?");


        }
    }
}
