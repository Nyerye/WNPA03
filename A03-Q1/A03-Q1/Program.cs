//
// Place your file header comments here
//
using System;
using System.Diagnostics;

namespace A03_Q1
{
    public class Program
    {
        static void Main(string[] args)
        {
            long initialTicks = InitialCode();
            long betterTicks = BetterCode();

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

        public static long InitialCode()
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

            return sw.ElapsedTicks;
        }

        public static long BetterCode()
        {
            int temp = 0;
            float randomFloat;
            Random rand = new Random();
            int LOOPCOUNT = 10000;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                randomFloat = rand.NextSingle();

                if (randomFloat < .10f)
                {
                    temp = 1;
                }
                else if (randomFloat < .30f)
                {
                    temp = 2;
                }
                else
                {
                    temp = 3;
                }
            }

            sw.Stop();
            GC.KeepAlive(temp);

            return sw.ElapsedTicks;
        }
    }
}