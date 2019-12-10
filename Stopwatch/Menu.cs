using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static void PowerOn(string question, StopWatch stopwatch)
        {

            bool loopState = true;
            while (loopState)
            {
                Console.WriteLine(question);

                switch (Int32.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Menu.PowerState.On:
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
        }
    }
}
