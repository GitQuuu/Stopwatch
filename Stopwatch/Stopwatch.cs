using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Stopwatch
{
    public class StopWatch
    {

        public static TimeSpan Duration { get; private set; }   
        public static DateTime TimeStart { get; private set; }
        public static DateTime TimeStop { get; private set; }

        // A method to instantiating new objects of the StopWatch class
        public StopWatch CreateStopwatch()
        {
            StopWatch stopwatchObject = new StopWatch();

            return stopwatchObject;
        }

        public void PowerOn()
        {
            StopWatch stopwatch = new StopWatch();
            bool loopState = true;
            while (loopState)
            {
                Console.WriteLine();

                switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Menu.PowerState.On:
                        //stopwatch.StartTimer();
                        continue;
                    case (int)Menu.PowerState.Off:
                        stopwatch.StopTimer();
                        Console.Write("Are you sure? ");
                        loopState = false;
                        break;
                    default:
                        Console.WriteLine("Choose either 1 or 2");
                        continue;
                }

            }
        }

        public  void PowerOff(string actions)
        {
            bool powerOffState = true;
            while (powerOffState)
            {
                bool inputCheck = true;
                while (inputCheck)
                {
                    Console.Write(actions);
                    switch (char.TryParse(Console.ReadLine(), out char yesOrNo) ? yesOrNo : default)
                    {
                        case (char)Menu.Choices.No:

                            inputCheck = false;
                            powerOffState = true;
                            PowerOn("Press 1 to start again and 2 to end program");

                            break;
                        case (char)Menu.Choices.Yes:

                           
                            inputCheck = false;
                            powerOffState = false;
                           
                            break;
                        default:
                            Console.Write("Please select either y or n to continue program\n");
                            break;
                    }

                }

            }
        }


        public void StartTimer()
        {
            StopWatch stopwatch = new StopWatch();

            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");
            Runtime();


            //Thread secondThread = new Thread(new System.Threading.ThreadStart(Stopwatch.Runtime));
            //secondThread.Start();
            //Thread.Sleep(1000);


            bool preventOverlap = true;
            do
            {
                if (Console.ReadLine() == "2")
                {
                    //secondThread.Join();
                    StopTimer();
                    Console.WriteLine($"Runtime is {StopWatch.Duration.TotalSeconds} seconds \n");
                    preventOverlap = false;
                }
                else
                {
                    Console.WriteLine("Please stop the watch before starting a new instance");
                    preventOverlap = true;
                }
            } while (preventOverlap);
        }

        public void Runtime()
        {
            
            for (int liveRuntime = 1; liveRuntime > 0; liveRuntime++)
            {
                Console.SetCursorPosition(0, 3);
                Console.Write($"Live runtime 2 thread: {liveRuntime} \n");
                Thread.Sleep(1000);

                if (Console.KeyAvailable)
                {
                    break;
                }
            }
        }

        public delegate void ThreadStart();
        public void StopTimer()
        {
            TimeStop = DateTime.Now;
            Duration = TimeStop - TimeStart;
            TimeSpan elapsed = DateTime.Parse(TimeStop.ToString()).Subtract(DateTime.Parse(TimeStart.ToString()));
            Console.WriteLine($"Stopwatch stop at {TimeStop} elapsed time {elapsed}\n");
           
        }
    }
}