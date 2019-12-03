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
            bool exitOrContinue = true;
            while (exitOrContinue)
            {
                Console.WriteLine("Press 1 to start and 2 to stop watch");

                bool loopState = true;
                do
                {
                    switch (int.TryParse(Console.ReadLine(), out int value) ? value: 0)
                    {
                        case (int)Stopwatch.WatchState.Start:
                            Console.Clear();
                            Stopwatch.Start();
                            continue;
                        case (int) Stopwatch.WatchState.Stop:
                            Stopwatch.Stop();
                            loopState = false;
                            break;
                        default:
                            Console.WriteLine("Please try again");
                            break;
                    }

                } while (loopState);

                Console.WriteLine($"Runtime is {Stopwatch.Duration.TotalSeconds} seconds \n");

                Console.WriteLine("Continue program y/n?");
                if (Console.ReadLine() != "n")
                {
                    exitOrContinue = true;
                }
                else
                {
                    exitOrContinue = false;

                    Console.WriteLine("Thanks for using Stopwatch");
                }
            }
            

   
            Console.ReadLine();
        }
    }
}
