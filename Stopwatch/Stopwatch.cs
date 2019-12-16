﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace StopWatch
{
    public class StopWatch
    {

        public static TimeSpan Duration { get; set;}
        
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

            Thread thread = new Thread(new System.Threading.ThreadStart(RuntimeInForeground));
            thread.Start();

            thread.Join();
        }
    
        public static void StopTimer()
        {
            TimeStop = DateTime.Now;
            TimeSpan elapsed = DateTime.Parse(TimeStop.ToString()).Subtract(DateTime.Parse(TimeStart.ToString()));
            Console.WriteLine($"Stopwatch stop at {TimeStop} elapsed time {Duration}\n");

        }

        public void RuntimeInForeground()
        {
            System.Diagnostics.Stopwatch stopwatch = Stopwatch.StartNew();

            Console.Write($"Thread Id: {Thread.CurrentThread.ManagedThreadId} " +
                          $"State: {Thread.CurrentThread.ThreadState} " +
                          $"Priority: {Thread.CurrentThread.Priority}\n");

            Console.WriteLine("Press any key to stop the live runtime");

            bool keyPress = true;
            do
            {
                Console.SetCursorPosition(0, 6);
                Console.Write($"Live runtime: {stopwatch.Elapsed.Seconds}\n");

                Duration = stopwatch.Elapsed;
                Thread.Sleep(1000);

               
                if (Console.KeyAvailable)
                {
                    stopwatch.Stop();
                    keyPress = false;
                }

            } while (keyPress);

        }

        public delegate void ThreadStart();
    }


}