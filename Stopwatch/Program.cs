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
            bool stopwatchLoop = true;

            while (stopwatchLoop == true)
                
            {
                bool exitOrContinue = true;
                Console.WriteLine("Press 1 to start and 2 to stop watch");


                    switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
                    {
                        case (int)Stopwatch.WatchState.Start:
                            Console.Clear();
                            Stopwatch.Start();
                            continue;
                        case (int) Stopwatch.WatchState.Stop:
                            Stopwatch.Stop();
                            break;
                        default:
                            Console.WriteLine("Please try again");
                            continue;
                    }

                while (exitOrContinue) { 

                    Console.WriteLine("Continue program y/n?");
                    if (Console.ReadLine() == "y" )
                    {
                        stopwatchLoop = true;
                        exitOrContinue = false;
                    }
                    else
                    {
                        stopwatchLoop = false;
                        exitOrContinue = false;

                    }
                }
            }

        }
    }
}
