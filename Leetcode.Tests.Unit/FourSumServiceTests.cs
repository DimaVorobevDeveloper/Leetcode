using Leetcode.Services;
using Leetcode.Tests.Unit.Models;

namespace Leetcode.Tests.Unit;

[TestClass]
public class FourSumServiceTests
{
    /* Input: nums = [1,0,-1,0,-2,2], target = 0 Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
     * Input: nums = [2,2,2,2,2], target = 8 Output: [[2,2,2,2]] */

    [DataTestMethod]
    [DynamicData(nameof(CombinationTests), DynamicDataSourceType.Method)]
    public void FourSum(TestCollectionData testData)
    {
        var result = FourSumService.GetUniqueQuadruplets(testData.Nums, testData.Target);
        Assert.AreEqual(testData.Expected.SelectMany(x => x).Count(), result.SelectMany(x => x).Count());
    }

    public static IEnumerable<TestCollectionData[]> CombinationTests()
    {
        yield return new[] { new TestCollectionData(new List<IList<int>> { new[] { -2, -1, 1, 2 }, new[] { -2, 0, 0, 2 }, new[] { -1, 0, 0, 1 } }, 0, new[] { 1, 0, -1, 0, -2, 2 }) };
        yield return new[] { new TestCollectionData(new List<IList<int>> { }, 1896, new[] { -490, -481, -471, -467, -453, -450, -446, -440, -437, -424, -423, -391, -384, -373, -358, -332, -318, -314, -311, -309, -299, -279, -270, -257, -243, -208, -205, -171, -153, -147, -142, -138, -129, -99, -20, -19, 17, 30, 44, 82, 86, 93, 122, 125, 138, 139, 158, 169, 175, 181, 199, 200, 203, 203, 205, 225, 248, 272, 277, 306, 334, 335, 337, 338, 342, 344, 359, 396, 403, 405, 412, 434, 437, 439, 440, 441, 443, 446, 446, 457, 465, 468, 473, 496 }) };
        yield return new[] { new TestCollectionData(new List<IList<int>> { new[] { 2, 2, 2, 2 } }, 8, new[] { 2, 2, 2, 2, 2 }) };
        yield return new[] { new TestCollectionData(new List<IList<int>> { }, -294967296, new[] { 1000000000, 1000000000, 1000000000, 1000000000 }) };
    }
}