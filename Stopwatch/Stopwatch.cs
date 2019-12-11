using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace StopWatch
{
    public class StopWatch
    {

        public  TimeSpan Duration { get;  set; }   
        public static DateTime TimeStart { get; set; }
        public static DateTime TimeStop { get;  set; }

        // A method to instantiating new objects of the StopWatch class
        public static StopWatch CreateStopwatch()
        {
           
            //StopWatch stopwatchObject = new StopWatch();
    
            return new StopWatch();
        }

        public  void StartTimer()
        {
            
            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");


            Thread thread = new Thread(new System.Threading.ThreadStart(Menu.RuntimeInForeground));
            thread.Start();
          

            bool preventOverlap;
            do
            {

                if (Console.ReadLine() == "2")
                {
                    thread.Join();
                    StopTimer();
                    Console.WriteLine($"Runtime is {this.Duration.TotalSeconds} seconds \n");
                    preventOverlap = false;
                }
                else
                {
                    Console.WriteLine("Please stop the watch before starting a new instance");
                    preventOverlap = true;
                }
            } while (preventOverlap);
        }
    
        public  void StopTimer()
        {
            
            TimeStop = DateTime.Now;
            this.Duration = TimeStop - TimeStart;
            TimeSpan elapsed = DateTime.Parse(TimeStop.ToString()).Subtract(DateTime.Parse(TimeStart.ToString()));
            Console.WriteLine($"Stopwatch stop at {TimeStop} elapsed time {elapsed}\n");

        }


        public delegate void ThreadStart();
    }


}