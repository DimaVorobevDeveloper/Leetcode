namespace Leetcode.Services;

public class ArrayComparator
{
    public static bool IsEquals(IEnumerable<string> word1, IEnumerable<string> word2)
    {
        // var t2
        var w1 = string.Empty;
        var w2 = string.Empty;
        var word1Enumerator = word1.GetEnumerator();
        var word2Enumerator = word2.GetEnumerator();
        int n, m = 0;
        while (word1Enumerator.MoveNext())
        {
            w1 += word1Enumerator.Current;
            n = w1.Length;

            do
            {
                word2Enumerator.MoveNext();
                w2 += word2Enumerator.Current;
                m = w2.Length;
            } while (n > m);

            int k = 0;
            int l = 0;
            var min = n > m ? m : n;
            while (min != l && w1[k] == w2[l])
            {
                k++;
                l++;
            }

            if (min != l) return false;

            w1 = w1.Substring(min);
            w2 = w2.Substring(min);
        }

        return w1 == w2;
    }
}