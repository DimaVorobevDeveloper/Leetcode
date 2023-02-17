using BenchmarkDotNet.Running;

namespace Leetcode.Tests.Unit.Benchmark;

internal class Program
{
    // !!! run in release mode
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ThreeSumHelperBenchmark>();
    }
}