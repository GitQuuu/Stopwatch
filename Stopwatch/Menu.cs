﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StopWatch
{
    static class Menu
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

        public static StopWatch PowerOn(string question)
        {
            StopWatch stopwatch = new StopWatch();

            bool loopState = true;
            while (loopState)
            {
                Console.WriteLine(question);

                switch (Int32.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)PowerState.On:
                        stopwatch.StartTimer();
                        continue;
                    case (int)PowerState.Off:
                        stopwatch.StopTimer();
                        Console.Write("Are you sure? ");
                        loopState = false;
                        break;
                    default:
                        Console.WriteLine("Choose either 1 or 2");
                        continue;
                }

            }

            return stopwatch;
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
                        Console.Clear();
                        stopwatch.StartTimer();
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

            PowerOff("Pres y to exit",stopwatch);
        }

        public static void PowerOff(string actions, StopWatch stopwatch)
        {
            bool powerOffState = true;
            while (powerOffState)
            {
                bool inputCheck = true;
                while (inputCheck)
                {
                    Console.Write(actions);
                    switch (Char.TryParse(Console.ReadLine(), out char yesOrNo) ? yesOrNo : default)
                    {
                        case (char)Menu.Choices.No:

                            inputCheck = false;
                            powerOffState = true;
                            stopwatch.StartTimer();

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
    }

   
}
