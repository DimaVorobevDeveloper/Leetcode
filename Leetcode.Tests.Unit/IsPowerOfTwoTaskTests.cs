using Leetcode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tests.Unit
{
    [TestClass]
    public class IsPowerOfTwoTaskTests
    {
        // n = 2^x
        /*
             2^0 = 1
             2^1 = 2
             2^2 = 4
             2^3 = 8
             2^4 = 16
             2^5 = 32
             2^6 = 64
             2^7 = 128
             2^8 = 256
             2^9 = 512
             2^10 = 1024
             2^11 = 2048
             2^12 = 4096
             2^13 = 8192
             2^14 = 16384
        */
        [TestMethod]
        [DataRow(8, true)]
        [DataRow(2048, true)]
        [DataRow(20, false)]
        public void LetterCombinations(int n, bool expected)
        {
            var result = IsPowerOfTwoTask.IsPowerOfTwo(n);

            Assert.AreEqual(expected, result);
        }
    }
}
