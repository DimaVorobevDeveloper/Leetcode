using Leetcode.Services;

namespace Leetcode.Tests.Unit;

[TestClass]
public class LetterCombinationsServiceTests
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
    [DataRow(new[] { "a", "b", "c" }, "2")]
    [DataRow(new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }, "23")]
    public void LetterCombinations(string[] expected, string digits)
    {
        var result = LetterCombinationsService.LetterCombinations(digits);

        CollectionAssert.AreEqual(expected, result.ToArray());
    }
}

