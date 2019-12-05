using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Stopwatch
{
    public class Stopwatch
    {
        private static bool _loopState;

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


        public static void PowerOn(string introduction)
        {
            bool LoopState = true;
            while (LoopState)
            {
                Console.WriteLine(introduction);

                switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Stopwatch.WatchState.On:
                        Console.Clear();
                        Stopwatch.StartTimer();
                        continue;
                    case (int)Stopwatch.WatchState.Off:
                        Stopwatch.StopTimer();
                        LoopState = false;
                        break;
                    default:
                        Console.WriteLine("Choose either 1 or 2");
                        continue;
                }

            }
        }

        public static void PowerOff(string actions)
        {
            bool powerOffState = true;
            while (powerOffState)
            {
                bool inputCheck = true;
                while (inputCheck)
                {
                    Console.WriteLine(actions);
                    switch (char.TryParse(Console.ReadLine(), out char yesOrNo) ? yesOrNo : default)
                    {
                        case (char)Stopwatch.Choices.Yes:

                            inputCheck = false;
                            powerOffState = true;
                            PowerOn("Press 1 to start again and 2 to end program");

                            break;
                        case (char)Stopwatch.Choices.No:

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

        public static void StopTimer()
        {
            
            TimeStop = DateTime.Now;
            Duration = TimeStop - TimeStart;   
            Console.WriteLine($"Stopwatch stop at {TimeStop}\n");
        }
    }
}