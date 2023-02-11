namespace Leetcode.Services;

public class LetterCombinationsService
{
    /*
     *Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
     * Return the answer in any order.
      A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
     *
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

    public static IList<string> LetterCombinations(string digits)
    {
        if (digits == "")
        {
            return new List<string>();
        }

        if (digits.Length == 1)
        {
            return LettersMap[digits];
        }

        var vals = digits.Select(key => LettersMap[key.ToString()]).ToArray();

        var combinationsArr = vals[0];
        for (int i = 1; i < vals.Count(); i++)
        {
            var newCombinationsArr = new string[combinationsArr.Length * vals[i].Length];
            var k = 0;
            for (int l = 0; l < combinationsArr.Length; l++)
            {
                for (int j = 0; j < vals[i].Length; j++)
                {
                    newCombinationsArr[k] = combinationsArr[l] + vals[i][j];
                    // newCombinationsArr[k] = $"{combinationsArr[l]}{vals[i][j]}";
                    k++;
                }
            }

            combinationsArr = newCombinationsArr;
        }

        return combinationsArr.Select(x => x).ToList();
    }

    public static readonly Dictionary<string, string[]> LettersMap = new()
    {
        { "2", new [] { "a","b","c" } },
        { "3", new [] { "d","e","f" } },
        { "4", new [] { "g","h","i" } },
        { "5", new [] { "j","k","l" } },
        { "6", new [] { "m","n","o" } },
        { "7", new [] { "p","q","r","s" } },
        { "8", new [] { "t","u","v" } },
        { "9", new [] { "w","x","y","z" } }
    };
}
