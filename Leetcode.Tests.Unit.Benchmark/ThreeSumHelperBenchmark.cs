using BenchmarkDotNet.Attributes;
using Leetcode.Services;

namespace Leetcode.Tests.Unit.Benchmark;

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
    ///
    /// BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3693/22H2/2022Update)
    /// 13th Gen Intel Core i7-13700, 1 CPU, 24 logical and 16 physical cores
    ///     .NET SDK 8.0.100
    /// | Method                     | Mean        | Error     | StdDev   | Gen0     | Gen1     | Gen2     | Allocated |
    /// |--------------------------- |------------:|----------:|---------:|---------:|---------:|---------:|----------:|
    /// | ThreeSum                   |    53.95 ms |  0.345 ms | 0.323 ms | 700.0000 | 300.0000 | 300.0000 |  10.03 MB |
    /// | ThreeSumWithoutOptimizeWay | 4,716.57 ms | 11.567 ms | 9.030 ms |        - |        - |        - |    4.4 MB |
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
    public IList<IList<int>> ThreeSum() => ThreeSumService.ThreeSum(nums);

    [Benchmark]
    public IList<IList<int>> ThreeSumWithoutOptimizeWay() => ThreeSumService.ThreeSumWithoutOptimizeWay(nums);
}