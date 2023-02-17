namespace Leetcode.Services;

public class LongestCommonPrefixService
{
    public static string Get(string[] strs)
    {
        var str = strs.MinBy(x => x.Length);
        var result = "";
        var searchValue = "";

        foreach (var s in str)
        {
            searchValue = result == "" ? s.ToString() : result + s;

            if (strs.All(x => x.StartsWith(searchValue)))
            {
                result += s;
            }
            else
            {
                return result;
            }
        }

        return result;
    }
}