using BenchmarkDotNet.Attributes;
using Leetcode.Services;

namespace Leetcode.Tests.Unit.Benchmark
{
    [MemoryDiagnoser]
    public class ThreeSumHelperBenchmark
    {
        private const int N = 3000;
        private readonly int[] nums;

        /// <summary>
        /// |                     Method |         Mean |      Error |     StdDev |      Gen0 |     Gen1 |     Gen2 | Allocated |
        /// |--------------------------- |-------------:|-----------:|-----------:|----------:|---------:|---------:|----------:|
        /// |                   ThreeSum |     95.64 ms |   1.615 ms |   1.510 ms | 1500.0000 | 500.0000 | 333.3333 |  10.13 MB |
        /// | ThreeSumWithoutOptimizeWay | 13,144.15 ms | 208.412 ms | 184.752 ms |         - |        - |        - |   4.44 MB |
        /// </summary>
        public ThreeSumHelperBenchmark()
        {
            int Min = -99000;
            int Max = 99000;
            Random randNum = new Random();
            nums = Enumerable
                .Repeat(0, N)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();
        }

        [Benchmark]
        public IList<IList<int>> ThreeSum() => ThreeSumHelper.ThreeSum(nums);

        [Benchmark]
        public IList<IList<int>> ThreeSumWithoutOptimizeWay() => ThreeSumHelper.ThreeSumWithoutOptimizeWay(nums);
    }
}
