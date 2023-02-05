using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using Leetcode.Services;

namespace Leetcode.Tests.Unit.Benchmark
{
    public class ThreeSumHelperBenchmark
    {
        private const int N = 1000;
        private readonly byte[] data;
        private readonly int[] nums;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public Md5VsSha256()
        {
            int Min = -99000;
            int Max = 99000;
            Random randNum = new Random();
            nums = Enumerable
                .Repeat(0, 5)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();
        }

        [Benchmark]
        public IList<IList<int>> ThreeSum() => ThreeSumHelper.ThreeSum(nums);

        [Benchmark]
        public IList<IList<int>> ThreeSumWithoutOptimizeWay() => ThreeSumHelper.ThreeSumWithoutOptimizeWay(nums);
    }
}
