using System.Collections;
using Leetcode.Services;
using System.Diagnostics;

namespace Leetcode.Tests.Unit;

[TestClass]
public class LetterCombinationsServiceTest
{
    /*
     * Example 1:
       Input: digits = "23"
       Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

       Example 2:
       Input: digits = ""
       Output: []

       Example 3:
       Input: digits = "2"
       Output: ["a","b","c"]
     */
    [TestMethod]
    //[DataRow(Enumerable.Empty<string>(), "")]
    [DataRow(new[] { "a", "b", "c" }, "2")]
    [DataRow(new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }, "23")]
    public void LetterCombinations(string[] expected, string digits)
    {
        var t = new Stopwatch();
        Console.WriteLine($"run... ");
        t.Start();
        var result = LetterCombinationsService.LetterCombinations(digits);
        t.Stop();
        Console.WriteLine($"ElapsedMilliseconds = {t.ElapsedMilliseconds}");
        Console.WriteLine($"expected = {expected}, result = {result}");
        CollectionAssert.AreEqual(expected, result.ToArray());
    }
}

