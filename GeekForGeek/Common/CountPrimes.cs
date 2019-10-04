using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class CountPrimes
    {
        //Time: O(nloglogn) Space: O(n)
        public static int solution(int n)
        {
            int ans = 0;
            bool[] isPrime = new bool[n + 1];
            System.Array.Fill(isPrime, true);

            isPrime[0] = false;

            if (n > 0) isPrime[1] = false;

            for (int i = 2; i < n; ++i)
            {
                if (!isPrime[i]) continue;
                ++ans;

                for (int j = 2 * i; j < n; j += i)
                    isPrime[j] = false;
            }
            return ans;
        }
    }
}
