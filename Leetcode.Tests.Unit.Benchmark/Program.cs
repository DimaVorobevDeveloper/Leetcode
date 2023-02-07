using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;
using Leetcode.Services;

namespace Leetcode.Tests.Unit.Benchmark;

internal class Program
{
    // !!! run in release mode
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ThreeSumHelperBenchmark>();

        // BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();

        // DispatchBenchmark();
    }

    private static void DispatchBenchmark()
    {
        var benchmark = new JobDispatchBenchmark();
        benchmark.Setup();
        benchmark.Run().GetAwaiter().GetResult();

        RunDispatch(benchmark);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void RunDispatch(JobDispatchBenchmark benchmark)
    {
        for (int i = 0; i < 100; ++i)
        {
            benchmark.Run().GetAwaiter().GetResult();
        }
    }
}