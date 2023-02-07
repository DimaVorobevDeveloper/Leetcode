namespace Leetcode.Services;

public class SumClosestService
{
    public static int ThreeSumClosestV(int[] nums, int target)
    {
        Console.WriteLine($"input data count - {nums.Length}");

        var h = new HashSet<int>();

        if (nums.Count(x => x == 0) >= 3)
        {
            h.Add(-target);
        }

        if (nums.Count(x => x == 0) > 1)
        {
            // remove 0 > 1 count
            var newNums = nums.ToList();
            newNums.RemoveAll(x => x == 0);
            newNums.Add(0);
            nums = newNums.ToArray();
        }

        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) // Иди по массиву по всем элементом
        {
            dict.Add(i, target - nums[i]);
        }

        var min = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                if (i != j)
                {
                    //for (int k = j; k < nums.Length; k++)
                    //{
                    //    if (i != k && j != k)
                    //    {
                    //        h.Add(nums[i] + nums[j] + nums[k] - target);
                    //    }
                    //}

                    //if (dict.FirstOrDefault(x => i != x.Key && j != x.Key 
                    //                                        && x.Value > nums[i] + nums[j]))
                    //{

                    //}
                }
            }
        }

        int? more = h.Any(x => x >= 0) ? h.Where(x => x >= 0).Select(x => x).Min() : null;
        int? less = h.Any(x => x < 0) ? h.Where(x => x < 0).Select(x => -x).Min() : null;

        var result = more.HasValue ? ((!less.HasValue || more < less) ? target + more : target - less) : target - less.Value;

        return result.Value;
    }

    public static int ThreeSumClosest(int[] nums, int target)
    {
        /*
         * Given an integer array nums of length n and an integer target,
         * find three integers in nums such that the sum is closest to target.
           Return the sum of the three integers.
           You may assume that each input would have exactly one solution.

        Example 1:
        Input: nums = [-1,2,1,-4], target = 1
        Output: 2
        Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        Example 2:
        
        Input: nums = [0,0,0], target = 1
        Output: 0
        Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).

        3 <= nums.length <= 500
       -1000 <= nums[i] <= 1000
       -104 <= target <= 104
         */

        Console.WriteLine($"input data count - {nums.Length}");

        var h = new HashSet<int>();

        if (nums.Count(x => x == 0) > 1)
        {
            // remove 0 > 1 count
            var newNums = nums.ToList();
            newNums.RemoveAll(x => x == 0);
            newNums.Add(0);
            nums = newNums.ToArray();
        }

        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) // Иди по массиву по всем элементом
        {
            dict.Add(i, target - nums[i]);
        }

        for (int i = 0; i < nums.Length; i++) // Иди по массиву по всем элементом
        {
            for (int j = i; j < nums.Length; j++) // Во внутреннем цикле иди по массиву от текущего элемента внешнего массива
            {
                // Проверяй 0 - mass[i] - mass[j] есть в словаре ?
                if (i != j && !dict.TryGetValue(i, out int i1) && !dict.TryGetValue(j, out int j1))
                {
                    h.Add(-nums[i] - nums[j]);
                }
            }
        }

        var hh = new HashSet<int>();
        foreach (var d in dict)
        {
            foreach (var e in h)
            {
                hh.Add(d.Value + e);
            }
        }

        var result = hh.Any() ? hh.Min() : 0;

        return result;
    }
}
