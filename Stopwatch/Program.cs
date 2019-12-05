using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stopwatchLoop = true;

            while (stopwatchLoop == true)
                
            {
                bool exitOrContinue = true;
                Console.WriteLine("Press 1 to start and 2 to stop watch");


                    switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
                    {
                        case (int)Stopwatch.WatchState.On:
                            Console.Clear();
                            Stopwatch.StartTimer();
                            continue;
                        case (int) Stopwatch.WatchState.Off:
                            Stopwatch.StopTimer();
                            break;
                        default:
                            Console.WriteLine("Please try again");
                            continue;
                    }

                while (exitOrContinue)
                {
                    Console.WriteLine("Continue program y/n?");

                    bool doubleCheckExit = true;
                    while (doubleCheckExit)
                    {
                        switch (char.TryParse(Console.ReadLine(),out char yesOrNo) ? yesOrNo : default )
                        {
                            case (char)Stopwatch.Choices.Yes:
                                doubleCheckExit = false;
                                stopwatchLoop = true;
                                exitOrContinue = false;
                                break;
                            case (char)Stopwatch.Choices.No:
                                doubleCheckExit = false;
                                exitOrContinue = false;
                                stopwatchLoop = false;
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
}
