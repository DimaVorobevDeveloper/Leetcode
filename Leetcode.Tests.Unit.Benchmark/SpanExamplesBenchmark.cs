using BenchmarkDotNet.Attributes;
using Leetcode.Services;

namespace Leetcode.Tests.Unit.Benchmark;

[MemoryDiagnoser]
public class SpanExamplesBenchmark
{
    private const int N = 3000;
    private readonly int[] nums;

    /// <summary>
    /// |      Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
    /// |------------ |---------:|----------:|----------:|-------:|----------:|
    /// | GetPeopleV1 | 9.693 ns | 0.1086 ns | 0.1207 ns | 0.0115 |      48 B |
    /// | GetPeopleV2 | 9.868 ns | 0.1274 ns | 0.1192 ns | 0.0115 |      48 B |
    /// </summary>
    public SpanExamplesBenchmark()
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
    public Span<string> GetPeopleV1() => SpanExamples.GetPeopleV1();

    [Benchmark]
    public Span<string> GetPeopleV2() => SpanExamples.GetPeopleV2();
}