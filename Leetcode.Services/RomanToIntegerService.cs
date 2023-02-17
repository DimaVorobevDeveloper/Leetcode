namespace Leetcode.Services;

public class RomanToIntegerService
{
    public static int Convert(string s = "LVIII")
    {
        var dict = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };
        int globalNumber = 0;
        char previousChar = s[s.Length - 1];

        for (int i = s.Length - 1; i > -1; i--)
        {
            if (dict.TryGetValue(s[i], out int currNumber))
            {
                dict.TryGetValue(previousChar, out int prevNumber);

                if (previousChar != s[i] && prevNumber > currNumber)
                {
                    globalNumber -= currNumber;
                }
                else
                {

                    globalNumber += currNumber;
                }

                previousChar = s[i];
            }
        }

        return globalNumber;
    }
}
