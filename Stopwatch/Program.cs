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
            var stopwatch = new Stopwatch();

            Console.WriteLine("Press 1 to start and 2 to stop watch");

            bool loopState = true;
            do
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case (int)Stopwatch.WatchState.Start:
                        stopwatch.Start();
                        break;
                    case (int)Stopwatch.WatchState.Stop:
                        stopwatch.Stop();
                        loopState = false;
                        break;
                }
            } while (loopState);

            Console.WriteLine($"Duration of stopwatch is {stopwatch.TimeStop - stopwatch.TimeStart} seconds ");

           
                
            //if (Console.ReadLine() == "1")   
            //{
            //    stopwatch.Start();
            //}
            
            
            //Console.WriteLine("Hit 2 to stop watch");

            //if (Console.ReadLine() == "2")
            //{
            //    stopwatch.Stop();
            //}
            

            


            Console.ReadLine();
        }
    }
}
