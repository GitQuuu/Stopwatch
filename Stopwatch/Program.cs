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
            

            Console.WriteLine("Press 1 to start and 2 to stop watch");

            bool loopState = true;
            do
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case (int)Stopwatch.WatchState.Start:
                        Stopwatch.Start();
                        break;
                    case (int)Stopwatch.WatchState.Stop:
                        Stopwatch.Stop();
                        loopState = false;
                        break;
                }
            } while (loopState);

            Console.WriteLine($"Duration of stopwatch is {Stopwatch.Duration.Seconds} seconds ");

   
            Console.ReadLine();
        }
    }
}
