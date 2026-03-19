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

        static void Main(string[] args)
        {
            InitialCode();
            BetterCode();

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
            GC.KeepAlive(temp);

            initialTicks = sw.ElapsedTicks;
        }

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
            GC.KeepAlive(temp);

            betterTicks = sw.ElapsedTicks;
        }
    }
}