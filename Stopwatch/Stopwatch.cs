using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Stopwatch
{
    public static class Stopwatch
    {
        public enum Choices
        {
            Yes = 'y',
            No = 'n'
        }   

        public  enum WatchState
        {
            On = 1,
            Off = 2
        }

        public static TimeSpan Duration { get; private set; }   
        public static DateTime TimeStart { get; private set; }
        public static DateTime TimeStop { get; private set; }

        public static void StartTimer()
        {
            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");

            bool preventOverlap = true;
            do
            {
                Console.WriteLine("Press 2 to stop and display the runtime");

                if (Console.ReadLine() == "2")
                {
                    StopTimer();
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

        public static void StopTimer()
        {
            TimeStop = DateTime.Now;
            Duration = TimeStop - TimeStart;   
            Console.WriteLine($"Stopwatch stop at {TimeStop}\n");
        }
    }
}