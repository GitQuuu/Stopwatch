using System;
using System.ComponentModel;

namespace Stopwatch
{
    public static class Stopwatch
    {

        public  enum WatchState
        {
            Start = 1,
            Stop = 2
        }

        public static  TimeSpan Duration { get; private set; }   
        public static DateTime TimeStart { get; private set; }
        public static DateTime TimeStop { get; private set; }

        public static void Start()
        {
            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");

            bool preventOverlap = true;
            do
            {
                Console.WriteLine("Press 2 to stop and display the runtime");

                if (Console.ReadLine() == "2")
                {
                    Stop();
                    preventOverlap = false;

                    Console.WriteLine($"Runtime is {Stopwatch.Duration.TotalSeconds} seconds \n");
                }
                else
                {
                    Console.WriteLine("Please stop the watch before starting a new instance");

                    preventOverlap = true;
                }
            } while (preventOverlap);
        }

        public static void Stop()
        {
            TimeStop = DateTime.Now;
            Duration = TimeStop - TimeStart;   
            Console.WriteLine($"Stopwatch stop at {TimeStop}\n");
        }
    }
}