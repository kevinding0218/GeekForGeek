using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    /// <summary>
    /// For an example, Let’s say you buy some items at the store and the change from your purchase is 63 cents. 
    /// How does the clerk determine the change to give you? 
    /// If the clerk follows a greedy algorithm, 
    /// he or she gives you two quarters, a dime, and three pennies. 
    /// That is the smallest number of coins that will equal 63 cents.
    /// </summary>
    public static class CoinChange
    {
        static void MakeChange(double origAmount, double
                            remainAmount, int[] coins)
        {
            if ((origAmount % 25) < origAmount)
            {
                coins[3] = (int)(origAmount / 25);
                remainAmount = origAmount % 25;
                origAmount = remainAmount;
            }
            if ((origAmount % 10) < origAmount)
            {
                coins[2] = (int)(origAmount / 10);
                remainAmount = origAmount % 10;
                origAmount = remainAmount;
            }
            if ((origAmount % 5) < origAmount)
            {
                coins[1] = (int)(origAmount / 5);
                remainAmount = origAmount % 5;
                origAmount = remainAmount;
            }
            if ((origAmount % 1) < origAmount)
            {
                coins[0] = (int)(origAmount / 1);
                remainAmount = origAmount % 1;
            }
        }
        static void ShowChange(int[] arr)
        {
            if (arr[3] > 0)
                Console.WriteLine("Number of quarters(25): " +
                arr[3]);
            if (arr[2] > 0)
                Console.WriteLine("Number of dimes(10): " + arr[2]);
            if (arr[1] > 0)
                Console.WriteLine("Number of nickels(5): " + arr[1]);
            if (arr[0] > 0)
                Console.WriteLine("Number of pennies(1): " + arr[0]);
        }
        public static void Test()
        {
            Console.WriteLine("Enter the amount you want to change:");
            double origAmount = Convert.ToDouble(Console.ReadLine());
            double toChange = origAmount;
            double remainAmount = 0.0;
            int[] coins = new int[4];
            MakeChange(origAmount, remainAmount, coins);

            Console.WriteLine("The best way to change " +
            toChange + " cents is: ");
            ShowChange(coins);
        }
    }
}
