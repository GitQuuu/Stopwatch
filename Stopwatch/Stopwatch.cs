using System;
using System.ComponentModel;

namespace Stopwatch
{
    public class Stopwatch
    {

        public  enum WatchState
        {
            Start = 1,
            Stop = 2
        }

        public static TimeSpan Duration { get; set; }   
        public static DateTime TimeStart { get; set; }
        public static DateTime TimeStop { get; set; }

        public static void Start()
        {
            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");
        }

        public static void Stop()
        {
            TimeStop = DateTime.Now;
            Duration = TimeStop - TimeStart;   
            Console.WriteLine($"Stopwatch stop at {TimeStop}\n");
        }
    }
}