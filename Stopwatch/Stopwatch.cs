using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace StopWatch
{
    public class StopWatch
    {

        public  TimeSpan Duration { get;  set; }   
        public  DateTime TimeStart { get; set; }
        public  DateTime TimeStop { get;  set; }

        // A method to instantiating new objects of the StopWatch class
        public static StopWatch CreateStopwatch()
        {
           
            //StopWatch stopwatchObject = new StopWatch();
    
            return new StopWatch();
        }

        public  void StartTimer()
        {
            
            this.TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {this.TimeStart}\n");
            Menu.Runtime();


            //Thread secondThread = new Thread(new System.Threading.ThreadStart(Stopwatch.Runtime));
            //secondThread.Start();
            //Thread.Sleep(1000);

            bool preventOverlap;
            do
            {
                if (Console.ReadLine() == "2")
                {
                    //secondThread.Join();
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
            this.TimeStop = DateTime.Now;
            this.Duration = this.TimeStop - this.TimeStart;
            TimeSpan elapsed = DateTime.Parse(this.TimeStop.ToString()).Subtract(DateTime.Parse(this.TimeStart.ToString()));
            Console.WriteLine($"Stopwatch stop at {this.TimeStop} elapsed time {elapsed}\n");

        }


        public delegate void ThreadStart();
    }


}