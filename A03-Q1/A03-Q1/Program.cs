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

        //Moving the initialization off the random class up here to save time
        private Random rand;

        static void Main(string[] args)
        {

            BenchmarkRunner.Run<Program>();

        }

        //Setting up the random object once so BetterCode can reuse it
        [GlobalSetup]
        public void Setup()
        {
            rand = new Random();
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
            GC.KeepAlive(temp);

        }

        [Benchmark]
        public void BetterCode()
        {
            int temp = 0;
            int LOOPCOUNT = 10000;
            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                float randomFloat = rand.NextSingle();
                temp = randomFloat < .10f ? 1 : randomFloat < .30f ? 2 : 3;
            }
            GC.KeepAlive(temp);

        }
    }
}