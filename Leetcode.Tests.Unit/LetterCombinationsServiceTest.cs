using Leetcode.Services;
using System.Diagnostics;

namespace Leetcode.Tests.Unit;

[TestClass]
public class LetterCombinationsServiceTest
{
    [TestMethod]
    [DataRow(0, "0, 0, 0")]
    public void ThreeSumClosest(int expected, string digits)
    {
        var t = new Stopwatch();
        Console.WriteLine($"run... ");
        t.Start();
        var result = LetterCombinationsService.LetterCombinations(digits);
        t.Stop();
        Console.WriteLine($"ElapsedMilliseconds = {t.ElapsedMilliseconds}");
        Console.WriteLine($"expected = {expected}, result = {result}");
        // Assert.AreEqual(expected, result);
    }
}

