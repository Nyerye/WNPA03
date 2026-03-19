//
// Place your file header comments here
//
using System;
using System.Diagnostics;

namespace A03_Q1
{
    public class Program
    {
        //Store results here for summary
        public static long initialTicks;
        public static long betterTicks;

        public const int LOOPCOUNT = 10000;
        public const int RUNS = 1000; //repeat to reduce noise

        static void Main(string[] args)
        {
            //Warmup the Just in Time Engine so that way the methods are already compiled when I want to really call them. 
            //I do not want to count the time it takes to compile them as that is noise.
            InitialCode();
            BetterCode();

            //Force garbage collection before the real run so we go back to a clean slate
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            //Measure InitialCode
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < RUNS; i++)
            {
                InitialCode();
            }
            sw.Stop();
            initialTicks = sw.ElapsedTicks;

            //Force GC again before next test
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            //Measure BetterCode
            sw.Restart();
            for (int i = 0; i < RUNS; i++)
            {
                BetterCode();
            }
            sw.Stop();
            betterTicks = sw.ElapsedTicks;

            //Display the results out to the user. This is about as true as it gets.
            Console.WriteLine("Summary of execution times:");
            Console.WriteLine($"InitialCode: {initialTicks} ticks");
            Console.WriteLine($"BetterCode:  {betterTicks} ticks");

            if (betterTicks < initialTicks)
            {
                Console.WriteLine("BetterCode was faster.");
            }
            else if (betterTicks > initialTicks)
            {
                Console.WriteLine("InitialCode was faster.");
            }
            else
            {
                Console.WriteLine("Both methods took the same time.");
            }
        }
        /// <summary>
        /// Method that holds the original code that Norbert provided
        /// The only modifications I made to it is to insert a stopwatch to measure the time the for loop takes to complete.
        /// </summary>
        public static void InitialCode()
        {
            int temp = 0;
            Random rand = new Random();
            int LOOPCOUNT = 10000;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                float randomFloat = rand.NextSingle();

                if (randomFloat < .10f)
                {
                    temp = 1;
                }

                if (randomFloat >= .10f && randomFloat < .30f)
                {
                    temp = 2;
                }

                if (randomFloat >= .30f)
                {
                    temp = 3;
                }
            }

            sw.Stop();
            initialTicks = sw.ElapsedTicks;
        }

        /// <summary>
        /// My more superior coding method than what Norbert gave me.
        /// Changed it to use ints instead of floats that look for the same thing, just with whole numbers.
        /// Added const to the LOPPCOUNT as it is a constant and should be addressed as such.
        /// Changed the if block to a ternary statement so its less branching.
        /// </summary>
        public static void BetterCode()
        {
            int temp = 0;
            Random rand = new Random();
            const int LOOPCOUNT = 10000;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                //Have a ceiling of 10 (100%)
                int randomInt = rand.Next(10);

                //Use a ternary statement to keep instructions to one line instead of multiple.
                temp = randomInt < 1 ? 1 : randomInt < 3 ? 2 : 3;
            }
            sw.Stop();
            betterTicks = sw.ElapsedTicks;
        }
    }
}
