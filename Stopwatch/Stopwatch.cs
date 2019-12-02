using System;

namespace Stopwatch
{
    public class Stopwatch
    {
        public enum WatchState
        {
            Start,
            Stop
        }
       
        public DateTime TimeStart { get; set; }
        public DateTime TimeStop { get; set; }

        public void Start()
        {
            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");
        }

        public void Stop()
        {
            TimeStop = DateTime.Now;
            Console.WriteLine($"Stopwatch stop at {TimeStop}\n");
        }
    }
}