// 
// Place your file header comments here
//
using System.Diagnostics;

namespace A03_Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitialCode();
            BetterCode();

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }

        static void InitialCode()
        {
            // You may add code in this method for purposes of 
            // measuring performance.
            int temp = 0;
            Random rand = new Random();
            int LOOPCOUNT = 10000;
            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                float randomFloat = rand.NextSingle();
                if (randomFloat < .10)
                {
                    temp = 1;
                }
                if (randomFloat >= .10 && randomFloat < .30)
                {
                    temp = 2;
                }
                if (randomFloat >= .3)
                {
                    temp = 3;
                }
            }
        }

        static void BetterCode()
        {
            // Rewrite the code from initial code here, with
            // optimizations for time.
        }
    }
}
