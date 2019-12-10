using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StopWatch
{
    class Menu
    {
        public enum Choices
        {
            Yes = 'y',
            No = 'n'
        }

        public enum PowerState
        {
            On = 1,
            Off = 2
        }

        public static void PowerOn(string question)
        {
            bool loopState = true;
            while (loopState)
            {
                Console.WriteLine(question);

                switch (Int32.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Menu.PowerState.On:
                        StartTimer();
                        continue;
                    case (int)Menu.PowerState.Off:
                        StopTimer();
                        Console.Write("Are you sure? ");
                        loopState = false;
                        break;
                    default:
                        Console.WriteLine("Choose either 1 or 2");
                        continue;
                }

            }
        }
        public static void PowerOn(string question, StopWatch stopwatch)
        {

            bool loopState = true;
            while (loopState)
            {
                Console.WriteLine(question);

                switch (Int32.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Menu.PowerState.On:
                        StartTimer();
                        continue;
                    case (int)Menu.PowerState.Off:
                        StopTimer();
                        Console.Write("Are you sure? ");
                        loopState = false;
                        break;
                    default:
                        Console.WriteLine("Choose either 1 or 2");
                        continue;
                }

            }
        }

        public static void StartTimer()
        {

            StopWatch.TimeStart = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {StopWatch.TimeStart}\n");
            Runtime();


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

        public static void Runtime()
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
        public static void StopTimer()
        {
            StopWatch.TimeStop = DateTime.Now;
            StopWatch.Duration = StopWatch.TimeStop - StopWatch.TimeStart;
            TimeSpan elapsed = DateTime.Parse(StopWatch.TimeStop.ToString()).Subtract(DateTime.Parse(StopWatch.TimeStart.ToString()));
            Console.WriteLine($"Stopwatch stop at {StopWatch.TimeStop} elapsed time {elapsed}\n");

        }
        public static void PowerOff(string actions)
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
    }
}
