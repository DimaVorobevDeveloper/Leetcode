﻿namespace Leetcode.Services
{
    public static class IsPowerOfTwoTask
    {
       public static bool IsPowerOfTwo(int n)
       {
            // n = 2^x
            // /*
            // 2^0 = 1
            // 2^1 = 2
            // 2^2 = 4
            // 2^3 = 8
            // 2^4 = 16
            // 2^5 = 32
            // 2^6 = 64
            // 2^7 = 128
            // 2^8 = 256
            // 2^9 = 512
            // 2^10 = 1024
            // 2^11 = 2048
            // 2^12 = 4096
            // 2^13 = 8192
            // 2^14 = 16384
            // */
            try
            {
                if (n == 0) return false;

                double t = Math.Log2(n);
                double t1 = Convert.ToDouble((int)t); 
                return Math.Abs(t - t1) == 0;
            }
            catch (Exception)
            {
            }

            return false;
       }
    }
}
