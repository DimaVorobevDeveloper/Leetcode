namespace Leetcode.Tests.Unit.Benchmark;

internal class Program
{
    // !!! run in release mode
    private static void Main(string[] args)
    {
        //var summary = BenchmarkRunner.Run<ThreeSumHelperBenchmark>();
        A();
    }

    public static async Task A()
    {
        Console.WriteLine("A");
        Console.WriteLine("AB");
        long x = -900;
        string v = string.Empty;
        while (x <900)
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