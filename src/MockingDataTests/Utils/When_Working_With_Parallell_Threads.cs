using MockingData.Generators;
using MockingData.Generators.Random;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MockingDataTests.Utils
{
    public class When_Working_With_Parallell_Threads
    {
        [Fact]
        public void RandomGenerator_Should_Be_Able_To_Handle_Parallell_Calls()
        {
            var generator = new RandomGenerator();
            const int numRandomCalls = 10000;
            const int numTestLoops = 100;

            for (int p = 1; p <= 16; p <<= 1)
            {
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = p };
                RunAndMeasure("Random int", numTestLoops, () => { Parallel.For(0, numRandomCalls, parallelOptions, (idx) => { generator.Next(); }); });
                RunAndMeasure("Random double", numTestLoops, () => { Parallel.For(0, numRandomCalls, parallelOptions, (idx) => { generator.NextDouble(); }); });
            }
        }
        private static void RunAndMeasure(string name, int numLoops, Action act)
        {

            for (int i = 0; i < numLoops; ++i)
            {
                act();
            }
        }
    }


}
