using BenchmarkDotNet.Running;

namespace Leetcode.Tests.Unit.Benchmark;

internal class Program
{
    private static int a;

    static Program()
    {
        Program.a = a;
    }

    // !!! run in release mode
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ThreeSumHelperBenchmark>();
        //var summary = BenchmarkRunner.Run<FourSumServiceBenchmark>();
        //var summary = BenchmarkRunner.Run<SpanExamplesBenchmark>();
    }

    public static async Task A()
    {
        Console.WriteLine("A");
        Console.WriteLine("AB");
        long x = -900;
        string v = string.Empty;
        while (x < 900)
        {
            x++;
            v = v + x;
        }

        Console.WriteLine("ABC");
        await B();
        Console.WriteLine("D");
    }

    public static async Task B()
    {
        Console.WriteLine("B");
        await Task.Delay(5000);
        Console.WriteLine("C");
    }
}