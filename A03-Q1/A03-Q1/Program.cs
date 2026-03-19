// 
// Place your file header comments here
//
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace A03_Q1
{
    [MemoryDiagnoser]
    public class Program
    {
        static void Main(string[] args)
        {

            BenchmarkRunner.Run<Program>();
        }


        [Benchmark]
        public void InitialCode()
        {
            
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

        [Benchmark]
        public void BetterCode()
        {
            // Rewrite the code from initial code here, with
            // optimizations for time.
        }
    }
}
