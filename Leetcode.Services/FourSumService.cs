namespace Leetcode.Services;

public class FourSumService
{
    /*
     *Given an array nums of n integers, return an array of all the unique quadruplets
     * [nums[a], nums[b], nums[c], nums[d]] such that:
     * 0 <= a, b, c, d < n
       a, b, c, and d are distinct.
       nums[a] + nums[b] + nums[c] + nums[d] == target
       You may return the answer in any order.

       Example 1:
       Input: nums = [1,0,-1,0,-2,2], target = 0
       Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

       Example 2:
       Input: nums = [2,2,2,2,2], target = 8
       Output: [[2,2,2,2]]
     */

    public static IList<IList<int>> GetUniqueQuadruplets(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.TryAdd(target - nums[i], i)) ;
        }

        var h = new HashSet<(int, int, int, int)>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (i != j && i != k && k != j && dict.TryGetValue(nums[i] + nums[j] + nums[k], out int keyValK))
                    {
                        if (keyValK == i || keyValK == j || keyValK == k)
                            continue;

                        try
                        {
                            checked
                            {
                                var t = nums[i] + nums[j] + nums[k];
                                var r = new[] { target - t, nums[i], nums[j], nums[k] };
                                Array.Sort(r);
                                h.Add((r[0], r[1], r[2], r[3]));
                            }
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }

        var result = (IList<IList<int>>)h.Select(x => (IList<int>)new List<int> { x.Item1, x.Item2, x.Item3, x.Item4 }).ToList();

        return result;
    }

    public static IList<IList<int>> GetUniqueQuadrupletsV1(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            dict.Add(i, target - nums[i]);
        }

        var h = new HashSet<(int, int, int, int)>();
        KeVal x = new();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = i + 1; k < nums.Length; k++)
                {
                    if (i != j && i != k && k != j && dict.Any(x => x.Value == nums[i] + nums[j] + nums[k]))
                    {
                        x.K = dict.First(x => x.Value == nums[i] + nums[j] + nums[k]);
                        if (x.K.Key == i || x.K.Key == j || x.K.Key == k)
                            continue;

                        var r = new[] { target - nums[i] - nums[j] - nums[k], nums[i], nums[j], nums[k] };
                        Array.Sort(r);
                        h.Add((r[0], r[1], r[2], r[3]));
                    }
                }
            }
        }

        var result = (IList<IList<int>>)h.Select(x => (IList<int>)new List<int> { x.Item1, x.Item2, x.Item3, x.Item4 }).ToList();

        return result;
    }

    public class KeVal
    {
        public KeyValuePair<int, int> K { get; set; }
    }
}