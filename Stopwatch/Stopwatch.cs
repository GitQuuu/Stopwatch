using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Stopwatch
{
    public class Stopwatch
    {
        public enum Choices
        {
            Yes = 'y',
            No = 'n'
        }   

        public  enum PowerState
        {
            On = 1,
            Off = 2
        }

        public static TimeSpan Duration { get; private set; }   
        public static DateTime TimeStart { get; private set; }
        public static DateTime TimeStop { get; private set; }


        public  void PowerOn(string introduction)
        {
            Stopwatch stopwatch = new Stopwatch();
            bool LoopState = true;
            while (LoopState)
            {
                Console.WriteLine(introduction);

                switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Stopwatch.PowerState.On:
                        Console.Clear();
                        stopwatch.StartTimer();
                        continue;
                    case (int)Stopwatch.PowerState.Off:
                        Stopwatch.StopTimer();
                        Console.Write("Are you sure? ");
                        LoopState = false;
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
                        case (char)Stopwatch.Choices.No:

                            inputCheck = false;
                            powerOffState = true;
                            PowerOn("Press 1 to start again and 2 to end program");

                            break;
                        case (char)Stopwatch.Choices.Yes:

                           
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
            Stopwatch stopwatch = new Stopwatch();

            TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {TimeStart}\n");

           
            //Thread secondThread = new Thread(new System.Threading.ThreadStart(Stopwatch.Runtime));
            //secondThread.Start();
            //Thread.Sleep(1000);
            
            Runtime();

            bool preventOverlap = true;
            do
            {
                if (Console.ReadLine() == "2")
                {
                    //secondThread.Join();
                    StopTimer();
                    Console.WriteLine($"Runtime is {Stopwatch.Duration.TotalSeconds} seconds \n");
                    preventOverlap = false;
                }
                else
                {
                    Console.WriteLine("Please stop the watch before starting a new instance");
                    preventOverlap = true;
                }
            } while (preventOverlap);
        }

        public static void Runtime()
        {
            //ConsoleKeyInfo q;
            
                for (int liveRuntime = 1; liveRuntime > 0; liveRuntime++)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.Write($"Live runtime 2 thread: {liveRuntime} ");
                    Thread.Sleep(1000);

                    if (Console.KeyAvailable)
                    {
                        liveRuntime = 0;
                        break;
                    }
                }
            
           

        }

        public delegate void ThreadStart();
        public static void StopTimer()
        {
            Console.Clear();
            TimeStop = DateTime.Now;
            Duration = TimeStop - TimeStart;
            TimeSpan elapsed = DateTime.Parse(TimeStop.ToString()).Subtract(DateTime.Parse(TimeStart.ToString()));
            Console.WriteLine($"Stopwatch stop at {TimeStop} elapsed time {elapsed}\n");
           
        }
    }
}